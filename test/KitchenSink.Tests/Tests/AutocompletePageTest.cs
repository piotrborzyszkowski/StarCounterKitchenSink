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
        private static readonly By PlacesSearchSelector = By.CssSelector("[placeholder='Places to go...']");
        private static readonly By BreadcrumbsSearchSelector = By.CssSelector("[placeholder='Things to buy...']");
        private static readonly By FoundPlacesSelector = By.CssSelector("[title='places'] ul.kitchensink-autocomplete li");
        private static readonly By FoundBreadcrumbsSelector = By.CssSelector("[title='breadcrumbs'] ul.kitchensink-autocomplete li");

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
            Assert.AreEqual(8, driver.FindElements(FoundPlacesSelector).Count);

            driver.FindElement(BreadcrumbsSearchSelector).SendKeys("*");
            WaitForElementsToLoad(FoundBreadcrumbsSelector);
            Assert.AreEqual(10, driver.FindElements(FoundBreadcrumbsSelector).Count);
        }

        [Test]
        public void FillCountryNameThenSelectCountry() {
            driver.FindElement(PlacesSearchSelector).SendKeys("po");
            WaitForElementsToLoad(FoundPlacesSelector);
            Assert.AreEqual(new[] { "Poland", "Portugal"}, driver.FindElements(FoundPlacesSelector).Select(el=>el.Text).ToArray());
            AssertElements(FoundPlacesSelector, "Poland", "Portugal");
            driver.FindElements(FoundPlacesSelector)[0].Click();
            Assert.IsEmpty(driver.FindElements(FoundPlacesSelector));
            Assert.AreEqual("Poland", driver.FindElement(PlacesSearchSelector).GetAttribute("value"), "Search textbox has invalid content");
        }

        [Test]
        public void FillBreadcrumbNameThenSelectBreadcrumb() {
            driver.FindElement(BreadcrumbsSearchSelector).SendKeys("Milk");
            WaitForElementsToLoad(FoundBreadcrumbsSelector);
            AssertElements(FoundBreadcrumbsSelector, "Milk", "Coffee Milk 5 ML", "Milk 1 L");
            driver.FindElements(FoundBreadcrumbsSelector)[2].Click();
            Assert.IsEmpty(driver.FindElements(FoundBreadcrumbsSelector));
            Assert.AreEqual("Milk 1 L", driver.FindElement(BreadcrumbsSearchSelector).GetAttribute("value"), "Search textbox has invalid content");
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
            driver.FindElement(BreadcrumbsSearchSelector).Click();
            _wait.Until(d => d.FindElements(FoundPlacesSelector).Count == 0);
            Assert.IsEmpty(driver.FindElements(FoundPlacesSelector));
        }

        private void WaitForElementsToLoad(By selector) {
            _wait.Until(d => d.FindElements(selector).Count != 0);
        }
    }
}
