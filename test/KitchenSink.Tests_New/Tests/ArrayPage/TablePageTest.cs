using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.ArrayPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.ArrayPage
{
    [TestFixture]
    class TablePageTest : BaseTest
    {
        private TablePage _tablePage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _tablePage = _mainPage.GoToTablePage();
        }

        [Test]
        public void TablePage_AddNewRow()
        {

            var rowsBefore = _tablePage.CountTableRows();
            _tablePage.AddPet();
            var rowsAfter = _tablePage.CountTableRows();
            Assert.Greater(rowsAfter, rowsBefore);
        }
    }
}
