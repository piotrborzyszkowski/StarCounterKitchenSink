using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionArray;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionArray
{
    [TestFixture(Config.Browser.Chrome)]
    [TestFixture(Config.Browser.Edge)]
    [TestFixture(Config.Browser.Firefox)]
    class DropdownPageTest : BaseTest
    {
        private DropdownPage _dropDownPage;
        private MainPage _mainPage;

        public DropdownPageTest(Config.Browser browser) : base(browser)
        {
        }


        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _dropDownPage = _mainPage.GoToDropdownPage();
        }

        [Test]
        public void DropdownPage_PetsDropdown_SelectPets()
        {
            WaitUntil(x => _dropDownPage.PetsSelect.Displayed);
            _dropDownPage.SelectPet("dogs");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_dropDownPage.PetLikeLabel, "You like dogs")));

            _dropDownPage.SelectPet("cats");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_dropDownPage.PetLikeLabel, "You like cats")));

            _dropDownPage.SelectPet("rabbit");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_dropDownPage.PetLikeLabel, "You like rabbit")));
        }

        [Test]
        public void DropdownPage_JuicyDropdown_SelectProduct()
        {
            WaitUntil(x => _dropDownPage.JuicySelect.Displayed);
            Assert.AreEqual(string.Empty, new SelectElement(_dropDownPage.ProductSelect).SelectedOption);

            _dropDownPage.SelectJuicySelect("Polymer JavaScript library");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_dropDownPage.JuicySelectLabel, "You have selected: Polymer JavaScript library")));
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(new SelectElement(_dropDownPage.ProductSelect).SelectedOption, "Polymer JavaScript library")));

            _dropDownPage.SelectJuicySelect("Starcounter Database");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_dropDownPage.JuicySelectLabel, "You have selected: Starcounter Database")));
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(new SelectElement(_dropDownPage.ProductSelect).SelectedOption, "Starcounter Database")));
        }

        [Test]
        public void DropdownPage_Dropdown_SelectProduct()
        {
            WaitUntil(x => _dropDownPage.ProductSelect.Displayed);
            _dropDownPage.SelectProduct("Starcounter Database");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_dropDownPage.JuicySelectLabel, "You have selected: Starcounter Database")));
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(new SelectElement(_dropDownPage.JuicySelect).SelectedOption, "Starcounter Database")));

            _dropDownPage.SelectProduct("Polymer JavaScript library");
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_dropDownPage.JuicySelectLabel, "You have selected: Polymer JavaScript library")));
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(new SelectElement(_dropDownPage.JuicySelect).SelectedOption, "Polymer JavaScript library")));
        }
    }
}

