using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests.Ui.BooleanPage
{
    public class ButtonPage : BasePage
    {     
        public ButtonPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-carrots-reaction__label")]
        public IWebElement InfoLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Button (inline script)']")]
        public IWebElement CarrotsButton1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Button (function)']")]
        public IWebElement CarrotsButton2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text() = 'Span (function)']")]
        public IWebElement CarrotsSpan { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Enable carrot engine']")]
        public IWebElement SwitchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Add carrots']")]
        public IWebElement DisableButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-carrot-engine-reaction__label")]
        public IWebElement SwitchButtonLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-one-carrot-reaction__label")]
        public IWebElement DisableButtonLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Take one Regenerating Carrot']")]
        public IWebElement SelfButton1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Take one Regenerating Carrot(with delay)']")]
        public IWebElement SelfButton2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-self-button__label")]
        public IWebElement SelfButtonLabel { get; set; }

        public void ClickButton1()
        {
            ClickOn(CarrotsButton1);
        }

        public void ClickButton2()
        {
            ClickOn(CarrotsButton2);
        }

        public void ClickSpan()
        {
            ClickOn(CarrotsSpan);
        }

        public void ClickSwitchButton()
        {
            ClickOn(SwitchButton);
        }

        public void ClickDisableButton()
        {
            ClickOn(DisableButton);
        }

        public void ClickSelfButton1()
        {
            ClickOn(SelfButton1);
        }

        public void ClickSelfButton2()
        {
            ClickOn(SelfButton2);
        }
    }
}
