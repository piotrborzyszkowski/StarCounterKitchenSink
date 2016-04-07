using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using KitchenSink.Tests;

namespace KitchenSink.Test {

    [TestFixture("firefox")]
    [TestFixture("chrome")]
    //[TestFixture("edge")]
    //[TestFixture("internet explorer")]
    public class TextPageTest : BaseTest
    {
        public TextPageTest(string browser) : base(browser) {}

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
    }
}
