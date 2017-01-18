using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class PasswordPageTest : BaseTest
    {
        [Test]
        public void PasswordPage_PageLoads()
        {
            //driver.Navigate().GoToUrl(baseURL);
            //driver.FindElement(ByHelper.AnyLinkWithText("Password")).ClickUsingMouse(driver);
            //var element = driver.FindElement(ByHelper.AnyInput);
            //Assert.AreEqual(element.GetAttribute("type"), "password");
        }

        [Test]
        public void PasswordPage_PasswordTooShort()
        {
            //driver.Navigate().GoToUrl(baseURL + "/Password");
            //var element = driver.FindElement(ByHelper.AnyInput);
            //Assert.AreEqual(element.GetAttribute("type"), "password");
            //driver.FindElement(ByHelper.AnyInput).Clear();
            //driver.FindElement(ByHelper.AnyInput).SendKeys("Short");
            //Assert.AreEqual(passwordTooShort, driver.FindElement(ByHelper.AnyControlLabel).Text);
        }

        [Test]
        public void PasswordPage_PasswordWithProperLength()
        {
            //driver.Navigate().GoToUrl(baseURL + "/Password");
            //var element = driver.FindElement(ByHelper.AnyInput);
            //Assert.AreEqual(element.GetAttribute("type"), "password");
            //driver.FindElement(ByHelper.AnyInput).Clear();
            //driver.FindElement(ByHelper.AnyInput).SendKeys("PerfectPass");
            //this.WaitUntil(x => !passwordTooShort.Equals(driver.FindElement(ByHelper.AnyControlLabel).Text));
            //Assert.AreEqual(passwordWithProperLength, driver.FindElement(ByHelper.AnyControlLabel).Text);
        }

        [Test]
        public void PasswordPage_ChangingPasswordToGoodThenToShort()
        {
            //driver.Navigate().GoToUrl(baseURL + "/Password");
            //var element = driver.FindElement(ByHelper.AnyInput);
            //Assert.AreEqual(element.GetAttribute("type"), "password");
            //driver.FindElement(ByHelper.AnyInput).Clear();
            //driver.FindElement(ByHelper.AnyInput).SendKeys("PerfectPass");
            //this.WaitUntil(x => !passwordTooShort.Equals(driver.FindElement(ByHelper.AnyControlLabel).Text));
            //driver.FindElement(ByHelper.AnyInput).Clear();
            //driver.FindElement(ByHelper.AnyInput).SendKeys("Bad");
            //this.WaitUntil(x => !passwordWithProperLength.Equals(driver.FindElement(ByHelper.AnyControlLabel).Text));
            //Assert.AreEqual(passwordTooShort, driver.FindElement(ByHelper.AnyControlLabel).Text);
        }
    }
}
