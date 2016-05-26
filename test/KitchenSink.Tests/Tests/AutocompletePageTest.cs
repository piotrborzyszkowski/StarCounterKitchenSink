using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Tests {

    [TestFixture("firefox")]
    [TestFixture("chrome")]
    [TestFixture("edge")]
    public class AutocompletePageTest : BaseTest
    {
        private WebDriverWait _wait;
        private static readonly By PlacesSearchSelector = By.CssSelector("[placeholder='Poland? Sweden?']");
        private static readonly By ProductsSearchSelector = By.CssSelector("[placeholder='Whiskey? Whisky?']");
        private static readonly By FoundPlacesSelector = By.CssSelector("[title='places'] ul.kitchensink-autocomplete li");
        private static readonly By FoundProductsSelector = By.CssSelector("[title='products'] ul.kitchensink-autocomplete li");

        public AutocompletePageTest(string browser) : base(browser) {
        }

        [SetUp]
        public void Setup() {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(baseURL + "/Autocomplete");
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("html body puppet-client")));
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(PlacesSearchSelector));
        }

        [Test]
        public void FillStarExpectAllItemsShowUp() {
            driver.FindElement(PlacesSearchSelector).SendKeys("*");
            WaitForElementsToLoad(FoundPlacesSelector);
            Assert.AreEqual(7, driver.FindElements(FoundPlacesSelector).Count);

            driver.FindElement(ProductsSearchSelector).SendKeys("*");
            WaitForElementsToLoad(FoundProductsSelector);
            Assert.AreEqual(6, driver.FindElements(FoundProductsSelector).Count);
        }

        // TODO: Renable once the test fixed by Marcin.
        //[Test]
        public void FillCountryNameThenSelectCountry() {
            driver.FindElement(PlacesSearchSelector).SendKeys("po");
            WaitForElementsToLoad(FoundPlacesSelector);
            Assert.AreEqual(new[] { "Poland", "Portugal"}, driver.FindElements(FoundPlacesSelector).Select(el=>el.Text).ToArray());
            AssertElements(FoundPlacesSelector, "Poland", "Portugal");
            driver.FindElements(FoundPlacesSelector)[0].Click();
            Assert.IsEmpty(driver.FindElements(FoundPlacesSelector));
            Assert.AreEqual("Poland", driver.FindElement(PlacesSearchSelector).GetAttribute("value"), "Search textbox has invalid content");
            Assert.AreEqual("Poland", driver.FindElement(PlacesSearchSelector).GetAttribute("value"), "Search textbox has invalid content");
            Assert.AreEqual("Capital of Poland is Warsaw", driver.FindElement(By.Id("kitchensink-autocomplete-capital")).Text,
                "Invalid capital text");
        }

        // TODO: Renable once the test fixed by Marcin.
        //[Test]
        public void FillProductNameThenSelectProduct() {
            driver.FindElement(ProductsSearchSelector).SendKeys("Whisk");
            WaitForElementsToLoad(FoundProductsSelector);
            AssertElements(FoundProductsSelector, "Scotch Whisky", "Irish Whiskey");
            driver.FindElements(FoundProductsSelector)[1].Click();
            Assert.IsEmpty(driver.FindElements(FoundProductsSelector));
            Assert.AreEqual("Irish Whiskey", driver.FindElement(ProductsSearchSelector).GetAttribute("value"), "Search textbox has invalid content");
            Assert.AreEqual("Irish Whiskey costs $2", driver.FindElement(By.Id("kitchensink-autocomplete-price")).Text,
                "Invalid capital text");
        }

        private void AssertElements(By elementsSelector, params string[] expected) {
            Assert.That(driver.FindElements(elementsSelector).Select(el => el.Text).ToArray(), Is.EquivalentTo(expected ).IgnoreCase);
        }

        [Test]
        public void FillPlaceNameThenBlurExpectHintsGone() {
            if (browser == "edge") {
                Assert.Ignore("Blur event does not fire in edge under selenium");
            }
            var placesSearchbox = driver.FindElement(PlacesSearchSelector);
            placesSearchbox.SendKeys("po");
            WaitForElementsToLoad(FoundPlacesSelector);
            placesSearchbox.SendKeys(Keys.Tab);
            driver.FindElement(ProductsSearchSelector).Click();
            _wait.Until(d => d.FindElements(FoundPlacesSelector).Count == 0);
            Assert.IsEmpty(driver.FindElements(FoundPlacesSelector));
        }

        private void WaitForElementsToLoad(By selector) {
            _wait.Until(d => d.FindElements(selector).Count != 0);
        }
    }
}
