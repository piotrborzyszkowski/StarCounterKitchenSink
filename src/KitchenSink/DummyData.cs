using KitchenSink.Model.Persistent;
using Starcounter;

namespace KitchenSink
{
    public static class DummyData
    {
        public static void Create()
        {
            Db.Transact(() =>
            {
                if (Db.SQL("SELECT p FROM KitchenSink.Model.Persistent.Person p").First == null)
                {
                    int orderNumber = 0;
                    new Person("Clemence", "Hunnisett", ++orderNumber);
                    new Person("Veronica", "Clarkson", ++orderNumber);
                    new Person("Ami", "Langley", ++orderNumber);
                    new Person("Rupert", "Donalds", ++orderNumber);
                    new Person("Geraldine", "Traviss", ++orderNumber);
                    new Person("Julius", "Edwards", ++orderNumber);
                    new Person("Jessika", "Jewel", ++orderNumber);
                    new Person("Herbert", "Wright", ++orderNumber);
                    new Person("Kori", "Wragge", ++orderNumber);
                    new Person("Dorthy", "Danniell", ++orderNumber);
                    new Person("Garry", "Leon", ++orderNumber);
                    new Person("Rudolph", "Jameson", ++orderNumber);
                    new Person("Matilda", "Earls", ++orderNumber);
                    new Person("Jessika", "Foster", ++orderNumber);
                    new Person("Jessika", "Wright", ++orderNumber);
                    new Person("Herbert", "Jameson", ++orderNumber);
                    new Person("Kori", "Hunnisett", ++orderNumber);
                    new Person("Dorthy", "Langley", ++orderNumber);
                }

                // For Dropdown page
                if (Db.SQL("SELECT p FROM KitchenSink.SoftwareProduct p").First == null)
                {
                    new SoftwareProduct { Name = "Starcounter Database" };
                    new SoftwareProduct { Name = "Polymer JavaScript library" };
                }

                // For Pagination page
                if (Db.SQL<Book>("SELECT b FROM KitchenSink.Book b").First == null)
                {
                    // change the number of element with adjusting elementsInTotal
                    int elementsInTotal = 100;
                    for (int i = 0; i < elementsInTotal; i++)
                    {
                        var book = new Book
                        {
                            Author = "Arbitrary Author",
                            Title = "Arbitrary Book " + (i + 1),
                            Position = i + 1
                        };
                    }
                }

                // For Breadcrumb page
                if (BreadcrumbTestData.Exists())
                {
                    BreadcrumbTestData.DeleteAll();
                }
                BreadcrumbTestData.Create();

                // For Autocomplete page
                if (Db.SQL("SELECT p FROM KitchenSink.GroceryProduct p").First == null)
                {
                    new GroceryProduct { Name = "Bread", Price = 1 };
                    new GroceryProduct { Name = "Butter", Price = 3 };
                    new GroceryProduct { Name = "Scotch Whisky", Price = 4 };
                    new GroceryProduct { Name = "Irish Whiskey", Price = 2 };
                    new GroceryProduct { Name = "Milk", Price = 5 };
                    new GroceryProduct { Name = "Boiled Mutton", Price = 7 };
                }
            });
        }
    }
}