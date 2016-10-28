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
            this.TotalEntries = Db.SQL<long>("SELECT COUNT(e) FROM KitchenSink.Book e").First;
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", this.EntriesPerPage, this.EntriesPerPage * (currentOffset - 1));
            this.TotalPages = this.TotalEntries / this.EntriesPerPage;
            this.CurrentPage = 1;
            createNavButtons(this.EntriesPerPage);
        }

        // Decides the number of entries the user can choose between
        public void setPageEntries()
        {
            int[] entryChoices = new int[] { 5, 15, 30 };
            foreach (int entry in entryChoices)
            {
                var page = this.PageEntries.Add();
                page.Amount = entry;
            }
        }

        public void createNavButtons(long entriesPerPage, long currentOffset = 1)
        {
            this.Pages.Clear();
            long pagesNeeded = this.TotalEntries / entriesPerPage + 1;
            long currentPage = currentOffset / entriesPerPage;

            for (long i = currentPage - 1; i < currentPage + 4; i++)
            {
                if (i > 0 && i < pagesNeeded)
                {
                    var page = this.Pages.Add();
                    page.PageNumber = i;
                }
            }
            this.CurrentPage = currentOffset / entriesPerPage + 1;
        }

        long currentOffset = 0;

        void Handle(Input.EntriesPerPage action)
        {
            createNavButtons(action.Value, currentOffset);
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", action.Value, currentOffset);
            this.TotalPages = this.TotalEntries / this.EntriesPerPage;
        }

        void Handle(Input.ChangePage action)
        {
            currentOffset = this.EntriesPerPage * (action.Value - 1);
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", this.EntriesPerPage, this.EntriesPerPage * (action.Value - 1));
            createNavButtons(this.EntriesPerPage, currentOffset);
        }

        void Handle(Input.PreviousPage action)
        {
            currentOffset = currentOffset - this.EntriesPerPage >= 0 ? currentOffset - this.EntriesPerPage : 0;
            changePage(currentOffset);
        }

        void Handle(Input.NextPage action)
        {
            if (currentOffset + this.EntriesPerPage < this.TotalEntries)
            {
                currentOffset = currentOffset + this.EntriesPerPage;
            }
            changePage(currentOffset);
        }

        void Handle(Input.LastPage action)
        {
            currentOffset = this.TotalEntries - this.EntriesPerPage;
            changePage(currentOffset);
        }

        void Handle(Input.FirstPage action)
        {
            currentOffset = 0;
            changePage(currentOffset);
        }

        public void changePage(long currentOffset)
        {
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", this.EntriesPerPage, currentOffset);
            createNavButtons(this.EntriesPerPage, currentOffset);
        }
    }
}