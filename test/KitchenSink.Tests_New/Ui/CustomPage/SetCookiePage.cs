using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Test.Custom
{
    public class SetCookiePage : BasePage
    {
        public SetCookiePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}
