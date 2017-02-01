﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests.Ui.StringPage
{
    public class DatepickerPage : BasePage
    {
        public DatepickerPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-pikaday__input")]
        public IWebElement DatePicker { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'pika-lendar']//table//tbody//td[@class = 'is-selected']//button[@class = 'pika-button pika-day']")]
        public IWebElement SelectedDay { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-year__input")]
        public IWebElement YearInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-month__input")]
        public IWebElement MonthInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-day__input")]
        public IWebElement DayInput { get; set; }

        public void SelectDate(string date)
        {
            DatePicker.Clear();
            DatePicker.SendKeys(date);
            DatePicker.SendKeys(Keys.Enter);
            ClickOn(SelectedDay);
        }
    }
}