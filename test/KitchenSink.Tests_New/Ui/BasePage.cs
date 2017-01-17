using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace KitchenSink.Test
{
    public class BasePage
    {
        public IWebDriver Driver;

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Datepicker']")]
        public IWebElement DatepickerPageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Dropdown']")]
        public IWebElement DropdownPageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Nested partials']")]
        public IWebElement NestedPartialsPageLink { get; set; }
    
        [FindsBy(How = How.XPath, Using = "//a[text() = 'Table']")]
        public IWebElement TablePageLink { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public IWebElement WaitForElementToBeClickable(IWebElement elementName, int seconds)
        {
            var wait = new WebDriverWait(new SystemClock(), Driver, TimeSpan.FromSeconds(seconds), TimeSpan.FromMilliseconds(50));
            IWebElement element = null;
            try
            {
                element = wait.Until(ExpectedConditions.ElementToBeClickable(elementName));
            }
            catch (WebDriverTimeoutException)
            {
            }
            return element;
        }

        public void ClickOn(IWebElement elementName, int seconds = 5)
        {
            IWebElement element = WaitForElementToBeClickable(elementName, seconds);
            if (element != null && element.Displayed && element.Enabled)
            {
                ICapabilities capabilities = ((RemoteWebDriver)Driver).Capabilities;
                if (capabilities.BrowserName == "Chrome")
                {
                    element.Click();
                }
                else
                {
                    new Actions(Driver).Click(element).Build().Perform();
                }
            }
        }
    }
}
