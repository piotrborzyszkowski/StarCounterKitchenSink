using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Test.Boolean
{
    public class ButtonPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//pre[@slot = 'KitchenSink/5']")]
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

        [FindsBy(How = How.XPath, Using = "//span[@slot = 'KitchenSink/10']")]
        public IWebElement SwitchButtonLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@slot = 'KitchenSink/14']")]
        public IWebElement DisableButtonLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Take one Regenerating Carrot']")]
        public IWebElement SelfButton1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Take one Regenerating Carrot(with delay)']")]
        public IWebElement SelfButton2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@slot = 'KitchenSink/17']//div//p")]
        public IWebElement SelfButtonLabel { get; set; }
        
        public ButtonPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

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
