using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class RedirectPageTest : BaseTest
    {
        private RedirectPage _redirectPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            MainPage mainPage = new MainPage(Driver);
            _redirectPage = mainPage.GoToRedirectPage();
        }

        [Test]
        public void RedirectPage_ClickingOnFruitShouldChangeUrlAndText()
        {

            var oryginalText = "Select your favorite food";

            _redirectPage.ClickButton("Fruit");
            WaitUntil(x => _redirectPage.InfoLabel.Text != oryginalText);
            Assert.AreEqual("You\'ve got some tasty apple", _redirectPage.InfoLabel.Text);
            Assert.AreEqual("http://localhost:8080/KitchenSink/Redirect/apple", Driver.Url);
            
            oryginalText = "You\'ve got some tasty apple";
            _redirectPage.ClickButton("Vegetable");
            WaitUntil(x => _redirectPage.InfoLabel.Text != oryginalText);
            Assert.AreEqual("You\'ve got some tasty carrot", _redirectPage.InfoLabel.Text);
            Assert.AreEqual("http://localhost:8080/KitchenSink/Redirect/carrot", Driver.Url);

            oryginalText = "You\'ve got some tasty carrot";
            _redirectPage.ClickButton("Bread");
            WaitUntil(x => _redirectPage.InfoLabel.Text != oryginalText);
            Assert.AreEqual("You\'ve got some tasty baguette", _redirectPage.InfoLabel.Text);
            Assert.AreEqual("http://localhost:8080/KitchenSink/Redirect/baguette", Driver.Url);
        }

        [Test]
        public void RedirectPage_ClickingOnRedirectToAnotherPartialShouldChangeUrl()
        {
            MainPage mainPage = new MainPage(Driver);
            RedirectPage redirectPage = mainPage.GoToRedirectPage();

            redirectPage.ClickButton("Morph");
            Assert.AreEqual("http://localhost:8080/KitchenSink", Driver.Url);
        }

        [Test]
        public void RedirectPage_ClickingOnRedirectToExternalWebsiteShouldChangeUrl()
        {
            MainPage mainPage = new MainPage(Driver);
            RedirectPage redirectPage = mainPage.GoToRedirectPage();

            redirectPage.ClickButton("Redirect");
            Assert.AreEqual("https://starcounter.io/", Driver.Url);
        }
    }
}
