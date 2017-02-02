using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionCustom;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.SectionCustom
{
    [TestFixture(Config.Browser.Chrome, "Krystian Matti", "Running AutoComplete Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Krystian Matti", "Running AutoComplete Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Krystian Matti", "Running AutoComplete Page Test on Firefox")]
    class AutoCompletePageTest : BaseTest
    {
        private AutoCompletePage _autoCompletePage;
        private MainPage _mainPage;

        public AutoCompletePageTest(Config.Browser browser) : base(browser)
        {
        }

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
            _autoCompletePage.ProductsInput.Clear();
            _autoCompletePage.ProductsInput.SendKeys("*");
            WaitUntil(x => _autoCompletePage.ProductsAutoComplete.Count > 0);
            Assert.AreEqual(8, _autoCompletePage.ProductsAutoComplete.Count);

            WaitUntil(x => _autoCompletePage.PlaceInput.Displayed);
            _autoCompletePage.PlaceInput.Clear();
            _autoCompletePage.PlaceInput.SendKeys("*");
            WaitUntil(x => _autoCompletePage.PlacesAutoComplete.Count > 0);
            Assert.AreEqual(7, _autoCompletePage.PlacesAutoComplete.Count);
        }

        [Test]
        public void AutoCompletePage_FillCountryNameThenSelectCountry()
        {
            WaitUntil(x => _autoCompletePage.PlaceInput.Displayed);
            _autoCompletePage.PlaceInput.Clear();
            _autoCompletePage.PlaceInput.SendKeys("P");
            WaitUntil(x => _autoCompletePage.PlacesAutoComplete.Count > 0);
            _autoCompletePage.ChoosePlace("Poland");
            Assert.AreEqual("Capital of Poland is Warsaw", _autoCompletePage.PlaceInfoLabel.Text);
        }

        [Test]
        public void AutoCompletePage_FillProductNameThenSelectProduct()
        {
            WaitUntil(x => _autoCompletePage.ProductsInput.Displayed);
            _autoCompletePage.PlaceInput.Clear();
            _autoCompletePage.ProductsInput.SendKeys("B");
            WaitUntil(x => _autoCompletePage.ProductsAutoComplete.Count > 0);
            _autoCompletePage.ChooseProducts("Bread");
            Assert.AreEqual("Bread costs $1", _autoCompletePage.ProductsInfoLabel.Text);
        }
    }
}
