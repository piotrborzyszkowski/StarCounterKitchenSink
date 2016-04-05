using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Test {
    [TestFixture("firefox")]
    [TestFixture("chrome")]
    //[TestFixture("edge")]
    //[TestFixture("internet explorer")]
    public class MarcinNunit {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private string browser;

        public MarcinNunit(string browser) {
            this.browser = browser;
        }

        [SetUp]
        public void SetupTest() {
            driver = WebDriverFactory.Create(this.browser);
            baseURL = "http://localhost:8080/KitchenSink";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest() {
            try {
                driver.Quit();
            }
            catch (Exception) {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void PageLoads() {
            driver.Navigate().GoToUrl(baseURL + "/Text");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(_driver => _driver.FindElement(By.XPath("/html/body/puppet-client")));
        }

        [Test]
        public void TextPropagationOnUnfocus() {
            driver.Navigate().GoToUrl(baseURL + "/Text");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(_driver => _driver.FindElement(By.XPath("(//input)[1]")));
            var label = driver.FindElement(By.XPath("(//label[@class='control-label'])[1]"));
            var originalText = label.Text;
            driver.FindElement(By.XPath("(//input)[1]")).Clear();
            driver.FindElement(By.XPath("(//input)[1]")).SendKeys("Marcin");
            driver.FindElement(By.XPath("//body")).Click();
            wait.Until((x) => {
                return !label.Text.Equals(originalText);
            });
            Assert.AreEqual("Hi, Marcin!", driver.FindElement(By.XPath("(//label[@class='control-label'])[1]")).Text);
        }

        [Test]
        public void TextPropagationWhileTyping() {
            driver.Navigate().GoToUrl(baseURL + "/Text");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(_driver => _driver.FindElement(By.XPath("(//input)[2]")));
            var label = driver.FindElement(By.XPath("(//label[@class='control-label'])[2]"));
            var originalText = label.Text;
            driver.FindElement(By.XPath("(//input)[2]")).Clear();
            driver.FindElement(By.XPath("(//input)[2]")).SendKeys("M");
            wait.Until((x) => {
                return !label.Text.Equals(originalText);
            });
            Assert.AreEqual("Hi, M!", driver.FindElement(By.XPath("(//label[@class='control-label'])[2]")).Text);
        }

        private bool IsElementPresent(By by) {
            try {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException) {
                return false;
            }
        }
    }
}
