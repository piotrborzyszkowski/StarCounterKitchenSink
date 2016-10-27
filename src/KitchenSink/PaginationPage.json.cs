using Starcounter;

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

            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ?", 5);
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

        long currentValue = 0;

        void Handle(Input.ChangePage action)
        {
            currentValue = action.Value;
            this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", 5, action.Value);
        }

        void Handle(Input.PreviousPage action)
        {
            if (currentValue > 0)
            {
                currentValue = currentValue - 5;
                this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", 5, currentValue);
            }
        }

        void Handle(Input.NextPage action)
        {
            if (currentValue < 25)
            {
                currentValue = currentValue + 5;
                this.Library.Data = Db.SQL<Book>("SELECT b FROM KitchenSink.Book b FETCH ? OFFSET ?", 5, currentValue);
            }
        }
    }
}