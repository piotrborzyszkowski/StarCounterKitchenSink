using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class PasswordPageTest : BaseTest
    {
        private PasswordPage _passwordPage;

        [OneTimeSetUp]
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

            _passwordPage.ClearPassword();
            _passwordPage.FillPassword(password);
            Assert.AreEqual(orygnalLabel, _passwordPage.GetPasswordInfoLabel());
        }

        [Test]
        public void PasswordPage_PasswordWithProperLength()
        {
            const string password = "123456";

            _passwordPage.ClearPassword();
            _passwordPage.FillPassword(password);
            Assert.AreEqual("Good password!", _passwordPage.GetPasswordInfoLabel());
        }

        [Test]
        public void PasswordPage_ChangingPasswordToGoodThenToShort()
        {
            const string password = "123456";

            _passwordPage.ClearPassword();
            _passwordPage.FillPassword(password);
            Assert.AreEqual("Good password!", _passwordPage.GetPasswordInfoLabel());
            _passwordPage.ClearPassword();
            _passwordPage.FillPassword("123");
            Assert.AreEqual("Password must be at least 6 chars long", _passwordPage.GetPasswordInfoLabel());
        }
    }
}
