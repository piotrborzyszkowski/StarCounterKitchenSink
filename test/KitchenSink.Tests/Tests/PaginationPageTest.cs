using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using KitchenSink.Tests;
using System.Threading;
using System.Collections.Generic;

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

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(baseURL + "/pagination");
            this.WaitUntil(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("puppet-client")));
        }

        [Test]
        public void PaginationPage_PageLoads()
        {
            driver.Navigate().GoToUrl(baseURL);

            driver.FindElement(ByHelper.AnyLinkWithText("Pagination")).ClickUsingMouse(driver);
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("kitchensink-pagination-entry")));
        }

        [Test]
        public void PaginationPage_Dropdown_HasCorrectOptions()
        {
            var dropDownOptions = driver.FindElements(By.XPath("//select/option"));
            string[] entriesPerPage = new string[] { "5", "15", "30" };
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(dropDownOptions[i].Text, entriesPerPage[i]);
            }
        }

        [Test]
        public void PaginationPage_DropDown_RightNumberOfElementsOnClick()
        {
            var dropDownOptions = driver.FindElements(By.XPath("//select/option"));
            int[] entriesPerPage = new int[] { 5, 15, 30 };
            for (int i = 0; i < dropDownOptions.Count; i++)
            {
                var dropDown = driver.FindElement(By.TagName("select"));
                var dropDownSelect = new SelectElement(dropDown);
                dropDownSelect.SelectByIndex(i);

                wait.Until((x) => x.FindElements(By.ClassName("kitchensink-pagination-entry")).Count.Equals(entriesPerPage[i]));
            }
        }

        [Test]
        public void PaginationPage_LastButton_GoesToLastPage()
        {
            var initialElementText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
            ClickButton("kitchensink-pagination-last", initialElementText);

            Assert.AreEqual(driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text, "Arbitrary Book 96 - Arbitrary Author");
        }


        // This test is dependent on the last button
        [Test]
        public void PaginationPage_FirstButton_GoesToFirstPage()
        {
            ClickButton("kitchensink-pagination-last", driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text);
            var initialElementText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
            ClickButton("kitchensink-pagination-first", initialElementText);
            Assert.AreEqual(driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text, "Arbitrary Book 1 - Arbitrary Author");
        }

        [Test]
        public void PaginationPage_NextButton_GoesToNextPage()
        {
            var initialElementText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
            ClickButton("kitchensink-pagination-next", initialElementText);
            Assert.AreEqual(driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text, "Arbitrary Book 6 - Arbitrary Author");
        }

        // This test is dependent on the next button
        [Test]
        public void PaginationPage_PreviousButton_GoesToPreviousPage()
        {
            ClickButton("kitchensink-pagination-next", driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text);
            var initialElementText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
            ClickButton("kitchensink-pagination-previous", initialElementText);
            Assert.AreEqual(driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text, "Arbitrary Book 1 - Arbitrary Author");
        }

        [Test]
        public void PaginationPage_NavButtons_GoesToRightPage()
        {
            var buttons = driver.FindElements(By.ClassName("kitchensink-pagination-change"));
            for (int i = 0; i < 3; i++)
            {
                buttons[i].ClickUsingMouse(driver);
                wait.Until((x) => {
                    var expectedFirstEntryText = "Arbitrary Book " + (Int32.Parse(buttons[i].Text) * 5 - 4).ToString() + " - Arbitrary Author";
                    var firstEntryText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
                    return expectedFirstEntryText == firstEntryText;
               });
            }

        }
        
        private void ClickButton(string buttonID, string initialElementText)
        {
            driver.FindElement(By.Id(buttonID)).ClickUsingMouse(driver);
            wait.Until((x) => {
                var currentText = driver.FindElement(By.ClassName("kitchensink-pagination-entry")).Text;
                return !initialElementText.Equals(currentText);
            });
        }
    }
}