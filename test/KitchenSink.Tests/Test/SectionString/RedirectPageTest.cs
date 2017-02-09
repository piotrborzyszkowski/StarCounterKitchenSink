﻿using System;
using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionString;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionString
{
    [TestFixture(Config.Browser.Chrome, "Running Redirect Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Running Redirect Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Running Redirect Page Test on Firefox")]
    class RedirectPageTest : BaseTest
    {
        private RedirectPage _redirectPage;
        private MainPage _mainPage;

        public RedirectPageTest(Config.Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _redirectPage = _mainPage.GoToRedirectPage();
        }

        [Test]
        public void RedirectPage_ClickingOnFruitShouldChangeUrlAndText()
        {
            _redirectPage.ClickButton(Config.Buttons.Fruit);
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_redirectPage.InfoLabel, "You\'ve got some tasty apple")));
            Assert.AreEqual(Config.KitchenSinkUrl + "/Redirect/apple", Driver.Url);
            
            _redirectPage.ClickButton(Config.Buttons.Vegetable);
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_redirectPage.InfoLabel, "You\'ve got some tasty carrot")));
            Assert.AreEqual(Config.KitchenSinkUrl + "/Redirect/carrot", Driver.Url);

            _redirectPage.ClickButton(Config.Buttons.Bread);
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_redirectPage.InfoLabel, "You\'ve got some tasty baguette")));
            Assert.AreEqual(Config.KitchenSinkUrl + "/Redirect/baguette", Driver.Url);
        }

        [Test]
        public void RedirectPage_ClickingOnRedirectToAnotherPartialShouldChangeUrl()
        {
            _redirectPage.ClickButton(Config.Buttons.Morph);
            WaitUntil(x => Driver.Url == Config.KitchenSinkUrl.ToString());
            Assert.AreEqual(Config.KitchenSinkUrl, Driver.Url);
        }

        [Test]
        public void RedirectPage_ClickingOnRedirectToExternalWebsiteShouldChangeUrl()
        {
            _redirectPage.ClickButton(Config.Buttons.Redirect);
            WaitUntil(x => Driver.Url == "https://starcounter.io/");
            Assert.AreEqual("https://starcounter.io/", Driver.Url);
        }
    }
}
