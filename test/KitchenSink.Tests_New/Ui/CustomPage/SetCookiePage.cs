using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.CustomPage
{
    public class SetCookiePage : BasePage
    {
        public SetCookiePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}
