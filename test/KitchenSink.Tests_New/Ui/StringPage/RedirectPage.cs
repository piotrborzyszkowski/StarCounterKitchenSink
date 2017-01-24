using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.StringPage
{
    public class RedirectPage : BasePage
    {
        public RedirectPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-fruit__button")]
        public IWebElement FruitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-vegetable__button")]
        public IWebElement VegetableButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-bread__button")]
        public IWebElement BreadButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-favourite-food__label")]
        public IWebElement InfoLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-morph__button")]
        public IWebElement MorphButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-redirect__button")]
        public IWebElement RedirectButton { get; set; }

        public void ClickButton(string button)
        {
            switch (button)
            {
                case "Bread":
                    ClickOn(BreadButton); break;
                case "Vegetable":
                    ClickOn(VegetableButton); break;
                case "Fruit":
                    ClickOn(FruitButton); break;
                case "Morph":
                    ClickOn(MorphButton); break;
                case "Redirect":
                    ClickOn(RedirectButton); break;
            }
        }
    }
}