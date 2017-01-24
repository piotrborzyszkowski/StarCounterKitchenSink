using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.StringPage
{
    public class PasswordPage : BasePage
    {
        public PasswordPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-password__input")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-info__label")]
        public IWebElement PaswordInputInfoLabel { get; set; }

        public void FillPassword(string password)
        {
            PasswordInput.SendKeys(password);
        }

        public void ClearPassword()
        {
            PasswordInput.Clear();
        }
    }
}