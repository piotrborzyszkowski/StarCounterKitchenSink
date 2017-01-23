using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests_New.Ui.CustomPage
{
    public class PaginationPage : BasePage
    {
        public PaginationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-dropdown select")]
        public IWebElement DropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-paginationResult")]
        public IList<IWebElement> PaginationResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-pagination li")]
        public IWebElement Pagination { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-label")]
        public IWebElement PaginationInfoLabel { get; set; }

        public void DropdownSelect(string p0)
        {
            SelectElement dropDown = new SelectElement(DropDown);
            dropDown.SelectByText(p0);
        }

        public int CountPaginationResult()
        {
            return PaginationResult.Count;
        }

        internal void GoToPage(string v)
        {
            ClickOn(Pagination.FindElement(By.XPath("//span[text() = '" + v + "']")));
        }

        public string GetTitle(string p0)
        {
            var temp = PaginationResult.Where(x => x.Text.Contains(p0)).Select(x => x.Text).First();
            return temp;
        }
    }
}
