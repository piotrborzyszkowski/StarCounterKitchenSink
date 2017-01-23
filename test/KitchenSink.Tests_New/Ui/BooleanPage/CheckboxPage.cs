using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.BooleanPage
{
    public class CheckboxPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".automated-tests-driverLicenseLabel")]
        public IWebElement InfoLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-driverLicenseInput")]
        public IWebElement Checkbox { get; set; }

        public CheckboxPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public bool GetCheckboxState()
        {
            return Checkbox.Selected;
        }

        public void ChangeCheckboxState()
        {
            ClickOn(Checkbox);
        }
    }
}
