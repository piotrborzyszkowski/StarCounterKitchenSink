using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests.Ui.SectionBoolean
{
    public class CheckboxPage : BasePage
    {
        public CheckboxPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-driver-license__label")]
        public IWebElement InfoLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-driver-license__input")]
        public IWebElement Checkbox { get; set; }

        public void ChangeCheckboxState()
        {
            ClickOn(Checkbox);
        }
    }
}
