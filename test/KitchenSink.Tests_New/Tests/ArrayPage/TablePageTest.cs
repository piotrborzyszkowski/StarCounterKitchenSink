using NUnit.Framework;

namespace KitchenSink.Test.Array
{
    [TestFixture]
    class TablePageTest : BaseTest
    {
        [Test]
        public void TablePage_AddNewRow()
        {
            MainPage mainPage = new MainPage(Driver);
            TablePage tablePage = mainPage.GoToTablePage();
            var rowsBefore = tablePage.CountTableRows();
            tablePage.AddPet();
            var rowsAfter = tablePage.CountTableRows();
            Assert.Greater(rowsAfter, rowsBefore);
        }
    }
}
