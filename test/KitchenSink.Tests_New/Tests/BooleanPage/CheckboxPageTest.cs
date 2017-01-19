using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Test.Boolean
{
    [TestFixture]
    class CheckboxPageTest : BaseTest
    {
        private CheckboxPage _checkboxPage;

        [OneTimeSetUp]
        public void SetUp()
        {
            var mainPage = new MainPage(Driver);
            _checkboxPage = mainPage.GoToCheckboxPage();
        }

        [Test]
        public void CheckboxPage_CheckboxUncheckedAndCheckedAgain()
        {
            WaitUntil(x => _checkboxPage.Checkbox.Displayed);

            if (_checkboxPage.GetCheckboxState())
            {
                Assert.AreEqual("You can drive", _checkboxPage.InfoLabel.Text);
                _checkboxPage.ChangeCheckboxState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_checkboxPage.Checkbox, false));
                Assert.AreEqual("You can't drive", _checkboxPage.InfoLabel.Text);
            }

            if (!_checkboxPage.GetCheckboxState())
            {
                Assert.AreEqual("You can't drive", _checkboxPage.InfoLabel.Text);
                _checkboxPage.ChangeCheckboxState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_checkboxPage.Checkbox, true));
                Assert.AreEqual("You can drive", _checkboxPage.InfoLabel.Text);
            }
        }
    }
}
