using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Test.String
{
    public class UrlPage : BasePage
    {
        public UrlPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}