using NUnit.Framework;

namespace KitchenSink.Test.Custom
{
    [TestFixture]
    class AutoCompletePageTest : BaseTest
    {
        [Test]
        public void FillStarExpectAllItemsShowUp()
        {
            //driver.FindElement(PlacesSearchSelector).SendKeys("*");
            //Assert.AreEqual(7, driver.FindElements(FoundPlacesSelector).Count);

            //driver.FindElement(ProductsSearchSelector).SendKeys("*");
            //Assert.AreEqual(6, driver.FindElements(FoundProductsSelector).Count);
        }

        [Test]
        public void FillCountryNameThenSelectCountry()
        {
            //if (browser == "firefox")
            //{
            //    Assert.Ignore("GetAttribute(\"value\") is not supported in Selenium 3.0.0-beta2 in Firefox");
            //}
            //driver.FindElement(PlacesSearchSelector).SendKeys("po");
            //var countryToPick = "Poland";
            //AssertElements(FoundPlacesSelector, countryToPick, "Portugal");
            //driver.FindElements(FoundPlacesSelector).First(el => el.Text == countryToPick).Click();
            //this.WaitUntil(d => driver.FindElements(FoundPlacesSelector).Count == 0);
            //Assert.AreEqual(countryToPick, driver.FindElement(PlacesSearchSelector).GetAttribute("value"),
            //    "Search textbox has invalid content");
            //Assert.AreEqual("Capital of Poland is Warsaw",
            //    driver.FindElement(By.Id("kitchensink-autocomplete-capital")).Text,
            //    "Invalid capital text");
        }

        [Test]
        public void FillProductNameThenSelectProduct()
        {
            //if (browser == "firefox")
            //{
            //    Assert.Ignore("GetAttribute(\"value\") is not supported in Selenium 3.0.0-beta2 in Firefox");
            //}
            //driver.FindElement(ProductsSearchSelector).SendKeys("Whisk");
            //var whiskeyToPick = "Irish Whiskey";
            //AssertElements(FoundProductsSelector, "Scotch Whisky", whiskeyToPick);
            //driver.FindElements(FoundProductsSelector).First(el => el.Text == whiskeyToPick).Click();
            //this.WaitUntil(d => driver.FindElements(FoundProductsSelector).Count == 0);
            //Assert.AreEqual(whiskeyToPick, driver.FindElement(ProductsSearchSelector).GetAttribute("value"),
            //    "Search textbox has invalid content");
            //Assert.AreEqual("Irish Whiskey costs $2", driver.FindElement(By.Id("kitchensink-autocomplete-price")).Text,
            //    "Invalid capital text");
        }

        [Test]
        public void FillPlaceNameThenBlurExpectHintsGone()
        {
            //if (browser == "edge")
            //{
            //    Assert.Ignore("Blur event does not fire in edge under selenium");
            //}
            //var placesSearchbox = driver.FindElement(PlacesSearchSelector);
            //placesSearchbox.SendKeys("po");
            //this.WaitUntil(d => d.FindElements(FoundPlacesSelector).Count != 0);
            //Assert.AreEqual(driver.FindElements(FoundPlacesSelector).Count, 2);
            //placesSearchbox.SendKeys(Keys.Tab);
            //driver.FindElement(ProductsSearchSelector).Click();
            //this.WaitUntil(d => d.FindElements(FoundPlacesSelector).Count == 0);
            //Assert.IsEmpty(driver.FindElements(FoundPlacesSelector));
        }
    }
}
