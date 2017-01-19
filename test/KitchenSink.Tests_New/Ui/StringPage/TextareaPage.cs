using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Test.String
{
    public class TextareaPage : BasePage
    {
        public TextareaPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-textarea")]
        public IWebElement Textarea { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-label")]
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

        public string GetTextareaInfoLabel()
        {
            return TextareaInfoLabel.Text;
        }
    }
}