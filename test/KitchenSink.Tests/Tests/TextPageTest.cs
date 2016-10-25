using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using KitchenSink.Tests;

namespace KitchenSink.Test
{
    [TestFixture("firefox")]
    [TestFixture("chrome")]
    [TestFixture("edge")]
    //[TestFixture("internet explorer")]
    public class TextPageTest : BaseTest
    {
        public TextPageTest(string browser) : base(browser)
        {
        }

        [Test]
        public void TextPage_PageLoads()
        {
            driver.Navigate().GoToUrl(baseURL + "/Text");
        }

        [Test]
        public void TextPage_TextPropagationOnUnfocus()
        {
            driver.Navigate().GoToUrl(baseURL + "/Text");
            var label = driver.FindElement(ByHelper.AnyControlLabel);
            var originalText = label.Text;
            var input = driver.FindElement(ByHelper.AnyInput);
            input.Clear();
            input.SendKeys("M");
            input.SendKeys("a");
            input.SendKeys("r");
            input.SendKeys("c");
            input.SendKeys("i");
            input.SendKeys("n");
            driver.FindElement(ByHelper.Body).ClickUsingMouse(driver);
            this.WaitUntil(x => !label.Text.Equals(originalText));
            Assert.AreEqual("Hi, Marcin!", driver.FindElement(ByHelper.AnyControlLabel).Text);
        }

        [Test]
        public void TextPage_TextPropagationWhileTyping()
        {
            driver.Navigate().GoToUrl(baseURL + "/Text");
            var label = driver.FindElement(ByHelper.NthControlLabel(1));
            var originalText = label.Text;
            driver.FindElement(ByHelper.NthInput(1)).Clear();
            driver.FindElement(ByHelper.NthInput(1)).SendKeys("M");
            this.WaitUntil(x => !label.Text.Equals(originalText));
            Assert.AreEqual("Hi, M!", driver.FindElement(ByHelper.NthControlLabel(1)).Text);
        }
    }
}