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

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Validation']")]
        public IWebElement ValidationPageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Button']")]
        public IWebElement ButtonPageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Checkbox']")]
        public IWebElement CheckboxPageLink { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public IWebElement WaitForElementToBeClickable(IWebElement elementName, int seconds)
        {
            //var wait = new WebDriverWait(new SystemClock(), Driver, TimeSpan.FromSeconds(seconds), TimeSpan.FromMilliseconds(50));
            IWebElement element = null;
            try
            {
                element = WaitUntil(ExpectedConditions.ElementToBeClickable(elementName));
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
                element.Click();
            }
        }

        protected TResult WaitUntil<TResult>(Func<IWebDriver, TResult> condition)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            return wait.Until(condition);
        }
    }
}
