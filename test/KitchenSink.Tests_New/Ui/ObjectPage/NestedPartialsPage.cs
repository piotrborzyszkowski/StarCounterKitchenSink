using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.ObjectPage
{
    public class NestedPartialsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//button[text() = 'Add child']")]
        public IWebElement AddChildButton { get; set; }

        [FindsByAll]
        [FindsBy(How = How.XPath, Using = "//div[@class = 'kitchensink-nested-child']")]
        public IList<IWebElement> ChildDivs { get; set; }
        
        public NestedPartialsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public void AddChild()
        {
            ClickOn(AddChildButton);
        }

        public int CountChildDivs()
        {
            return ChildDivs.Count;
        }
    }
}
