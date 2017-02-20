using System;
using System.Collections.Generic;
using System.Linq;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test
{
    public class BaseTest
    {
        public IWebDriver Driver;
        private readonly Config.Browser _browser;
        private readonly List<string> _browsers = TestContext.Parameters["Browsers"].Split(',').ToList();

        //DEBUG ONLY
        //private readonly List<string> _browsers = "Chrome;Firefox".Split(';').ToList();

        public BaseTest(Config.Browser browser)
        {
            _browser = browser;
        }

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            if (_browsers.Contains(Config.BrowserDictionary[_browser]))
                Driver = WebDriverManager.StartDriver(_browser, Config.Timeout, Config.RemoteWebDriverUri);
            else
            {
                Assert.Ignore();
            }
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            Driver?.Quit();
        }

        protected TResult WaitUntil<TResult>(Func<IWebDriver, TResult> condition)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            return wait.Until(condition);
        }

        public bool WaitForText(IWebElement elementName, string text, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.TextToBePresentInElement(elementName, text));
        }
    }
}