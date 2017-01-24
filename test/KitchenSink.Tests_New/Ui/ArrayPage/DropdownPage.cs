using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests_New.Ui.ArrayPage
{
    public class DropdownPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".automated-tests-pets__select")]
        public IWebElement PetsSelect { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-pet-like__label")]
        public IWebElement PetLikeLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-product__select")]
        public IWebElement ProductSelect { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests-juicy-select__label")]
        public IWebElement JuicySelectLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".automated-tests__juicy-select select")]
        public IWebElement JuicySelect { get; set; }

        public DropdownPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public void SelectPet(string petName)
        {
            SelectElement sel = new SelectElement(PetsSelect);
            sel.SelectByText(petName);
        }

        public void SelectJuicy(string juicyName)
        {
            SelectElement sel = new SelectElement(ProductSelect);
            sel.SelectByText(juicyName);
        }

        public string GetJuicySelectValue()
        {
            SelectElement sel = new SelectElement(ProductSelect);
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
