using Starcounter;

namespace KitchenSink
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
        public int OrderNumber { get; set; }
    }
}
