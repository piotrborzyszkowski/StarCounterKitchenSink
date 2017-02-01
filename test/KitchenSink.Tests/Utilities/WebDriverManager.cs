using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace KitchenSink.Tests.Utilities
{
    public class WebDriverManager
    {
        private static IWebDriver _driver;

        public static IWebDriver StartDriver(Config.Browser browser, double timeout, Uri remoteWebDriverUri, double implicitlyTimeout)
        {
            switch (browser)
            {
                case Config.Browser.Chrome:
                    {
                        _driver = new RemoteWebDriver(remoteWebDriverUri, DesiredCapabilities.Chrome());
                        break;
                    }
                case Config.Browser.Edge:
                    {
                        _driver = new RemoteWebDriver(remoteWebDriverUri, DesiredCapabilities.Edge());
                        break;
                    }
                case Config.Browser.Firefox:
                    {
                        _driver = new RemoteWebDriver(remoteWebDriverUri, DesiredCapabilities.Firefox());
                        break;
                    }
            }

            IWebDriver eventDriver = new EventListener(_driver);
            _driver = eventDriver;
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(timeout));
            _driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(timeout));
            return _driver;
        }

        public static void StopDriver()
        {
            _driver.Quit();
        }
    }
}