using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using KitchenSink.Test;

namespace KitchenSink.Tests
{
    public class BaseTest
    {
        public BaseTest(string browser)
        {
            this.browser = browser;
        }

        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        protected string browser;

        [SetUp]
        public void SetupTest()
        {
            baseURL = "http://localhost:8080/KitchenSink";
            verificationErrors = new StringBuilder();

            if (this.browser == "edge" && Environment.OSVersion.ToString() != "Microsoft Windows NT 10.0.10586.0")
            {
                Assert.Ignore("You're not using Windows 10, so Microsoft Edge is unavailable. The test is being omitted.");
            }
            driver = WebDriverFactory.Create(this.browser);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
