using Starcounter;
using System.Collections.Generic;

namespace KitchenSink
{
    [Database]
    public class Book
    {
        public string Author;
        public string Title;
    }

    partial class PaginationPage : Json
    {
        protected override void OnData()
        {
            base.OnData();

            var firstBook = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b").First;
            if (firstBook == null)
            {
                // creates some dummy data
                int elementsInTotal = 100;
                Db.Transact(() =>
                {
                    for (int i = 0; i < elementsInTotal; i++)
                    {
                        var book = new Book()
                        {
                            Author = "George R.R Martin",
                            Title = "Game of Thrones " + (i + 1).ToString()
                        };
                    }
                });
            }

            setPageEntries();
            this.EntriesPerPage = 5;
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", this.EntriesPerPage, this.EntriesPerPage * (currentOffset - 1));
            createPages(this.EntriesPerPage);
        }

        long totalEntries = Db.SQL<long>("SELECT COUNT(e) FROM KitchenSink.Book e").First;

        // Decides the number of entries the user can choose between
        public void setPageEntries()
        {
            var page = this.PageEntries.Add();
            page.Amount = 5;

            page = this.PageEntries.Add();
            page.Amount = 15;

            page = this.PageEntries.Add();
            page.Amount = 30;
        }

        public void createPages(long entriesPerPage)
        {
            this.Pages.Clear();
            long pagesNeeded = (totalEntries / entriesPerPage) + 1;



            for (int i = 1; i < pagesNeeded; i++)
            {
                var page = this.Pages.Add();
                page.PageNumber = i;
            }
        }

        long currentOffset = 0;

        void Handle(Input.EntriesPerPage action)
        {
            createPages(action.Value);
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", action.Value, currentOffset);
        }

        // Handles the click on the number buttons
        void Handle(Input.ChangePage action)
        {
            currentOffset = this.EntriesPerPage * (action.Value - 1);
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", this.EntriesPerPage, this.EntriesPerPage * (action.Value - 1));
        }

        // Handles click on previous button
        void Handle(Input.PreviousPage action)
        {
            currentOffset = currentOffset - this.EntriesPerPage >= 0 ? currentOffset - this.EntriesPerPage : 0;
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", this.EntriesPerPage, currentOffset);
        }

        void Handle(Input.NextPage action)
        {
            if (currentOffset + this.EntriesPerPage < totalEntries)
            {
                currentOffset = currentOffset + this.EntriesPerPage;
            }
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", this.EntriesPerPage, currentOffset);
        }
    }
}