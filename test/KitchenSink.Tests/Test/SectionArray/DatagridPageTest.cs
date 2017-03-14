using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionArray;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.SectionArray
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(Config.Browser.Chrome)]
    [TestFixture(Config.Browser.Edge)]
    [TestFixture(Config.Browser.Firefox)]
    class DatagridPageTest : BaseTest
    {
        private DatagridPage _datagridPage;
        private MainPage _mainPage;
        private readonly Config.Browser _browser;

        public DatagridPageTest(Config.Browser browser) : base(browser)
        {
            _browser = browser;
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _datagridPage = _mainPage.GoToDataGridPage();
        }

        [Test]
        public void TablePage_AddNewRow()
        {
            if (_browser == Config.Browser.Chrome)
                WaitUntil(x => _datagridPage.CheckTableVisible());
            else
                WaitUntil(x => _datagridPage.PetsTable.Displayed);
            
            _datagridPage.AddPet();

            if (_browser == Config.Browser.Chrome)
                WaitUntil(x => _datagridPage.GetTableRowsCount() == 4);
            else
                WaitUntil(x => _datagridPage.PetsTableRows.Count == 4);
        }
    }
}
