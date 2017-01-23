using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.ArrayPage
{
    public class TablePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Add a pet']")]
        public IWebElement AddPetButton { get; set; }

        [FindsByAll]
        [FindsBy(How = How.XPath, Using = "//table[@class='table table-striped']//tbody//tr")]
        public IList<IWebElement> PetsTableRows { get; set; }
      
        public TablePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public void AddPet()
        {
            ClickOn(AddPetButton);
        }

        public int CountTableRows()
        {
            return PetsTableRows.Count;
        }
    }
}
