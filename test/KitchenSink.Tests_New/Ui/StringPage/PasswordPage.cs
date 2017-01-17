using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Test.String
{
    public class PasswordPage : BasePage
    {
        public PasswordPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}