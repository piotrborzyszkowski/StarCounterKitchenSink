using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionString;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionString
{
    [TestFixture(Config.Browser.Chrome, "Krystian Matti", "Running Text Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Krystian Matti", "Running Text Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Krystian Matti", "Running Text Page Test on Firefox")]
    internal class TextPageTest : BaseTest
    {
        private TextPage _textPage;
        private MainPage _mainPage;

        public TextPageTest(Config.Browser browser, string author, string description) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _textPage = _mainPage.GoToTextPage();
        }

        [Test]
        public void TextPage_TextPropagationOnUnfocus()
        {
            WaitUntil(x => _textPage.Input.Displayed);

            _textPage.FillInput("Krystian");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_textPage.InputInfoLabel, "Hi, Krystian!")));
            _textPage.ClearInput();
            WaitUntil(x => _textPage.Input.Text == string.Empty);
            Assert.AreEqual("What\'s your name?", _textPage.InputInfoLabel.Text);
        }

        [Test]
        public void TextPage_TextPropagationWhileTyping()
        {
            WaitUntil(x => _textPage.InputDynamic.Displayed);

            _textPage.FillInputDynamic("K");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_textPage.InputInfoLabelDynamic, "Hi, K!")));
            _textPage.ClearInputDynamic();
            WaitUntil(x => _textPage.InputDynamic.Text == string.Empty);
            Assert.AreEqual("What\'s your name?", _textPage.InputInfoLabelDynamic.Text);
        }
    }
}