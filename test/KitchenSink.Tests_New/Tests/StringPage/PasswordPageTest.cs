using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.StringPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.StringPage
{
    [TestFixture]
    class PasswordPageTest : BaseTest
    {
        private PasswordPage _passwordPage;

        [SetUp]
        public void SetUp()
        {
            var mainPage = new MainPage(Driver);
            _passwordPage = mainPage.GoToPasswordPage();
        }


        [Test]
        public void PasswordPage_PasswordTooShort()
        {
            const string orygnalLabel = "Password must be at least 6 chars long";
            const string password = "123";

            WaitUntil(x => _passwordPage.PasswordInput.Displayed);
            _passwordPage.ClearPassword();
            _passwordPage.FillPassword(password);
            Assert.AreEqual(orygnalLabel, _passwordPage.PaswordInputInfoLabel.Text);
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
