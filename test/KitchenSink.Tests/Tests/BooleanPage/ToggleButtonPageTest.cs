using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.BooleanPage;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Tests.BooleanPage
{
    [TestFixture]
    class ToggleButtonPageTest : BaseTest
    {
        private ToggleButtonPage _toggleButtonPage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _toggleButtonPage = _mainPage.GoToToggleButtonPage();
        }

        [Test]
        public void ToggleButtonPage_CheckboxUncheckedAndCheckedAgain()
        {
            WaitUntil(x => _toggleButtonPage.ToogleButton.Displayed);
            WaitUntil(x => _toggleButtonPage.InfoLabel.Displayed);

            if (_toggleButtonPage.ToogleButton.Selected)
            {
                Assert.AreEqual("I accept terms and conditions", _toggleButtonPage.InfoLabel.Text);
                _toggleButtonPage.ChangeToggleButtonState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_toggleButtonPage.ToogleButton, true));
                Assert.AreEqual("I don't accept terms and conditions", _toggleButtonPage.InfoLabel.Text);
            }

            if (!_toggleButtonPage.ToogleButton.Selected)
            {
                Assert.AreEqual("I accept terms and conditions", _toggleButtonPage.InfoLabel.Text);
                _toggleButtonPage.ChangeToggleButtonState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_toggleButtonPage.ToogleButton, false));
                Assert.AreEqual("I don't accept terms and conditions", _toggleButtonPage.InfoLabel.Text);
            }
        }
    }
}
