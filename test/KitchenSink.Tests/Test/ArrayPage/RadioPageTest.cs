using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.ArrayPage;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.ArrayPage
{ 
    [TestFixture]
    class RadioPageTest : BaseTest
    {
        private RadioPage _radioPage;
        private MainPage _mainPage;

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
            Assert.AreEqual("You like dogs", _radioPage.InfoLabel.Text);

            _radioPage.SelectRadio("cats");
            Assert.AreEqual("You like cats", _radioPage.InfoLabel.Text);

            _radioPage.SelectRadio("rabbit");
            Assert.AreEqual("You like rabbit", _radioPage.InfoLabel.Text);

            _radioPage.SelectRadio("dogs");
            Assert.AreEqual("You like dogs", _radioPage.InfoLabel.Text);
        }
    }
}
