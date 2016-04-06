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
    public class CheckBoxPageTest : BaseTest
    {
        private string canDrive = "You can drive";
        private string cantDrive = "You can't drive";

        public CheckBoxPageTest(string browser) : base(browser) {}

        [Test]
        public void PageLoads() {
            driver.Navigate().GoToUrl(baseURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.LinkText("Checkbox")));
            driver.FindElement(By.LinkText("Checkbox")).Click();
            wait.Until(_driver => _driver.FindElement(By.XPath("(//input)[1]")));
            IWebElement element = driver.FindElement(By.XPath("(//input)[1]"));
            Assert.AreEqual(element.GetAttribute("type"), "checkbox");
        }

        [Test]
        public void CheckboxUnchecked()
        {
            driver.Navigate().GoToUrl(baseURL + "/Checkbox");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.XPath("(//input)[1]")));
            IWebElement element = driver.FindElement(By.XPath("(//input)[1]"));
            Assert.AreEqual(element.GetAttribute("type"), "checkbox");
            element.Click();
            wait.Until((x) => {
                return !canDrive.Equals(driver.FindElement(By.CssSelector("div.kitchensink-layout__column-right > starcounter-include > div")).Text);
            });
            var uncheckedText = driver.FindElement(By.CssSelector("div.kitchensink-layout__column-right > starcounter-include > div")).Text;
            Assert.AreEqual(cantDrive, uncheckedText);
        }

        [Test]
        public void CheckboxUncheckedAndCheckedAgain()
        {
            driver.Navigate().GoToUrl(baseURL + "/Checkbox");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.XPath("(//input)[1]")));
            IWebElement element = driver.FindElement(By.XPath("(//input)[1]"));
            Assert.AreEqual(element.GetAttribute("type"), "checkbox");
            element.Click();
            wait.Until((x) => {
                return !canDrive.Equals(driver.FindElement(By.CssSelector("div.kitchensink-layout__column-right > starcounter-include > div")).Text);
            });
            var uncheckedText = driver.FindElement(By.CssSelector("div.kitchensink-layout__column-right > starcounter-include > div")).Text;
            Assert.AreEqual(cantDrive, uncheckedText);
            element.Click();
            wait.Until((x) => {
                return !cantDrive.Equals(driver.FindElement(By.CssSelector("div.kitchensink-layout__column-right > starcounter-include > div")).Text);
            });
            var checkedText = driver.FindElement(By.CssSelector("div.kitchensink-layout__column-right > starcounter-include > div")).Text;
            Assert.AreEqual(canDrive, checkedText);
        }
    }
}
