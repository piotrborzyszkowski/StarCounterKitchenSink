using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui.ArrayPage
{
    public class RadioPage : BasePage
    {
        public RadioPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-pet-reaction__label")]
        public IWebElement InfoLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests__radio-buttons")]
        public IList<IWebElement> Radios { get; set; }


        public void SelectRadio(string radioName)
        {
            var temp = Radios.Single(x => x.GetAttribute("test-value") == radioName);
            ClickOn(temp);
        }
    }
}
