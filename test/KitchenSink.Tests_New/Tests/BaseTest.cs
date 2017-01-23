using System;
using KitchenSink.Tests_New.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests_New.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            Driver = WebDriverManager.StartDriver(Config.Browser.Chrome, Config.Url, Config.Timeout, Config.RemoteWebDriverUri, Config.ImplicitlyTimeout);
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            WebDriverManager.StopDriver();
        }

        protected TResult WaitUntil<TResult>(Func<IWebDriver, TResult> condition)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            return wait.Until(condition);
        }
    }
}