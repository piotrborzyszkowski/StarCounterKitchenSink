using System.Linq;
using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.CustomPage;
using NUnit.Framework;

namespace KitchenSink.Tests.Tests.CustomPage
{
    [TestFixture]
    class PaginationPageTest : BaseTest
    {
        private PaginationPage _paginationPage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _paginationPage = _mainPage.GoToPaginationPage();
        }

        [Test]
        public void PaginationPage_Dropdown_HasCorrectOptions()
        {
            _paginationPage.ScrollToTheTop();

            WaitUntil(x => _paginationPage.DropDown.Displayed);
            _paginationPage.DropdownSelect("5");          
            Assert.AreEqual(5, _paginationPage.PaginationResult.Count);
            Assert.AreEqual("page 1 of 20", _paginationPage.PaginationInfoLabel.Text);
            _paginationPage.DropdownSelect("15");
            WaitUntil(x => _paginationPage.PaginationResult.Count > 5);
            Assert.AreEqual(15, _paginationPage.PaginationResult.Count);
            Assert.AreEqual("page 1 of 7", _paginationPage.PaginationInfoLabel.Text);
            _paginationPage.DropdownSelect("30");
            WaitUntil(x => _paginationPage.PaginationResult.Count > 15);
            Assert.AreEqual(30, _paginationPage.PaginationResult.Count);
            Assert.AreEqual("page 1 of 4", _paginationPage.PaginationInfoLabel.Text);
        }


        [Test]
        public void PaginationPage_LastButton_GoesToLastPage()
        {
            _paginationPage.ScrollToTheTop();

            WaitUntil(x => _paginationPage.DropDown.Displayed);
            _paginationPage.DropdownSelect("15");
            WaitUntil(x => _paginationPage.PaginationResult.Count > 5);
            Assert.AreEqual(15, _paginationPage.PaginationResult.Count);
            Assert.AreEqual("page 1 of 7", _paginationPage.PaginationInfoLabel.Text);
            _paginationPage.GoToPage(">>");
            Assert.AreEqual("Arbitrary Book 99 - Arbitrary Author", _paginationPage.PaginationResult.Where(x => x.Text.Contains("99")).Select(x => x.Text).First());
            _paginationPage.GoToPage("3");
            Assert.AreEqual("Arbitrary Book 40 - Arbitrary Author", _paginationPage.PaginationResult.Where(x => x.Text.Contains("40")).Select(x => x.Text).First());
            _paginationPage.GoToPage("<<");
            Assert.AreEqual("Arbitrary Book 1 - Arbitrary Author", _paginationPage.PaginationResult.Where(x => x.Text.Contains("1")).Select(x => x.Text).First());
        }
    }
}
