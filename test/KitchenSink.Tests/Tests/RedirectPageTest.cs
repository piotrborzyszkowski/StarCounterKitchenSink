using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Tests
{
    [TestFixture("firefox")]
    [TestFixture("chrome")]
    [TestFixture("edge")]
    public class RedirectPageTest : BaseTest
    {
        public RedirectPageTest(string browser) : base(browser)
        {
        }

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl(baseURL + "/Redirect");
        }

        [Test]
        public void ClickingOnFruitShouldChangeUrlAndText()
        {
            ClickButton("Fruit");

            // on edge juicy sometimes messes up the dom tree, so you can't be sure about its relative position to button
            Assert.That(driver.Url, Is.EqualTo($"{baseURL}/Redirect/apple"));
        }

        [Test]
        public void ClickingOnRedirectToAnotherPartialShouldChangeUrl()
        {
            ClickButton("Morph to another partial");
        }

        [Test]
        public void ClickingOnRedirectToExternalWebsiteShouldChangeUrl()
        {
            ClickButton("Redirect to Starcounter.io");
        }

        private void ClickButton(string text)
        {
            driver.FindElement(ByHelper.AnyButtonWithText(text)).ClickUsingMouse(driver);
        }
    }
}