using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class ValidationPageTest : BaseTest
    {
        private ValidationPage _validationPage;

        [SetUp]
        public void OneTimeSetUp()
        {
            var mainPage = new MainPage(Driver);
            _validationPage = mainPage.GoToValidationPage();
        }

        [Test]
        public void ValidationPage_InvalidRequireInput()
        {
            WaitUntil(x => _validationPage.ValidateButton.Displayed);
            _validationPage.Validate();

            Assert.AreEqual("'Name' should not be empty.", _validationPage.NameErrorLabel.GetAttribute("test-value"));
            Assert.AreEqual("'Last Name' should not be empty.", _validationPage.LastNameErrorLabel.GetAttribute("test-value"));
        }

        [Test]
        public void ValidationPage_ValidRequireInput()
        {
            WaitUntil(x => _validationPage.NameInput.Displayed);
            _validationPage.InsertName("TestName");
            WaitUntil(x => _validationPage.NameInput.Text != string.Empty);
            WaitUntil(x => _validationPage.LastNameInput.Displayed);
            _validationPage.InsertLastName("TestLastName");
            WaitUntil(x => _validationPage.LastNameInput.Text != string.Empty);
            _validationPage.Validate();

            Assert.AreEqual(string.Empty, _validationPage.NameErrorLabel.Text);
            Assert.AreEqual(string.Empty, _validationPage.LastNameErrorLabel.Text);
        }
    }
}
