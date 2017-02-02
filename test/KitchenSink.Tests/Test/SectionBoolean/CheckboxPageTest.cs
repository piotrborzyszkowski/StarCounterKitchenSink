using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionBoolean;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionBoolean
{
    [TestFixture(Config.Browser.Chrome, "Krystian", "Running Test on Chrome")]
    [TestFixture(Config.Browser.Edge,"Krystian","Running Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Krystian", "Running Test on Firefox")]
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
                Assert.AreEqual("You can drive", _checkboxPage.InfoLabel.Text);
                _checkboxPage.ChangeCheckboxState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_checkboxPage.Checkbox, false));
                Assert.AreEqual("You can't drive", _checkboxPage.InfoLabel.Text);
            }
            else
            {
                Assert.AreEqual("You can't drive", _checkboxPage.InfoLabel.Text);
                _checkboxPage.ChangeCheckboxState();
                WaitUntil(ExpectedConditions.ElementSelectionStateToBe(_checkboxPage.Checkbox, true));
                Assert.AreEqual("You can drive", _checkboxPage.InfoLabel.Text);
            }
        }
    }
}
