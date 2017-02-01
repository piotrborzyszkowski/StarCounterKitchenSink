using System;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test
{
    public class BaseTest
    {
        public IWebDriver Driver;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            Driver = WebDriverManager.StartDriver(Config.Browser.Chrome, Config.Timeout, Config.RemoteWebDriverUri);
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
           Driver.Quit();
        }

        protected TResult WaitUntil<TResult>(Func<IWebDriver, TResult> condition)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            return wait.Until(condition);
        }
    }
}