using Starcounter;
using System;
using System.Linq;

namespace KitchenSink
{
    public partial class SortableListPage : Json
    {
        public void LoadData()
        {
            var persons = Db.SQL<KitchenSink.Person>("SELECT p FROM KitchenSink.Person p ORDER BY p.OrderNumber").Skip(3).Take(5).ToList();
            this.Data = new
            {
                Persons = persons
            };
        }

        public void Handle(Input.PreviousPage action)
        {
            "".ToString();
        }

        public void Handle(Input.NextPage action)
        {
            "".ToString();
        }

        [SortableListPage_json.Persons]
        public partial class Person : Json
        {
            public void Handle(Input.MoveUp action)
            {
                var person = (KitchenSink.Person)this.Data;
                if (person.OrderNumber <= 1)
                {
                    throw new ArgumentOutOfRangeException("Unable to move up the first person");
                }

                var previousPerson = Db.SQL<KitchenSink.Person>("SELECT p FROM KitchenSink.Person p WHERE p.OrderNumber = ?", person.OrderNumber - 1).First;
                person.OrderNumber--;
                previousPerson.OrderNumber++;

                //((SortableListPage)Parent).LoadData();

                Transaction.Commit();
                //List<KitchenSink.Person> persons = Parent.Data
            }

            public void Handle(Input.MoveDown action)
            {
                "".ToString();
            }
        }
    }
}
