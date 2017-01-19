using NUnit.Framework;

namespace KitchenSink.Test.Array
{
    [TestFixture]
    class DropdownPageTest : BaseTest
    {
        private DropdownPage _dropDownPage;

        [OneTimeSetUp]
        public void OnteTimeSetUp()
        {
            var mainPage = new MainPage(Driver);
            _dropDownPage = mainPage.GoToDropdownPage();
        }

        [Test]
        public void DropdownPage_PetsDropdown_SelectPets()
        {
            WaitUntil(x => _dropDownPage.petsSelect.Displayed);
            _dropDownPage.SelectPet("dogs");
            Assert.AreEqual("You like dogs", _dropDownPage.petLikeLabel.Text);

            _dropDownPage.SelectPet("cats");
            Assert.AreEqual("You like cats", _dropDownPage.petLikeLabel.Text);

            _dropDownPage.SelectPet("rabbit");
            Assert.AreEqual("You like rabbit", _dropDownPage.petLikeLabel.Text);
        }

        [Test]
        public void DropdownPage_JuicyDropdown_SelectJuicy()
        {
            WaitUntil(x => _dropDownPage.juicySelect.Displayed);
            _dropDownPage.SelectJuicy("Bread");
            Assert.AreEqual("You have selected: Bread", _dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Bread", _dropDownPage.GetJuicySelect2Value());

            _dropDownPage.SelectJuicy("Butter");
            Assert.AreEqual("You have selected: Butter", _dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Butter", _dropDownPage.GetJuicySelect2Value());

            _dropDownPage.SelectJuicy("Milk");
            Assert.AreEqual("You have selected: Milk", _dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Milk", _dropDownPage.GetJuicySelect2Value());
        }

        [Test]
        public void DropdownPage_JuicyDropdown_SelectAlko()
        {
            WaitUntil(x => _dropDownPage.juicySelect2.Displayed);
            _dropDownPage.SelectJuicy2("Irish Whiskey");
            Assert.AreEqual("You have selected: Irish Whiskey", _dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Irish Whiskey", _dropDownPage.GetJuicySelectValue());

            _dropDownPage.SelectJuicy2("Scotch Whisky");
            Assert.AreEqual("You have selected: Scotch Whisky", _dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Scotch Whisky", _dropDownPage.GetJuicySelectValue());

            _dropDownPage.SelectJuicy2("Boiled Mutton");
            Assert.AreEqual("You have selected: Boiled Mutton", _dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Boiled Mutton", _dropDownPage.GetJuicySelectValue());
        }
    }
}

