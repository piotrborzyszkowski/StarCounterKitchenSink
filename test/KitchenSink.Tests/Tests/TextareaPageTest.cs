using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using KitchenSink.Tests;
using System.Threading;

namespace KitchenSink.Test
{
    [TestFixture("firefox")]
    //[TestFixture("chrome")]
    //[TestFixture("edge")]
    //[TestFixture("internet explorer")]
    public class TextareaPageTest : BaseTest
    {
        public TextareaPageTest(string browser) : base(browser) { }

        [Test]
        public void TextareaPage_PageLoads()
        {
            driver.Navigate().GoToUrl(baseURL + "/Textarea");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("textarea.form-control")));
        }

        [Test]
        public void TextareaPage_WriteToTextArea()
        {
            driver.Navigate().GoToUrl(baseURL + "/Textarea");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("textarea.form-control")));

            driver.FindElement(By.CssSelector("textarea.form-control")).Clear();

            string setKeys = "Starcounter\r\nis\r\nawesome!";
            driver.FindElement(By.CssSelector("textarea.form-control")).SendKeys(setKeys);

            Assert.AreEqual(setKeys, driver.FindElement(By.CssSelector("textarea.form-control")).GetAttribute("value"));
        }

        [Test]
        public void TextareaPage_CounterPropagationWhileTyping()
        {
            driver.Navigate().GoToUrl(baseURL + "/Textarea");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("div.kitchensink-layout__column-right > starcounter-include > textarea[rows='3']")));

            var label = driver.FindElement(By.XPath("(//label[@class='control-label'])[1]"));
            var originalText = label.Text;

            driver.FindElement(By.XPath("(//textarea)[1]")).Clear();
            driver.FindElement(By.XPath("(//textarea)[1]")).SendKeys("U");
            wait.Until(x => !label.Text.Equals(originalText));

            string actualString = driver.FindElement(By.XPath("(//label[@class='control-label'])[1]")).Text;
            Assert.AreEqual("Length of your bio: 1 chars", actualString);
        }

    }
}
