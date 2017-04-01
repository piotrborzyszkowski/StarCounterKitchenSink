using KitchenSink.Model.Page;
using Starcounter;
using System;
using System.Linq;

namespace KitchenSink
{
    public partial class SortableListPage : Json
    {
        public const int pageSize = 5;

        public void LoadData()
        {
            var data = (SortableListPageData) this.Data;
            if (data == null)
            {
                this.Data = data = new SortableListPageData();
            }

            data.Persons = Db.SQL<Model.Persistent.Person>("SELECT p FROM KitchenSink.Model.Persistent.Person p ORDER BY p.OrderNumber").Skip(data.PageNumber * pageSize).Take(pageSize).ToList();

            var count = Db.SQL<long>("SELECT count(p.OrderNumber) FROM KitchenSink.Model.Persistent.Person p").First;
            data.MaxPageNumber = Convert.ToInt32(Math.Ceiling((double)count / (double)pageSize)) - 1;
            data.MaxPageNumber = Math.Max(data.MaxPageNumber, 0);
        }

        public void Handle(Input.PreviousPage action)
        {
            var data = (SortableListPageData)this.Data;
            if (data.PageNumber == 0)
            {
                throw new ArgumentOutOfRangeException("Unable to go to the previous page, already on the first page");
            }

            data.PageNumber--;
            LoadData();
        }

        public void Handle(Input.NextPage action)
        {
            var data = (SortableListPageData)this.Data;
            if (data.PageNumber == data.MaxPageNumber)
            {
                throw new ArgumentOutOfRangeException("Unable to go to the next page, already on the last page");
            }

            data.PageNumber++;
            LoadData();
        }

        [SortableListPage_json.Persons]
        public partial class Person : Json
        {
            public void Handle(Input.MoveUp action)
            {
                var person = (Model.Persistent.Person)this.Data;
                if (person.OrderNumber <= 1)
                {
                    throw new ArgumentOutOfRangeException("Unable to move up the first person");
                }

                Move(person, -1);
            }

            public void Handle(Input.MoveDown action)
            {
                var maxOrderCount = Db.SQL<long>("SELECT max(p.OrderNumber) FROM KitchenSink.Model.Persistent.Person p").First;

                var person = (Model.Persistent.Person)this.Data;
                if (person.OrderNumber >= maxOrderCount)
                {
                    throw new ArgumentOutOfRangeException("Unable to move down the first person");
                }

                Move(person, 1);
            }

            private void Move(Model.Persistent.Person person, int step)
            {
                int moveToOrderNumber = person.OrderNumber + step;
                var previousPerson = Db.SQL<Model.Persistent.Person>("SELECT p FROM KitchenSink.Model.Persistent.Person p WHERE p.OrderNumber = ?", moveToOrderNumber).First;

                person.OrderNumber += step;
                previousPerson.OrderNumber -= step;

                ((SortableListPage)Parent.Parent).LoadData();

                Transaction.Commit();
            }
        }
    }
}
