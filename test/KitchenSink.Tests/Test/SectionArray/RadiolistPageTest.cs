﻿using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionArray;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionArray
{
    [TestFixture(Config.Browser.Chrome, "Krystian", "Running Radiolist Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Krystian", "Running Radiolist Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Krystian", "Running Radiolist Page Test on Firefox")]
    class RadiolistPageTest : BaseTest
    {
        private RadiolistPage _radiolistPage;
        private MainPage _mainPage;

        public RadiolistPageTest(Config.Browser browser, string author, string description) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _radiolistPage = _mainPage.GoToRadiolistPage();
        }

        [Test]
        public void ButtonPage_RegularButton()
        {
            WaitUntil(x => _radiolistPage.InfoLabel.Displayed);
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_radiolistPage.InfoLabel, "Dogs")));

            _radiolistPage.SelectRadio("Cats");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_radiolistPage.InfoLabel, "Cats")));

            _radiolistPage.SelectRadio("Dogs");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_radiolistPage.InfoLabel, "Dogs")));
        }
    }
}
