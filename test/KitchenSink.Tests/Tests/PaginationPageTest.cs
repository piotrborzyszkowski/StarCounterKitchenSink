using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using KitchenSink.Tests;
using System.Threading;

namespace KitchenSink.Test
{
    [TestFixture("firefox")]
    [TestFixture("chrome")]
    [TestFixture("edge")]
    public class PaginationPageTest : BaseTest
    {
        public PaginationPageTest(string browser) : base(browser)
        {
        }

        [Test]
        public void PaginationPage_PageLoads()
        {
            driver.Navigate().GoToUrl(baseURL);

            driver.FindElement(ByHelper.AnyLinkWithText("Pagination")).ClickUsingMouse(driver);

            var element = driver.FindElement(ByHelper.AnyButtonWithText("1"));
            Assert.AreEqual(element.GetAttribute("class"), "page-link pagination-box btn btn-default active");
        }

        [Test]
        public void PaginationPage_DropdownTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/pagination");
            var dropDown = driver.FindElement(By.TagName("select"));
            var firstOption = dropDown.FindElement(By.TagName("option"));
            Assert.AreEqual(firstOption.GetAttribute("value"), firstOption.Text);
            Assert.AreEqual(driver.FindElements(By.TagName("paper-item")).Count, 5);
            dropDown.ClickUsingMouse(driver);
            dropDown.SendKeys(Keys.Down);
            dropDown.SendKeys(Keys.Enter);
            Assert.AreEqual(driver.FindElements(By.TagName("paper-item")).Count, 15);
        }

        [Test]
        public void PaginationPage_FirstLastButtonsTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/pagination");

            var initialElement = driver.FindElement(By.TagName("paper-item"));
            driver.FindElement(ByHelper.AnyButtonWithText(">>")).ClickUsingMouse(driver);
            this.WaitUntil((x) => !initialElement.Equals(By.TagName("paper-item")));
            driver.FindElement(ByHelper.AnyButtonWithText("<<")).ClickUsingMouse(driver);
            var finalElement = driver.FindElement(By.TagName("paper-item"));
            Assert.AreEqual(initialElement, finalElement);
        }

        [Test]
        public void PaginationPage_NavButtonTests()
        {
            driver.Navigate().GoToUrl(baseURL + "/pagination");

            string[] buttonText = new string[] { "3", ">", "<", "4" };

            foreach (string text in buttonText)
            {
                var initialElementText = driver.FindElement(By.TagName("paper-item")).Text;
                driver.FindElement(ByHelper.AnyButtonWithText(text)).ClickUsingMouse(driver);

                wait.Until((x) => {
                    var currentText = driver.FindElement(By.TagName("paper-item")).Text;
                    return !initialElementText.Equals(currentText);
                });

                var finalElementText = driver.FindElement(By.TagName("paper-item")).Text;
                Assert.AreNotEqual(initialElementText, finalElementText);
            }
        }
    }
}