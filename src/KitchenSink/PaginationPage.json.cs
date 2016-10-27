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
                createBooks(30);
            }

            //setAllOffsetKeys();
            getFirstFivePages();
        }

        public void createBooks(int numberOfBooks)
        {
            Db.Transact(() =>
            {
                for (int i = 1; i < numberOfBooks + 1; i++)
                {
                    var book = new Book()
                    {
                        Author = "George R.R Martin",
                        Title = "Game of Thrones " + i.ToString()
                    };
                }
            });
        }

        byte[] k = null;
        List<Book> books = new List<Book>();
        //List<byte[]> offsetKeys = new List<byte[]>();

        //public void setAllOffsetKeys()
        //{
        //    for (int i = 0; i < 30; i++)
        //    {
        //        using (IRowEnumerator<Book> a = Db.SQL<Book>("SELECT e FROM Book e FETCH ?", 1).GetEnumerator())
        //        {
        //            while (a.MoveNext()){};
        //            offsetKeys.Insert(i, a.GetOffsetKey());
        //        }
        //    }
        //}

        public void getFirstFivePages()
        {
            using (IRowEnumerator<Book> a = Db.SQL<Book>("SELECT e FROM Book e FETCH ?", 5).GetEnumerator())
            {
                while (a.MoveNext())
                {
                    books.Add(a.Current);
                };
                this.Library.Data = books;
                k = a.GetOffsetKey();
            }
        }

        void Handle(Input.ChangePage action)
        {
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", 5, action.Value);
            var test = offsetKeys;
        }

        void Handle(Input.PreviousPage action)
        {
            if (k == null) return;
            books.Clear();
            using (IRowEnumerator<Book> a = Db.SQL<Book>("SELECT e FROM Book e FETCH ? OFFSETKEY ?", 5, k).GetEnumerator())
            {
                while (a.MoveNext())
                {
                    books.Add(a.Current);
                }
                this.Library.Data = books;
                k = a.GetOffsetKey();
            }
        }

        void Handle(Input.NextPage action)
        {
            if (k == null) return;
            books.Clear();
            using (IRowEnumerator<Book> a = Db.SQL<Book>("SELECT e FROM Book e FETCH ? OFFSETKEY ?", 5, k).GetEnumerator())
            {
                while (a.MoveNext())
                {
                    books.Add(a.Current);
                }
                this.Library.Data = books;
                k = a.GetOffsetKey();
            }
        }
    }
}