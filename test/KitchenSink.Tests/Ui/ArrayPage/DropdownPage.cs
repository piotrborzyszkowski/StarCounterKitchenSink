using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Ui.ArrayPage
{
    public class DropdownPage : BasePage
    {
        public DropdownPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-pets__select")]
        public IWebElement PetsSelect { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-pet-like__label")]
        public IWebElement PetLikeLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-product__select")]
        public IWebElement ProductSelect { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-juicy-select__label")]
        public IWebElement JuicySelectLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test__juicy-select select")]
        public IWebElement JuicySelect { get; set; }

        public void SelectPet(string petName)
        {
            SelectElement sel = new SelectElement(PetsSelect);
            sel.SelectByText(petName);
        }

        public void SelectProduct(string productName)
        {
            SelectElement sel = new SelectElement(ProductSelect);
            sel.SelectByText(productName);
        }

        public string GetJuicySelectValue()
        {
            SelectElement sel = new SelectElement(JuicySelect);
            return sel.SelectedOption.Text;
        }

        public string GetJuicySelect2Value()
        {
            SelectElement sel = new SelectElement(JuicySelect);
            return sel.SelectedOption.Text;
        }

        public void SelectJuicy2(string juicyName)
        {
            SelectElement sel = new SelectElement(JuicySelect);
            sel.SelectByText(juicyName);
        }
    }
}
