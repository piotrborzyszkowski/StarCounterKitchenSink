using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.StringPage
{
    public class ValidationPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Name']")]
        public IWebElement NameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Last name']")]
        public IWebElement LastNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Validate']")]
        public IWebElement ValidateButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-nameErrorlabel")]
        public IWebElement NameErrorLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-lastNameErrorLabel")]
        public IWebElement LastNameErrorLabel { get; set; }

        public ValidationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public void InsertName(string name)
        {
            NameInput.SendKeys(name);  
            NameInput.SendKeys(Keys.Enter);
        }

        public void InsertLastName(string lastName)
        {
            LastNameInput.SendKeys(lastName);
            LastNameInput.SendKeys(Keys.Enter);
        }

        public void Validate()
        {
            ClickOn(ValidateButton);
        }
    }
}