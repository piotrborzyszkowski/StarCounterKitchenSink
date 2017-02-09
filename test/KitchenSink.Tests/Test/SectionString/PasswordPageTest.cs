using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionString;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionString
{
    [TestFixture(Config.Browser.Chrome, "Running Password Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Running Password Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Running Password Page Test on Firefox")]
    class PasswordPageTest : BaseTest
    {
        private PasswordPage _passwordPage;
        private MainPage _mainPage;

        public PasswordPageTest(Config.Browser browser) : base(browser)
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
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_passwordPage.PaswordInputInfoLabel, originalLabel)));
        }

        [Test]
        public void PasswordPage_PasswordWithProperLength()
        {
            const string password = "123456";

            WaitUntil(x => _passwordPage.PasswordInput.Displayed);
            _passwordPage.ClearPassword();
            _passwordPage.FillPassword(password);
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_passwordPage.PaswordInputInfoLabel, "Good password!")));
        }

        [Test]
        public void PasswordPage_ChangingPasswordToGoodThenToShort()
        {
            const string password = "123456";

            WaitUntil(x => _passwordPage.PasswordInput.Displayed);
            _passwordPage.ClearPassword();
            _passwordPage.FillPassword(password);
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_passwordPage.PaswordInputInfoLabel, "Good password!")));
            _passwordPage.ClearPassword();
            _passwordPage.FillPassword("123");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_passwordPage.PaswordInputInfoLabel, "Password must be at least 6 chars long")));
        }
    }
}
