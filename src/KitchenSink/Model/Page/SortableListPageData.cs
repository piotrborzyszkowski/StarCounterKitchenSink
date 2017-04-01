using KitchenSink.Model.Persistent;
using System.Collections.Generic;

namespace KitchenSink.Model.Page
{
    public class SortableListPageData
    {
        public List<Person> Persons { get; set; }

        public int PageNumber { get; set; }
        public int MaxPageNumber { get; set; }

        public int PageNumberHumanReadable
        {
            get
            {
                return PageNumber + 1;
            }
        }

        public bool PreviousPageDisabled
        {
            get
            {
                return PageNumber == 0;
            }
        }

        public bool NextPageDisabled
        {
            get
            {
                return PageNumber == MaxPageNumber;
            }
        }
    }
}
