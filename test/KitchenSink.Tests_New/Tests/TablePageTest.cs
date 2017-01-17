using KitchenSink.Test;
using NUnit.Framework;

namespace KitchenSink.Tests
{
    [TestFixture]
    class TablePageTest : BaseTest
    {
        [Test]
        public void TableTest()
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
