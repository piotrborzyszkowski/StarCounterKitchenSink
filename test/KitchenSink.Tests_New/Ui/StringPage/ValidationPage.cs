using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Test.String
{
    public class ValidationPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Name']")]
        public IWebElement NameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Last name']")]
        public IWebElement LastNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Validate']")]
        public IWebElement ValidateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@class = 'error-label' and @slot = 'KitchenSink/3']")]
        public IWebElement NameErrorLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@class = 'error-label' and @slot = 'KitchenSink/7']")]
        public IWebElement LastNameErrorLabel { get; set; }

        public ValidationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public void InsertName(string name)
        {
            WaitForElementToBeClickable(NameInput, 4);
            NameInput.SendKeys(name);
        }

        public void InsertLastName(string lastName)
        {
            WaitForElementToBeClickable(LastNameInput, 4);
            LastNameInput.SendKeys(lastName);
        }

        public void Validate()
        {
            ClickOn(ValidateButton);
        }

        public string GetNameError()
        {
            return NameErrorLabel.Text;
        }

        public string GetLastNameError()
        {
            return LastNameErrorLabel.Text;
        }
    }
}