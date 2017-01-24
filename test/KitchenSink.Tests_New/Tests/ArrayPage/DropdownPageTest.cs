using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.ArrayPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.ArrayPage
{
    [TestFixture]
    class DropdownPageTest : BaseTest
    {
        private DropdownPage _dropDownPage;
        private MainPage _mainPage;

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
            Assert.AreEqual("You like dogs", _dropDownPage.PetLikeLabel.Text);

            _dropDownPage.SelectPet("cats");
            Assert.AreEqual("You like cats", _dropDownPage.PetLikeLabel.Text);

            _dropDownPage.SelectPet("rabbit");
            Assert.AreEqual("You like rabbit", _dropDownPage.PetLikeLabel.Text);
        }

        [Test]
        public void DropdownPage_JuicyDropdown_SelectJuicy()
        {
            WaitUntil(x => _dropDownPage.JuicySelect.Displayed);
            _dropDownPage.SelectJuicy("Bread");
            Assert.AreEqual("You have selected: Bread", _dropDownPage.JuicySelectLabel.Text);
            Assert.AreEqual("Bread", _dropDownPage.GetJuicySelect2Value());

            _dropDownPage.SelectJuicy("Butter");
            Assert.AreEqual("You have selected: Butter", _dropDownPage.JuicySelectLabel.Text);
            Assert.AreEqual("Butter", _dropDownPage.GetJuicySelect2Value());

            _dropDownPage.SelectJuicy("Milk");
            Assert.AreEqual("You have selected: Milk", _dropDownPage.JuicySelectLabel.Text);
            Assert.AreEqual("Milk", _dropDownPage.GetJuicySelect2Value());
        }

        [Test]
        public void DropdownPage_JuicyDropdown_SelectAlko()
        {
            WaitUntil(x => _dropDownPage.JuicySelect.Displayed);
            _dropDownPage.SelectJuicy2("Irish Whiskey");
            Assert.AreEqual("You have selected: Irish Whiskey", _dropDownPage.JuicySelectLabel.Text);
            Assert.AreEqual("Irish Whiskey", _dropDownPage.GetJuicySelectValue());

            _dropDownPage.SelectJuicy2("Scotch Whisky");
            Assert.AreEqual("You have selected: Scotch Whisky", _dropDownPage.JuicySelectLabel.Text);
            Assert.AreEqual("Scotch Whisky", _dropDownPage.GetJuicySelectValue());

            _dropDownPage.SelectJuicy2("Boiled Mutton");
            Assert.AreEqual("You have selected: Boiled Mutton", _dropDownPage.JuicySelectLabel.Text);
            Assert.AreEqual("Boiled Mutton", _dropDownPage.GetJuicySelectValue());
        }
    }
}

