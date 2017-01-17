using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Test.Array
{
    public class RadiolistPage : BasePage
    {
        public RadiolistPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}
