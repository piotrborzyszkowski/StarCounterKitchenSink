using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using KitchenSink.Tests;

namespace KitchenSink.Test {

    [TestFixture("firefox")]
    [TestFixture("chrome")]
    [TestFixture("edge")]
    //[TestFixture("internet explorer")]
    public class ValidationPageTest : BaseTest
    {
        public ValidationPageTest(string browser) : base(browser) {}

        [Test]
        public void ValidationPage_PageLoads() {
            driver.Navigate().GoToUrl(baseURL + "/Validation");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("html body puppet-client")));
        }

        [Test]
        public void ValidationPage_InvalidRequireInput() {
            driver.Navigate().GoToUrl(baseURL + "/Validation");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("div.kitchensink-layout__column-right > starcounter-include > input[type='text']")));
            var label = driver.FindElement(By.XPath("(//label[@class='error-label'])[1]"));
            var originalText = label.Text;
            Assert.AreEqual(string.Empty, originalText);
            driver.FindElement(By.XPath("//button")).ClickUsingMouse(driver);
            wait.Until(x => !label.Text.Equals(originalText));
            Assert.AreEqual("'Name' should not be empty.", driver.FindElement(By.XPath("(//label[@class='error-label'])[1]")).Text);
        }

        [Test]
        public void ValidationPage_ValidRequireInput()
        {
            driver.Navigate().GoToUrl(baseURL + "/Validation");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("div.kitchensink-layout__column-right > starcounter-include > input[type='text']")));
            var label = driver.FindElement(By.XPath("(//label[@class='error-label'])[1]"));
            var originalText = label.Text;
            Assert.AreEqual(string.Empty, originalText);
            driver.FindElement(By.XPath("(//input)[1]")).Clear();
            driver.FindElement(By.XPath("(//input)[1]")).SendKeys("Marcin");
            wait.Until(d => d.FindElement(By.XPath("(//input)[1]")).GetAttribute("value") != string.Empty);
            driver.FindElement(By.XPath("//button")).ClickUsingMouse(driver);
            Assert.AreEqual(string.Empty, driver.FindElement(By.XPath("(//label[@class='error-label'])[1]")).Text);
        }
    }
}
