using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace KitchenSink.Test
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
            driver.Navigate().GoToUrl(portalUrl);
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ImplicitlyTimeout));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(timeout));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(timeout));
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static void StopDriver()
        {
            driver.Quit();
        }
    }
}