using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.ArrayPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.ArrayPage
{
    [TestFixture]
    class DatagridPageTest : BaseTest
    {
        private DatagridPage _datagridPage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _datagridPage = _mainPage.GoToDataGridPage();
        }

        [Test]
        public void TablePage_AddNewRow()
        {
            var rowsBefore = _datagridPage.CountTableRows();
            _datagridPage.AddPet();
            var rowsAfter = _datagridPage.CountTableRows();
            Assert.Greater(rowsAfter, rowsBefore);
        }
    }
}
