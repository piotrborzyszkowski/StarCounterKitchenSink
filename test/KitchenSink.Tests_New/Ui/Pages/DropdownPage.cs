using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Test
{
    public class DropdownPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//select[@slot = '2']")]
        public IWebElement petsSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@slot = '3']")]
        public IWebElement petLikeLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@slot = '9']")]
        public IWebElement juicySelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@slot = '13']")]
        public IWebElement juicySelectLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//juicy-select[@class = 'kitchensink-juicyselect']//select")]
        public IWebElement juicySelect2 { get; set; }

        public DropdownPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public void SelectPet(string petName)
        {
            SelectElement sel = new SelectElement(petsSelect);
            sel.SelectByText(petName);
        }

        public void SelectJuicy(string juicyName)
        {
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
            SelectElement sel = new SelectElement(juicySelect2);
            sel.SelectByText(juicyName);
        }
    }
}
