using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.StringPage;
using NUnit.Framework;
using OpenQA.Selenium;

namespace KitchenSink.Tests_New.Tests.StringPage
{
    [TestFixture]
    class ValidationPageTest : BaseTest
    {
        private ValidationPage _validationPage;

        [SetUp]
        public void SetUp()
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

            WaitUntil(x => _validationPage.LastNameInput.Displayed);
            _validationPage.InsertLastName("TestLastName");

            WaitUntil(x => _validationPage.NameInput.GetAttribute("test-value") != string.Empty && _validationPage.LastNameInput.GetAttribute("test-value") != string.Empty);
            _validationPage.Validate();

            Assert.AreEqual(string.Empty, _validationPage.NameErrorLabel.Text);
            Assert.AreEqual(string.Empty, _validationPage.LastNameErrorLabel.Text);
        }
    }
}
