﻿using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionString;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.SectionString
{
    [TestFixture(Config.Browser.Chrome, "Krystian Matti", "Running Password Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Krystian Matti", "Running Password Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Krystian Matti", "Running Password Page Test on Firefox")]
    class PasswordPageTest : BaseTest
    {
        private PasswordPage _passwordPage;
        private MainPage _mainPage;

        public PasswordPageTest(Config.Browser browser, string author, string description) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _passwordPage = _mainPage.GoToPasswordPage();
        }

        [Test]
        public void PasswordPage_PasswordTooShort()
        {
            const string originalLabel = "Password must be at least 6 chars long";
            const string password = "123";

            WaitUntil(x => _passwordPage.PasswordInput.Displayed);
            _passwordPage.ClearPassword();
            _passwordPage.FillPassword(password);
            Assert.AreEqual(originalLabel, _passwordPage.PaswordInputInfoLabel.Text);
        }

        [Test]
        public void PasswordPage_PasswordWithProperLength()
        {
            const string password = "123456";

            WaitUntil(x => _passwordPage.PasswordInput.Displayed);
            _passwordPage.ClearPassword();
            _passwordPage.FillPassword(password);
            Assert.AreEqual("Good password!", _passwordPage.PaswordInputInfoLabel.Text);
        }

        [Test]
        public void PasswordPage_ChangingPasswordToGoodThenToShort()
        {
            const string password = "123456";

            WaitUntil(x => _passwordPage.PasswordInput.Displayed);
            _passwordPage.ClearPassword();
            _passwordPage.FillPassword(password);
            Assert.AreEqual("Good password!", _passwordPage.PaswordInputInfoLabel.Text);
            _passwordPage.ClearPassword();
            _passwordPage.FillPassword("123");
            Assert.AreEqual("Password must be at least 6 chars long", _passwordPage.PaswordInputInfoLabel.Text);
        }
    }
}
