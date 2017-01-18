using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace KitchenSink.Test.Array
{
    public class DropdownPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//select[@slot = 'KitchenSink/2']")]
        public IWebElement petsSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@slot = 'KitchenSink/3']")]
        public IWebElement petLikeLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@slot = 'KitchenSink/9']")]
        public IWebElement juicySelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@slot = 'KitchenSink/13']")]
        public IWebElement juicySelectLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//juicy-select[@class = 'kitchensink-juicyselect']//select")]
        public IWebElement juicySelect2 { get; set; }

        public DropdownPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public void SelectPet(string petName)
        {
            WaitForElementToBeClickable(petsSelect, 3);
            SelectElement sel = new SelectElement(petsSelect);
            sel.SelectByText(petName);
        }

        public void SelectJuicy(string juicyName)
        {
            WaitForElementToBeClickable(juicySelect, 3);
            SelectElement sel = new SelectElement(juicySelect);
            sel.SelectByText(juicyName);
        }

        public string GetJuicySelectValue()
        {
            SelectElement sel = new SelectElement(juicySelect);
            return sel.SelectedOption.Text;

        }

        public string GetJuicySelect2Value()
        {
            SelectElement sel = new SelectElement(juicySelect2);
            return sel.SelectedOption.Text;
        }

        public void SelectJuicy2(string juicyName)
        {
            WaitForElementToBeClickable(juicySelect2, 3);
            SelectElement sel = new SelectElement(juicySelect2);
            sel.SelectByText(juicyName);
        }
    }
}
