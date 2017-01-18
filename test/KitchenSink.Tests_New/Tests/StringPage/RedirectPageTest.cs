using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class RedirectPageTest : BaseTest
    {
        [Test]
        public void ClickingOnFruitShouldChangeUrlAndText()
        {
            //ClickButton("Fruit");

            //// on edge juicy sometimes messes up the dom tree, so you can't be sure about its relative position to button
            //this.WaitUntil(ExpectedConditions.ElementIsVisible(ByHelper.AnyDivWithText("You've got some tasty apple")));
            //Assert.That(driver.Url, Is.EqualTo($"{baseURL}/Redirect/apple"));
        }

        [Test]
        public void ClickingOnRedirectToAnotherPartialShouldChangeUrl()
        {
            //ClickButton("Morph to another partial");

            //// redirecting can take some time
            //this.WaitUntil(ExpectedConditions.UrlContains(baseURL));
        }

        [Test]
        public void ClickingOnRedirectToExternalWebsiteShouldChangeUrl()
        {
            //ClickButton("Redirect to Starcounter.io");

            //// see https://github.com/PuppetJs/puppet-redirect/issues/3
            //// this is no longer needed, since puppet-client shows a "reconnection" message instead of alert
            ////if (browser == "firefox") {
            //// depending on wheter or not Launcher will be present, the dialog will differ
            //// _wait.Until(d => WaitForNoConnectionAndDismiss(d) || d.FindElements(By.XPath("//h4[text()='Connection error']")).Count != 0);
            ////}

            //// redirecting can take some time
            //this.WaitUntil(ExpectedConditions.UrlContains("https://starcounter.io/"));
        }
    }
}
