using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Test
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public DatepickerPage GoToDatePickerPage()
        {
            ClickOn(DatepickerPageLink);
            return new DatepickerPage(Driver);
        }

        public DropdownPage GoToDropdownPage()
        {
            ClickOn(DropdownPageLink);
            return new DropdownPage(Driver);
        }

        public NestedPartialsPage GoToNestedPartialsPage()
        {
            ClickOn(NestedPartialsPageLink);
            return new NestedPartialsPage(Driver);
        }

        public TablePage GoToTablePage()
        {
            ClickOn(TablePageLink);
            return new TablePage(Driver);
        }
    }
}
