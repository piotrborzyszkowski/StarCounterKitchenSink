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
    public class PasswordPageTest : BaseTest
    {
        private string passwordTooShort = "Password must be at least 6 chars long";
        private string passwordWithProperLength = "Good password!";

        public PasswordPageTest(string browser) : base(browser) {}

        [Test]
        public void PageLoads() {
            driver.Navigate().GoToUrl(baseURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.LinkText("Password")));
            driver.FindElement(By.LinkText("Password")).Click();
            wait.Until(_driver => _driver.FindElement(By.XPath("(//input)[1]")));
            IWebElement element = driver.FindElement(By.XPath("(//input)[1]"));
            Assert.AreEqual(element.GetAttribute("type"), "password");
        }

        [Test]
        public void PasswordTooShort()
        {
            driver.Navigate().GoToUrl(baseURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.LinkText("Password")));
            driver.FindElement(By.LinkText("Password")).Click();
            wait.Until(_driver => _driver.FindElement(By.XPath("(//input)[1]")));
            IWebElement element = driver.FindElement(By.XPath("(//input)[1]"));
            Assert.AreEqual(element.GetAttribute("type"), "password");
            driver.FindElement(By.XPath("(//input)[1]")).Clear();
            driver.FindElement(By.XPath("(//input)[1]")).SendKeys("Short");
            Assert.AreEqual(passwordTooShort, driver.FindElement(By.XPath("(//label[@class='control-label'])[1]")).Text);
        }

        [Test]
        public void PasswordWithProperLength()
        {
            driver.Navigate().GoToUrl(baseURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.LinkText("Password")));
            driver.FindElement(By.LinkText("Password")).Click();
            wait.Until(_driver => _driver.FindElement(By.XPath("(//input)[1]")));
            IWebElement element = driver.FindElement(By.XPath("(//input)[1]"));
            Assert.AreEqual(element.GetAttribute("type"), "password");
            driver.FindElement(By.XPath("(//input)[1]")).Clear();
            driver.FindElement(By.XPath("(//input)[1]")).SendKeys("PerfectPass");
            wait.Until((x) => {
                return !passwordTooShort.Equals(driver.FindElement(By.XPath("(//label[@class='control-label'])[1]")).Text);
            });

            Assert.AreEqual(passwordWithProperLength, driver.FindElement(By.XPath("(//label[@class='control-label'])[1]")).Text);
        }

        [Test]
        public void ChangingPasswordToGoodThenToShort()
        {
            driver.Navigate().GoToUrl(baseURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.LinkText("Password")));
            driver.FindElement(By.LinkText("Password")).Click();
            wait.Until(_driver => _driver.FindElement(By.XPath("(//input)[1]")));
            IWebElement element = driver.FindElement(By.XPath("(//input)[1]"));
            Assert.AreEqual(element.GetAttribute("type"), "password");
            driver.FindElement(By.XPath("(//input)[1]")).Clear();
            driver.FindElement(By.XPath("(//input)[1]")).SendKeys("PerfectPass");
            wait.Until((x) => {
                return !passwordTooShort.Equals(driver.FindElement(By.XPath("(//label[@class='control-label'])[1]")).Text);
            });
            driver.FindElement(By.XPath("(//input)[1]")).Clear();
            driver.FindElement(By.XPath("(//input)[1]")).SendKeys("Bad");
            wait.Until((x) => {
                return !passwordWithProperLength.Equals(driver.FindElement(By.XPath("(//label[@class='control-label'])[1]")).Text);
            });
            Assert.AreEqual(passwordTooShort, driver.FindElement(By.XPath("(//label[@class='control-label'])[1]")).Text);
        }
    }
}
