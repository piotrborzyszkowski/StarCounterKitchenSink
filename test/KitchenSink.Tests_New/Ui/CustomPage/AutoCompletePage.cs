using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.CustomPage
{
    public class AutoCompletePage : BasePage
    {
        public AutoCompletePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@title = 'products']//input")]
        public IWebElement ProductsInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@title = 'places']//input")]
        public IWebElement PlaceInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@title = 'products']//ul//li")]
        public IList<IWebElement> ProductsAutoComplete { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@title = 'places']//ul//li")]
        public IList<IWebElement> PlacesAutoComplete { get; set; }

        [FindsBy(How = How.Id, Using = "kitchensink-autocomplete-capital")]
        public IWebElement PlaceInfoLabel { get; set; }

        [FindsBy(How = How.Id, Using = "kitchensink-autocomplete-price")]
        public IWebElement ProductsInfoLabel { get; set; }

        public void SendKeyProductsInput(string s)
        {
            ProductsInput.SendKeys(s);
        }

        public void SendKeyPlacesInput(string s)
        {
            PlaceInput.SendKeys(s);
        }

        public void ChoosePlace(string s)
        {
            var test = (from temp in PlacesAutoComplete where temp.Text == s select temp).First();
            test.Click();

        }

        public void ChooseProducts(string b)
        {
            var test = (from temp in ProductsAutoComplete where temp.Text == b select temp).First();
            test.Click();
        }

        public void ClearProductsInput()
        {
            ProductsInput.Clear();
        }

        public void ClearPlaceInput()
        {
            PlaceInput.Clear();
        }
    }
}
