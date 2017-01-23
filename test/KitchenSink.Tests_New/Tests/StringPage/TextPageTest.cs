using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.StringPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.StringPage
{
    [TestFixture]
    internal class TextPageTest : BaseTest
    {
        private TextPage _textPage;

        [SetUp]
        public void SetUp()
        {
            var mainPage = new MainPage(Driver);
            _textPage = mainPage.GoToTextPage();
        }

        [Test]
        public void TextPage_TextPropagationOnUnfocus()
        {
            const string oryginalText = "What\'s your name?";
            const string newText = "Krystian";

            _textPage.FillInput(newText);
            WaitUntil(x => _textPage.InputInfoLabel1.Text != oryginalText);
            Assert.AreEqual("Hi, Krystian!", _textPage.InputInfoLabel1.Text);
            _textPage.ClearInput();
            Assert.AreEqual(oryginalText, _textPage.InputInfoLabel1.Text);
        }

        [Test]
        public void TextPage_TextPropagationWhileTyping()
        {
            const string oryginalText = "What\'s your name?";
            const string newText = "K";

            _textPage.FillInputDynamic(newText);
            WaitUntil(x => _textPage.InputInfoLabel2.Text != oryginalText);
            Assert.AreEqual("Hi, K!", _textPage.InputInfoLabel2.Text);
            _textPage.ClearInputDynamic();
            WaitUntil(x => _textPage.InputInfoLabel2.Text != "Hi, K!");
            Assert.AreEqual(oryginalText, _textPage.InputInfoLabel2.Text);
        }
    }
}