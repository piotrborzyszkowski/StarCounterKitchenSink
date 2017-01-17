using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Test.String
{
    public class RedirectPage : BasePage
    {
        public RedirectPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}