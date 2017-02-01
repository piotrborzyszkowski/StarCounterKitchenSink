using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.StringPage;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.StringPage
{
    [TestFixture]
    class PasswordPageTest : BaseTest
    {
        private PasswordPage _passwordPage;
        private MainPage _mainPage;

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
