﻿using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionBoolean;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionBoolean
{
    [TestFixture(Config.Browser.Chrome, "Krystian Matti", "Running Toggle Button Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Krystian Matti", "Running Toggle Button Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Krystian Matti", "Running Toggle Button Page Test on Firefox")]
    class ToggleButtonPageTest : BaseTest
    {
        private ToggleButtonPage _toggleButtonPage;
        private MainPage _mainPage;

        public ToggleButtonPageTest(Config.Browser browser, string author, string description) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _toggleButtonPage = _mainPage.GoToToggleButtonPage();
        }

        [Test]
        public void ToggleButtonPage_CheckboxUncheckedAndCheckedAgain()
        {
            WaitUntil(x => _toggleButtonPage.ToogleButton.Displayed);
            WaitUntil(x => _toggleButtonPage.InfoLabel.Displayed);

            if (_toggleButtonPage.ToogleButton.Selected)
            {
                Assert.AreEqual("I accept terms and conditions", _toggleButtonPage.InfoLabel.Text);
                _toggleButtonPage.ChangeToggleButtonState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_toggleButtonPage.ToogleButton, true));
                Assert.AreEqual("I don't accept terms and conditions", _toggleButtonPage.InfoLabel.Text);
            }

            if (!_toggleButtonPage.ToogleButton.Selected)
            {
                Assert.AreEqual("I accept terms and conditions", _toggleButtonPage.InfoLabel.Text);
                _toggleButtonPage.ChangeToggleButtonState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_toggleButtonPage.ToogleButton, false));
                Assert.AreEqual("I don't accept terms and conditions", _toggleButtonPage.InfoLabel.Text);
            }
        }
    }
}
