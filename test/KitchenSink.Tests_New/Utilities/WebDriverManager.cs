using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace KitchenSink.Tests_New.Utilities
{
    public class WebDriverManager
    {
        private static IWebDriver driver;

        public static IWebDriver StartDriver(Config.Browser browser, Uri portalUrl, double timeout, Uri remoteWebDriverUri, double ImplicitlyTimeout)
        {
            switch (browser)
            {
                case Config.Browser.Chrome:
                    {
                        driver = new RemoteWebDriver(remoteWebDriverUri, DesiredCapabilities.Chrome());
                        break;
                    }
                case Config.Browser.Edge:
                    {
                        driver = new RemoteWebDriver(remoteWebDriverUri, DesiredCapabilities.Edge());
                        break;
                    }
                case Config.Browser.Firefox:
                    {
                        driver = new RemoteWebDriver(remoteWebDriverUri, DesiredCapabilities.Firefox());
                        break;
                    }
            }

            IWebDriver eventDriver = new EventListener(driver);
            driver = eventDriver;
            driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(portalUrl);
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(timeout));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(timeout));
            return driver;
        }

        public static void StopDriver()
        {
            driver.Quit();
        }
    }
}