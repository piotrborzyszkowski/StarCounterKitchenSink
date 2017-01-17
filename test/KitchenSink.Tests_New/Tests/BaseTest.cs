using NUnit.Framework;
using OpenQA.Selenium;

namespace KitchenSink.Test
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
    }
}