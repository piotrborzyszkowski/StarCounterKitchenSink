using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.BooleanPage
{
    public class ToggleButtonPage : BasePage
    {
        public ToggleButtonPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-tooglebutton__label")]
        public IWebElement InfoLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests__tooglebutton")]
        public IWebElement ToogleButton { get; set; }

        public bool GetToogleButtonState()
        {
            return ToogleButton.Selected;
        }

        public void ChangeToogleButtonState()
        {
            ClickOn(ToogleButton);
        }
    }
}
