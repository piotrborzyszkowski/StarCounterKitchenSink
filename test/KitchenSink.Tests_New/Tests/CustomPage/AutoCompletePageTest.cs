using NUnit.Framework;

namespace KitchenSink.Test.Custom
{
    [TestFixture]
    class AutoCompletePageTest : BaseTest
    {
        private AutoCompletePage _autoCompletePage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mainPage = new MainPage(Driver);
            _autoCompletePage = mainPage.GoToAutoCompletePage();
        }

        [Test]
        public void AutoCompletePage_FillStarExpectAllItemsShowUp()
        {
            _autoCompletePage.ClearProductsInput();
            _autoCompletePage.SendKeyProductsInput("*");
            WaitUntil(x => _autoCompletePage.ProductsAutoComplete.Count > 0);
            Assert.AreEqual(8, _autoCompletePage.ProductsAutoComplete.Count);

            _autoCompletePage.ClearPlaceInput();
            _autoCompletePage.SendKeyPlacesInput("*");
            WaitUntil(x => _autoCompletePage.PlacesAutoComplete.Count > 0);
            Assert.AreEqual(7, _autoCompletePage.PlacesAutoComplete.Count);
        }

        [Test]
        public void AutoCompletePage_FillCountryNameThenSelectCountry()
        {
            _autoCompletePage.ClearPlaceInput();
            _autoCompletePage.SendKeyPlacesInput("P");
            WaitUntil(x => _autoCompletePage.PlacesAutoComplete.Count > 0);
            _autoCompletePage.ChoosePlace("Poland");
            Assert.AreEqual("Capital of Poland is Warsaw", _autoCompletePage.PlaceInfoLabel.Text);
        }

        [Test]
        public void AutoCompletePage_FillProductNameThenSelectProduct()
        {
            _autoCompletePage.ClearProductsInput();
            _autoCompletePage.SendKeyProductsInput("B");
            WaitUntil(x => _autoCompletePage.ProductsAutoComplete.Count > 0);
            _autoCompletePage.ChooseProducts("Bread");
            Assert.AreEqual("Bread costs $1", _autoCompletePage.ProductsInfoLabel.Text);
        }
    }
}
