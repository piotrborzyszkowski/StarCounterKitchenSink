using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests_New.Ui
{
    public class BasePage
    {
        public IWebDriver Driver;

        [FindsBy(How = How.XPath, Using = "//a[text() = 'MainPage']")]
        public IWebElement MainPageLink { get; set; }

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

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Text']")]
        public IWebElement TextPageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Textarea']")]
        public IWebElement TextareaPageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Redirect']")]
        public IWebElement RedirectPageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Password']")]
        public IWebElement PasswordPageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Pagination']")]
        public IWebElement PaginationPageLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Autocomplete']")]
        public IWebElement AutoCompletePageLink { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public IWebElement WaitForElementToBeClickable(IWebElement elementName, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
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
                element.Click();
            }
        }
    }
}
