using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.CustomPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.CustomPage
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
            WaitUntil(x => _paginationPage.DropDown.Displayed);
            _paginationPage.DropdownSelect("5");          
            Assert.AreEqual(5, _paginationPage.CountPaginationResult());
            Assert.AreEqual("page 1 of 20", _paginationPage.PaginationInfoLabel.Text);
            _paginationPage.DropdownSelect("15");
            WaitUntil(x => _paginationPage.CountPaginationResult() > 5);
            Assert.AreEqual(15, _paginationPage.CountPaginationResult());
            Assert.AreEqual("page 1 of 7", _paginationPage.PaginationInfoLabel.Text);
            _paginationPage.DropdownSelect("30");
            WaitUntil(x => _paginationPage.CountPaginationResult() > 15);
            Assert.AreEqual(30, _paginationPage.CountPaginationResult());
            Assert.AreEqual("page 1 of 4", _paginationPage.PaginationInfoLabel.Text);
        }


        [Test]
        public void PaginationPage_LastButton_GoesToLastPage()
        {
            WaitUntil(x => _paginationPage.DropDown.Displayed);
            _paginationPage.DropdownSelect("15");
            WaitUntil(x => _paginationPage.CountPaginationResult() > 5);
            Assert.AreEqual(15, _paginationPage.CountPaginationResult());
            Assert.AreEqual("page 1 of 7", _paginationPage.PaginationInfoLabel.Text);
            _paginationPage.GoToPage(">>");
            Assert.AreEqual("Arbitrary Book 99 - Arbitrary Author", _paginationPage.GetTitle("99"));
            _paginationPage.GoToPage("3");
            Assert.AreEqual("Arbitrary Book 40 - Arbitrary Author", _paginationPage.GetTitle("40"));
            _paginationPage.GoToPage("<<");
            Assert.AreEqual("Arbitrary Book 1 - Arbitrary Author", _paginationPage.GetTitle("1"));
        }
    }
}
