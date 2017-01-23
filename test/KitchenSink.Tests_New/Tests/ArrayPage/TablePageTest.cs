using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.ArrayPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.ArrayPage
{
    [TestFixture]
    class TablePageTest : BaseTest
    {
        private TablePage _tablePage;

        [SetUp]
        public void SetUp()
        {
            var mainPage = new MainPage(Driver);
            _tablePage = mainPage.GoToTablePage();
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
