using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests.Ui.BooleanPage
{
    public class ToggleButtonPage : BasePage
    {
        public ToggleButtonPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-tooglebutton__label")]
        public IWebElement InfoLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test__tooglebutton")]
        public IWebElement ToogleButton { get; set; }

        public void ChangeToggleButtonState()
        {
            ClickOn(ToogleButton);
        }
    }
}
