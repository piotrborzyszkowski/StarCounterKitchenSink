using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace KitchenSink.Test.Array
{
    public class TablePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Add a pet']")]
        public IWebElement addPetButton { get; set; }

        [FindsByAll]
        [FindsBy(How = How.XPath, Using = "//table[@class='table table-striped']//tbody//tr")]
        public IList<IWebElement> petsTableRows { get; set; }
      
        public TablePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public void AddPet()
        {
            ClickOn(addPetButton);
        }

        public int CountTableRows()
        {
            return petsTableRows.Count;
        }
    }
}
