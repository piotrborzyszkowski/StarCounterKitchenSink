using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.BooleanPage;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Tests.BooleanPage
{
    [TestFixture]
    class CheckboxPageTest : BaseTest
    {
        private CheckboxPage _checkboxPage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _checkboxPage = _mainPage.GoToCheckboxPage();
        }

        [Test]
        public void CheckboxPage_CheckboxUncheckedAndCheckedAgain()
        {
            WaitUntil(x => _checkboxPage.Checkbox.Displayed);
            WaitUntil(x => _checkboxPage.InfoLabel.Displayed);

            if (_checkboxPage.Checkbox.Selected)
            {
                Assert.AreEqual("You can drive", _checkboxPage.InfoLabel.Text);
                _checkboxPage.ChangeCheckboxState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_checkboxPage.Checkbox, false));
                Assert.AreEqual("You can't drive", _checkboxPage.InfoLabel.Text);
            }

            if (!_checkboxPage.Checkbox.Selected)
            {
                Assert.AreEqual("You can't drive", _checkboxPage.InfoLabel.Text);
                _checkboxPage.ChangeCheckboxState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_checkboxPage.Checkbox, true));
                Assert.AreEqual("You can drive", _checkboxPage.InfoLabel.Text);
            }
        }
    }
}
