using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionArray;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.SectionArray
{
    [TestFixture(Config.Browser.Chrome)]
    [TestFixture(Config.Browser.Edge)]
    [TestFixture(Config.Browser.Firefox)]
    class RadiolistPageTest : BaseTest
    {
        private RadiolistPage _radiolistPage;
        private MainPage _mainPage;

        public RadiolistPageTest(Config.Browser browser) : base(browser)
        {
        }

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
