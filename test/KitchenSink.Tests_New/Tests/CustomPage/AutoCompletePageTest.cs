using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.CustomPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.CustomPage
{
    [TestFixture]
    class AutoCompletePageTest : BaseTest
    {
        private AutoCompletePage _autoCompletePage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _autoCompletePage = _mainPage.GoToAutoCompletePage();
        }

        [Test]
        public void AutoCompletePage_FillStarExpectAllItemsShowUp()
        {
            WaitUntil(x => _autoCompletePage.ProductsInput.Displayed);
            _autoCompletePage.ClearProductsInput();
            _autoCompletePage.SendKeyProductsInput("*");
            WaitUntil(x => _autoCompletePage.ProductsAutoComplete.Count > 0);
            Assert.AreEqual(8, _autoCompletePage.ProductsAutoComplete.Count);

            WaitUntil(x => _autoCompletePage.PlaceInput.Displayed);
            _autoCompletePage.ClearPlaceInput();
            _autoCompletePage.SendKeyPlacesInput("*");
            WaitUntil(x => _autoCompletePage.PlacesAutoComplete.Count > 0);
            Assert.AreEqual(7, _autoCompletePage.PlacesAutoComplete.Count);
        }

        [Test]
        public void AutoCompletePage_FillCountryNameThenSelectCountry()
        {
            WaitUntil(x => _autoCompletePage.PlaceInput.Displayed);
            _autoCompletePage.ClearPlaceInput();
            _autoCompletePage.SendKeyPlacesInput("P");
            WaitUntil(x => _autoCompletePage.PlacesAutoComplete.Count > 0);
            _autoCompletePage.ChoosePlace("Poland");
            Assert.AreEqual("Capital of Poland is Warsaw", _autoCompletePage.PlaceInfoLabel.Text);
        }

        [Test]
        public void AutoCompletePage_FillProductNameThenSelectProduct()
        {
            WaitUntil(x => _autoCompletePage.ProductsInput.Displayed);
            _autoCompletePage.ClearProductsInput();
            _autoCompletePage.SendKeyProductsInput("B");
            WaitUntil(x => _autoCompletePage.ProductsAutoComplete.Count > 0);
            _autoCompletePage.ChooseProducts("Bread");
            Assert.AreEqual("Bread costs $1", _autoCompletePage.ProductsInfoLabel.Text);
        }
    }
}
