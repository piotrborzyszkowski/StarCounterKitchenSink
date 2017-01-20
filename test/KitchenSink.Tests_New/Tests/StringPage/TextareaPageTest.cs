using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class TextareaPageTest : BaseTest
    {
        private TextareaPage _textareaPage;

        [OneTimeSetUp]
        public void SetUp()
        {
            var mainPage = new MainPage(Driver);
            _textareaPage = mainPage.GoToTextareaPage();
        }

        [Test]
        public void TextareaPage_WriteToTextArea()
        {
            const string newText = "We all love princess cake!";

            WaitUntil(x => _textareaPage.Textarea.Displayed);
            _textareaPage.ClearTextarea();
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
            Assert.AreEqual("Length of your bio: 0 chars", _textareaPage.TextareaInfoLabel.Text);
        }
    }
}
