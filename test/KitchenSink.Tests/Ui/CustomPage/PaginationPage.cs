using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Ui.CustomPage
{
    public class PaginationPage : BasePage
    {
        public PaginationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test__juicy-select select")]
        public IWebElement DropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-pagination-result__li")]
        public IList<IWebElement> PaginationResult { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-pagination li")]
        public IWebElement Pagination { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-pagination__label")]
        public IWebElement PaginationInfoLabel { get; set; }

        public void DropdownSelect(string p0)
        {
            SelectElement dropDown = new SelectElement(DropDown);
            dropDown.SelectByText(p0);
        }

        internal void GoToPage(string v)
        {
            ClickOn(Pagination.FindElement(By.XPath("//span[text() = '" + v + "']")));
        }
    }
}
