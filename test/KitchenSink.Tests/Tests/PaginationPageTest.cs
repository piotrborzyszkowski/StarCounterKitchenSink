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

            var element = driver.FindElements(By.ClassName("kitchensink-pagination-entry"));
            Assert.IsNotEmpty(element);
        }

        [Test]
        public void PaginationPage_DropdownTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/pagination");
            var dropDown = driver.FindElement(By.TagName("select"));
            var firstOption = dropDown.FindElement(By.TagName("option"));
            Assert.AreEqual(firstOption.GetAttribute("value"), firstOption.Text);
            Assert.AreEqual(driver.FindElements(By.ClassName("kitchensink-pagination-entry")).Count, 5);
            dropDown.ClickUsingMouse(driver);
            dropDown.SendKeys(Keys.Down);
            dropDown.SendKeys(Keys.Enter);
            Assert.AreEqual(driver.FindElements(By.ClassName("kitchensink-pagination-entry")).Count, 15);
        }

        public void ClickButton(string buttonID, string initialElementText)
        {
            driver.FindElement(By.Id(buttonID)).ClickUsingMouse(driver);
            wait.Until((x) => {
                var currentText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
                return !initialElementText.Equals(currentText);
            });
        }

        [Test]
        public void PaginationPage_LastButtonTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/pagination");

            var initialElementText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
            ClickButton("kitchensink-pagination-last", initialElementText);
            Assert.AreNotEqual(initialElementText, driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text);
        }


        // This test is dependent on the last button
        [Test]
        public void PaginationPage_FirstButtonTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/pagination");

            ClickButton("kitchensink-pagination-last", driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text);
            var initialElementText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
            ClickButton("kitchensink-pagination-first", initialElementText);
            Assert.AreNotEqual(initialElementText, driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text);
        }

        [Test]
        public void PaginationPage_NextButtonTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/pagination");

            var initialElementText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
            ClickButton("kitchensink-pagination-next", initialElementText);
            Assert.AreNotEqual(initialElementText, driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text);
        }

        // This test is dependent on the next button
        [Test]
        public void PaginationPage_PreviousButtonTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/pagination");

            ClickButton("kitchensink-pagination-next", driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text);
            var initialElementText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
            ClickButton("kitchensink-pagination-previous", initialElementText);
            Assert.AreNotEqual(initialElementText, driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text);
        }

        [Test]
        public void PaginationPage_NavButtonTests()
        {
            driver.Navigate().GoToUrl(baseURL + "/pagination");

            var buttons = driver.FindElements(By.ClassName("kitchensink-pagination-change"));

            System.Diagnostics.Debug.WriteLine("HERE");

            foreach (var button in buttons)
            {
                System.Diagnostics.Debug.Write("HERE");
                var initialElementText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
                button.ClickUsingMouse(driver);
                wait.Until((x) => {
                    var currentText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
                    if (button.Text == "1")
                    {
                        return initialElementText.Equals(currentText);
                    }
                    return !initialElementText.Equals(currentText);
                });
                // If you get through the wait.Until, then it must be true 
                // could probabaly replace with Assert.True(true) without any issues
                if (button.Text == "1")
                {
                    Assert.AreEqual(initialElementText, driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text);
                }
                else
                {
                    Assert.AreNotEqual(initialElementText, driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text);
                }
            }
        }
    }
}