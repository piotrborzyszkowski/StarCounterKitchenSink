using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Test.Boolean
{
    public class CheckboxPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@slot = 'KitchenSink/3']")]
        public IWebElement InfoLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type = 'checkbox']")]
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

        public string GetInfoLabelString()
        {
            return InfoLabel.Text;
        }
    }
}
