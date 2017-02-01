using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.ArrayPage;
using NUnit.Framework;

namespace KitchenSink.Tests.Tests.ArrayPage
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
            var rowsBefore = _datagridPage.PetsTableRows.Count;
            _datagridPage.AddPet();
            var rowsAfter = _datagridPage.PetsTableRows.Count;
            Assert.Greater(rowsAfter, rowsBefore);
        }
    }
}
