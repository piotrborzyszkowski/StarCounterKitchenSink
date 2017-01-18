using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class ValidationPageTest : BaseTest
    {
        [Test]
        public void ValidationPage_InvalidRequireInput()
        {
            MainPage mainPage = new MainPage(Driver);
            ValidationPage validationPage = mainPage.GoToValidationPage();

            validationPage.Validate();

            Assert.AreEqual("'Name' should not be empty.", validationPage.GetNameError());
            Assert.AreEqual("'Last Name' should not be empty.", validationPage.GetLastNameError());
        }

        [Test]
        public void ValidationPage_ValidRequireInput()
        {
            MainPage mainPage = new MainPage(Driver);
            ValidationPage validationPage = mainPage.GoToValidationPage();

            validationPage.InsertName("TestName");
            validationPage.InsertLastName("TestLastName");
            validationPage.Validate();

            Assert.AreEqual(string.Empty, validationPage.GetNameError());
            Assert.AreEqual(string.Empty, validationPage.GetLastNameError());
        }
    }
}
