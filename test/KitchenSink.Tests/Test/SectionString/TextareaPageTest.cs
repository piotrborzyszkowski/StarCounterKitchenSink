using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionString;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.SectionString
{
    [TestFixture(Config.Browser.Chrome, "Running Textarea Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Running Textarea Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Running Textarea Page Test on Firefox")]
    class TextareaPageTest : BaseTest
    {
        private TextareaPage _textareaPage;
        private MainPage _mainPage;

        public TextareaPageTest(Config.Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _textareaPage = _mainPage.GoToTextareaPage();
        }

        [Test]
        public void TextareaPage_WriteToTextArea()
        {
            const string newText = "We all love princess cake!";

            WaitUntil(x => _textareaPage.Textarea.Displayed);
            _textareaPage.ClearTextarea();
            WaitUntil(x => _textareaPage.Textarea.GetAttribute("text-value") != string.Empty);
            _textareaPage.FillTextarea(newText);
            Assert.AreEqual("Length of your bio: 26 chars", _textareaPage.TextareaInfoLabel.Text);
        }

        [Test]
        public void TextareaPage_CounterPropagationWhileTyping()
        {
            const string newText = "Love";

            WaitUntil(x => _textareaPage.Textarea.Displayed);
            _textareaPage.ClearTextarea();
            _textareaPage.FillTextarea(newText);
            Assert.AreEqual("Length of your bio: 4 chars", _textareaPage.TextareaInfoLabel.Text);
            _textareaPage.ClearTextarea();
            WaitUntil(x => _textareaPage.Textarea.GetAttribute("text-value") != string.Empty);
            Assert.AreEqual("Length of your bio: 0 chars", _textareaPage.TextareaInfoLabel.Text);
        }
    }
}
