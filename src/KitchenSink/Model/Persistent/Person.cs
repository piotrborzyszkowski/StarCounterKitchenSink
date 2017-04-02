using Starcounter;

namespace KitchenSink.Model.Persistent
{
    [Database]
    public class Person
    {
        public Person(string firstName, string lastName, int orderNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            OrderNumber = orderNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long OrderNumber { get; set; }
    }
}
