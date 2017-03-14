using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionCustom;
using NUnit.Framework;
using System.IO;
using KitchenSink.Tests.Utilities;

namespace KitchenSink.Tests.Test.SectionCustom
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(Config.Browser.Chrome)]
    [TestFixture(Config.Browser.Edge)] //BUG on EDGE https://developer.microsoft.com/en-us/microsoft-edge/platform/issues/7194303/
    [TestFixture(Config.Browser.Firefox)]
    class FileUploadPageTest : BaseTest
    {
        private FileUploadPage _fileUploadPage;
        private MainPage _mainPage;
        private readonly Config.Browser _browser;

        public FileUploadPageTest(Config.Browser browser) : base(browser)
        {
            _browser = browser;
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _fileUploadPage = _mainPage.GoToFileUploadPage();
        }

        [Test]
        public void FileUploadPage_UploadAFile()
        {
            if (_browser == Config.Browser.Chrome)
                WaitUntil(x => _fileUploadPage.CheckFileInputVisible());
            else
                WaitUntil(x => _fileUploadPage.FileInput.Enabled);

            string tempFilePath = Path.GetTempFileName();
            using (StreamWriter outputFile = new StreamWriter(tempFilePath, false))
            {
                outputFile.WriteLine("Test123");
            }

            if (_browser == Config.Browser.Chrome)
                _fileUploadPage.UploadAFileShadowRoot(tempFilePath);
            else
                _fileUploadPage.UploadAFile(tempFilePath);

            WaitUntil(x => _fileUploadPage.GetUploadedFilesCount() > 0);

            Assert.AreEqual("Do not forget to delete files from your temporary folder!",
                _fileUploadPage.InfoLabel.Text);
        }

        [Test]
        public void FileUploadPage_UploadAndDeleteAFile()
        {
            if (_browser == Config.Browser.Chrome)
                WaitUntil(x => _fileUploadPage.CheckFileInputVisible());
            else
                WaitUntil(x => _fileUploadPage.FileInput.Enabled);

            string tempFilePath = Path.GetTempFileName();
            using (StreamWriter outputFile = new StreamWriter(tempFilePath, false))
            {
                outputFile.WriteLine("Test123");
            }

            if (_browser == Config.Browser.Chrome)
                _fileUploadPage.UploadAFileShadowRoot(tempFilePath);
            else
                _fileUploadPage.UploadAFile(tempFilePath);

            WaitUntil(x => _fileUploadPage.GetUploadedFilesCount() > 0);

            Assert.AreEqual("Do not forget to delete files from your temporary folder!", _fileUploadPage.InfoLabel.Text);

            _fileUploadPage.DeleteAllFiles();
            WaitUntil(x => _fileUploadPage.GetUploadedFilesCount() == 0);

            Assert.IsTrue(!_fileUploadPage.InfoLabel.Displayed);
        }
    }
}
