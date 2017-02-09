using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionArray;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionArray
{
    [TestFixture(Config.Browser.Chrome, "Krystian Matti", "Running Dropdown Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Krystian Matti", "Running Dropdown Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Krystian Matti", "Running Dropdown Page Test on Firefox")]
    class DropdownPageTest : BaseTest
    {
        private DropdownPage _dropDownPage;
        private MainPage _mainPage;

        public DropdownPageTest(Config.Browser browser, string author, string description) : base(browser)
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
            Assert.AreEqual(string.Empty, _dropDownPage.GetSelectValue());

            _dropDownPage.SelectJuicySelect("Polymer JavaScript library");
            Assert.AreEqual("You have selected: Polymer JavaScript library", _dropDownPage.JuicySelectLabel.Text);
            Assert.AreEqual("Polymer JavaScript library", _dropDownPage.GetSelectValue());

            _dropDownPage.SelectJuicySelect("Starcounter Database");
            Assert.AreEqual("You have selected: Starcounter Database", _dropDownPage.JuicySelectLabel.Text);
            Assert.AreEqual("Starcounter Database", _dropDownPage.GetSelectValue());

        }

        [Test]
        public void DropdownPage_Dropdown_SelectProduct()
        {
            WaitUntil(x => _dropDownPage.ProductSelect.Displayed);
            _dropDownPage.SelectProduct("Starcounter Database");
            Assert.AreEqual("You have selected: Starcounter Database", _dropDownPage.JuicySelectLabel.Text);
            Assert.AreEqual("Starcounter Database", _dropDownPage.GetJuicySelectValue());

            _dropDownPage.SelectProduct("Polymer JavaScript library");
            Assert.AreEqual("You have selected: Polymer JavaScript library", _dropDownPage.JuicySelectLabel.Text);
            Assert.AreEqual("Polymer JavaScript library", _dropDownPage.GetJuicySelectValue());

        }
    }
}

