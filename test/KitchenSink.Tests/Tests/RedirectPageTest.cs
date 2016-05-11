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
    public class RedirectPageTest : BaseTest
    {
        private WebDriverWait _wait;

        public RedirectPageTest(string browser) : base(browser) {
        }

        [SetUp]
        public void Setup() {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(baseURL + "/Redirect");
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//button[text()='Fruit']")));
        }

        [Test]
        public void ClickingOnFruitShouldChangeUrlAndText() {
            var fruitButton = FindButton("Fruit");
            fruitButton.Click();

            Assert.That(fruitButton.FindElement(By.XPath("following-sibling::div")).Text, Contains.Substring("apple"));
            Assert.That(driver.Url, Is.EqualTo($"{baseURL}/Redirect/apple"));
        }

        [Test]
        public void ClickingOnRedirectToAnotherPartialShouldChangeUrl() {
            FindButton("Morph to another partial").Click();
            Assert.That(driver.Url, Is.EqualTo(baseURL));
        }

        [Test]
        public void ClickingOnRedirectToDocsShouldChangeUrl() {
            FindButton("Redirect to Starcounter.io").Click();

            // see https://github.com/PuppetJs/puppet-redirect/issues/3
            if (browser == "firefox") {
                _wait.Until(ExpectedConditions.AlertIsPresent());
                driver.SwitchTo().Alert().Dismiss();
            }

            // redirecting to external page can take some time
            _wait.Until(ExpectedConditions.UrlContains("http://starcounter.io/"));
        }

        private IWebElement FindButton(string text) {
            return driver.FindElement(By.XPath($"//button[text()='{text}']"));
        }
    }
}
