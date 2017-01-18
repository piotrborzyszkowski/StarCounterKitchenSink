using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class TextareaPageTest : BaseTest
    {
        [Test]
        public void TextareaPage_PageLoads()
        {
            //driver.Navigate().GoToUrl(baseURL);

            //driver.FindElement(ByHelper.AnyLinkWithText("Textarea")).ClickUsingMouse(driver);

            //var element = driver.FindElement(ByHelper.AnyTextareaFormControl);
            //Assert.AreEqual(element.Text, "");
        }

        [Test]
        public void TextareaPage_WriteToTextArea()
        {
            //if (browser == "firefox")
            //{
            //    Assert.Ignore("GetAttribute(\"value\") is not supported in Selenium 3.0.0-beta2 in Firefox");
            //}

            //driver.Navigate().GoToUrl(baseURL + "/Textarea");

            //driver.FindElement(ByHelper.AnyTextareaFormControl).Clear();

            //string setString = "We all love princess cake!";
            //driver.FindElement(ByHelper.AnyTextareaFormControl).SendKeys(setString);

            //string actualString = driver.FindElement(ByHelper.AnyTextareaFormControl).GetAttribute("value");

            //Assert.AreEqual(setString, actualString);
        }

        [Test]
        public void TextareaPage_CounterPropagationWhileTyping()
        {
            //driver.Navigate().GoToUrl(baseURL + "/Textarea");

            //var label = driver.FindElement(ByHelper.AnyControlLabel);
            //var originalText = label.Text;

            //driver.FindElement(ByHelper.AnyTextarea).Clear();
            //Assert.AreEqual("Length of your bio: 0 chars", originalText);

            //driver.FindElement(ByHelper.AnyTextarea).SendKeys("U");
            //this.WaitUntil(x => !label.Text.Equals(originalText));

            //string actualString = driver.FindElement(ByHelper.AnyControlLabel).Text;
            //Assert.AreEqual("Length of your bio: 1 chars", actualString);
        }
    }
}
