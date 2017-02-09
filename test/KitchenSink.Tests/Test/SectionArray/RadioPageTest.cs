using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionArray;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionArray
{
    [TestFixture(Config.Browser.Chrome, "Running Radio Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Running Radio Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Running Radio Page Test on Firefox")]
    class RadioPageTest : BaseTest
    {
        private RadioPage _radioPage;
        private MainPage _mainPage;

        public RadioPageTest(Config.Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _radioPage = _mainPage.GoToRadioPage();
        }

        [Test]
        public void ButtonPage_RegularButton()
        {
            WaitUntil(x => _radioPage.InfoLabel.Displayed);
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_radioPage.InfoLabel, "You like dogs")));

            _radioPage.SelectRadio("cats");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_radioPage.InfoLabel, "You like cats")));

            _radioPage.SelectRadio("rabbit");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_radioPage.InfoLabel, "You like rabbit")));

            _radioPage.SelectRadio("dogs");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_radioPage.InfoLabel, "You like dogs")));
        }
    }
}
