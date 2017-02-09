﻿using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionArray;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.SectionArray
{
    [TestFixture(Config.Browser.Chrome,"Running Table Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Running Table Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Running Table Page Test on Firefox")]
    class TablePageTest : BaseTest
    {
        private TablePage _tablePage;
        private MainPage _mainPage;

        public TablePageTest(Config.Browser browser) : base(browser)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _tablePage = _mainPage.GoToTablePage();
        }

        [Test]
        public void TablePage_AddNewRow()
        {

            var rowsBefore = _tablePage.PetsTableRows.Count;
            _tablePage.AddPet();
            var rowsAfter = _tablePage.PetsTableRows.Count;
            Assert.Greater(rowsAfter, rowsBefore);
        }
    }
}
