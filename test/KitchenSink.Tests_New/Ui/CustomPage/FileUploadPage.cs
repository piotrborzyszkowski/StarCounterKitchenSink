using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.CustomPage
{
    public class FileUploadPage : BasePage
    {
        public FileUploadPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.Id, Using = "fileElement")]
        public IWebElement FileInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert-warning")]
        public IWebElement InfoLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-uploaded-files__list")]
        public IList<IWebElement> UploadedFilesList { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-delete__button")]
        public IList<IWebElement> DeleteButtons { get; set; }

        public void UploadAFile(string filePath)
        {
            //((IJavaScriptExecutor)Driver).ExecuteScript("document.getElementById('fileElement').value = '" + filePath + "'");
            FileInput.SendKeys(filePath);
        }

        public int GetUploadedFilesCount()
        {
            return UploadedFilesList.Count;
        }

        public void DeleteAllFiles()
        {
            foreach (var deleteButton in DeleteButtons)
            {
                ClickOn(deleteButton);
            }
        }
    }
}
