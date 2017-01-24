using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.StringPage
{
    public class TextareaPage : BasePage
    {
        public TextareaPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests__textarea")]
        public IWebElement Textarea { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-bio-reaction__label")]
        public IWebElement TextareaInfoLabel { get; set; }

        public void FillTextarea(string input)
        {
            Textarea.SendKeys(input);
        }

        public void ClearTextarea()
        {
            var temp = Textarea.GetAttribute("test-value").Length;

            for (var i = 0; i < temp; i++)
            {
                Textarea.SendKeys(Keys.Backspace);
            }
        }
    }
}