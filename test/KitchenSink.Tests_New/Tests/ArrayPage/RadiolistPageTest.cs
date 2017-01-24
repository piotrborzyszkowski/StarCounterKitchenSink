using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.ArrayPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.ArrayPage
{
    [TestFixture]
    class RadiolistPageTest : BaseTest
    {
        private RadiolistPage _radiolistPage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _radiolistPage = _mainPage.GoToRadiolistPage();
        }

        [Test]
        public void ButtonPage_RegularButton()
        {
            WaitUntil(x => _radiolistPage.InfoLabel.Displayed);
            Assert.AreEqual("Dogs", _radiolistPage.InfoLabel.Text);

            _radiolistPage.SelectRadio("Cats");
            Assert.AreEqual("Cats", _radiolistPage.InfoLabel.Text);

            _radiolistPage.SelectRadio("Dogs");
            Assert.AreEqual("Dogs", _radiolistPage.InfoLabel.Text);
        }
    }
}
