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

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-passwordInput")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-Infolabel")]
        public IWebElement PaswordInputInfoLabel { get; set; }

        public void FillPassword(string password)
        {
            PasswordInput.SendKeys(password);
        }

        public string GetPasswordInfoLabel()
        {
            return PaswordInputInfoLabel.Text;
        }

        public void ClearPassword()
        {
            PasswordInput.Clear();
        }
    }
}