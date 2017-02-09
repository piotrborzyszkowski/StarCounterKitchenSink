using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionBoolean;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionBoolean
{
    [TestFixture(Config.Browser.Chrome)]
    [TestFixture(Config.Browser.Edge)]
    [TestFixture(Config.Browser.Firefox)]
    class CheckboxPageTest : BaseTest
    {
        private CheckboxPage _checkboxPage;
        private MainPage _mainPage;

        public CheckboxPageTest(Config.Browser browser) : base(browser)
        {
        }

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
                Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_checkboxPage.InfoLabel, "You can drive")));
                _checkboxPage.ToggleCheckbox();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_checkboxPage.Checkbox, false));
                Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_checkboxPage.InfoLabel, "You can't drive")));
            }
            else
            {
                Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_checkboxPage.InfoLabel, "You can't drive")));
                _checkboxPage.ToggleCheckbox();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_checkboxPage.Checkbox, true));
                Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_checkboxPage.InfoLabel, "You can drive")));
            }
        }
    }
}
