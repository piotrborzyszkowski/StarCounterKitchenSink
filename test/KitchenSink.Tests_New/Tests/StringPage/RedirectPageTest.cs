using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.StringPage;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;

namespace KitchenSink.Tests.Tests.StringPage
{
    [TestFixture]
    class RedirectPageTest : BaseTest
    {
        private RedirectPage _redirectPage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _redirectPage = _mainPage.GoToRedirectPage();
        }

        [Test]
        public void RedirectPage_ClickingOnFruitShouldChangeUrlAndText()
        {
            var originalText = "Select your favorite food";

            _redirectPage.ClickButton("Fruit");
            WaitUntil(x => _redirectPage.InfoLabel.Text != originalText);
            Assert.AreEqual("You\'ve got some tasty apple", _redirectPage.InfoLabel.Text);
            Assert.AreEqual(Config.KitchenSinkUrl + "/Redirect/apple", Driver.Url);
            
            originalText = "You\'ve got some tasty apple";
            _redirectPage.ClickButton("Vegetable");
            WaitUntil(x => _redirectPage.InfoLabel.Text != originalText);
            Assert.AreEqual("You\'ve got some tasty carrot", _redirectPage.InfoLabel.Text);
            Assert.AreEqual(Config.KitchenSinkUrl + "/Redirect/carrot", Driver.Url);

            originalText = "You\'ve got some tasty carrot";
            _redirectPage.ClickButton("Bread");
            WaitUntil(x => _redirectPage.InfoLabel.Text != originalText);
            Assert.AreEqual("You\'ve got some tasty baguette", _redirectPage.InfoLabel.Text);
            Assert.AreEqual(Config.KitchenSinkUrl + "/Redirect/baguette", Driver.Url);
        }

        [Test]
        public void RedirectPage_ClickingOnRedirectToAnotherPartialShouldChangeUrl()
        {
            _redirectPage.ClickButton("Morph");
            WaitUntil(x => Driver.Url == Config.KitchenSinkUrl.ToString());
            Assert.AreEqual(Config.KitchenSinkUrl, Driver.Url);
        }

        [Test]
        public void RedirectPage_ClickingOnRedirectToExternalWebsiteShouldChangeUrl()
        {
            _redirectPage.ClickButton("Redirect");
            WaitUntil(x => Driver.Url == "https://starcounter.io/");
            Assert.AreEqual("https://starcounter.io/", Driver.Url);
        }
    }
}
