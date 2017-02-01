using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.StringPage;
using NUnit.Framework;

namespace KitchenSink.Tests.Tests.StringPage
{
    [TestFixture]
    internal class TextPageTest : BaseTest
    {
        private TextPage _textPage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _textPage = _mainPage.GoToTextPage();
        }

        [Test]
        public void TextPage_TextPropagationOnUnfocus()
        {
            const string originalText = "What\'s your name?";
            const string newText = "Krystian";

            WaitUntil(x => _textPage.Input.Displayed);

            _textPage.FillInput(newText);
            WaitUntil(x => _textPage.InputInfoLabel1.Text != originalText);
            Assert.AreEqual("Hi, Krystian!", _textPage.InputInfoLabel1.Text);
            _textPage.ClearInput();
            WaitUntil(x => _textPage.Input.Text == string.Empty);
            Assert.AreEqual(originalText, _textPage.InputInfoLabel1.Text);
        }

        [Test]
        public void TextPage_TextPropagationWhileTyping()
        {
            const string originalText = "What\'s your name?";
            const string newText = "K";

            WaitUntil(x => _textPage.InputDynamic.Displayed);

            _textPage.FillInputDynamic(newText);
            WaitUntil(x => _textPage.InputInfoLabel2.Text != originalText);
            Assert.AreEqual("Hi, K!", _textPage.InputInfoLabel2.Text);
            _textPage.ClearInputDynamic();
            WaitUntil(x => _textPage.InputDynamic.Text == string.Empty);
            Assert.AreEqual(originalText, _textPage.InputInfoLabel2.Text);
        }
    }
}