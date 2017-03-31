using Starcounter;

namespace KitchenSink
{
    public partial class SortableListPage : Json
    {
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
                "".ToString();
            }

            public void Handle(Input.MoveDown action)
            {
                "".ToString();
            }
        }
    }
}
