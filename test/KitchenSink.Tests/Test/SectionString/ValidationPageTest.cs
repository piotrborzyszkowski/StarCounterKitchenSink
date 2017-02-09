using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionString;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.SectionString
{
    [TestFixture(Config.Browser.Chrome, "Running Validation Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Running Validation Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Running Validation Page Test on Firefox")]
    class ValidationPageTest : BaseTest
    {
        private ValidationPage _validationPage;
        private MainPage _mainPage;

        public ValidationPageTest(Config.Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _validationPage = _mainPage.GoToValidationPage();
        }

        [Test]
        public void ValidationPage_InvalidRequireInput()
        {
            WaitUntil(x => _validationPage.ValidateButton.Displayed);
            _validationPage.Validate();

            WaitUntil(x => _validationPage.NameErrorLabel.GetAttribute("test-value") != string.Empty && _validationPage.LastNameErrorLabel.GetAttribute("test-value") != string.Empty);

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
