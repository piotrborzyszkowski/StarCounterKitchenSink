using NUnit.Framework;

namespace KitchenSink.Test.Array
{
    [TestFixture]
    class DropdownPageTest : BaseTest
    {
        [Test]
        public void PetsDropdown_SelectPets()
        {
            MainPage mainPage = new MainPage(Driver);
            DropdownPage dropDownPage = mainPage.GoToDropdownPage();

            dropDownPage.SelectPet("dogs");
            Assert.AreEqual("You like dogs", dropDownPage.petLikeLabel.Text);

            dropDownPage.SelectPet("cats");
            Assert.AreEqual("You like cats", dropDownPage.petLikeLabel.Text);

            dropDownPage.SelectPet("rabbit");
            Assert.AreEqual("You like rabbit", dropDownPage.petLikeLabel.Text);
        }

        [Test]
        public void JuicyDropdown_SelectJuicy()
        {
            MainPage mainPage = new MainPage(Driver);
            DropdownPage dropDownPage = mainPage.GoToDropdownPage();

            dropDownPage.SelectJuicy("Bread");
            Assert.AreEqual("You have selected: Bread", dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Bread", dropDownPage.GetJuicySelect2Value());

            dropDownPage.SelectJuicy("Butter");
            Assert.AreEqual("You have selected: Butter", dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Butter", dropDownPage.GetJuicySelect2Value());

            dropDownPage.SelectJuicy("Milk");
            Assert.AreEqual("You have selected: Milk", dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Milk", dropDownPage.GetJuicySelect2Value());
        }

        [Test]
        public void JuicyDropdown_SelectAlko()
        {
            MainPage mainPage = new MainPage(Driver);
            DropdownPage dropDownPage = mainPage.GoToDropdownPage();

            dropDownPage.SelectJuicy2("Irish Whiskey");
            Assert.AreEqual("You have selected: Irish Whiskey", dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Irish Whiskey", dropDownPage.GetJuicySelectValue());

            dropDownPage.SelectJuicy2("Scotch Whisky");
            Assert.AreEqual("You have selected: Scotch Whisky", dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Scotch Whisky", dropDownPage.GetJuicySelectValue());

            dropDownPage.SelectJuicy2("Boiled Mutton");
            Assert.AreEqual("You have selected: Boiled Mutton", dropDownPage.juicySelectLabel.Text);
            Assert.AreEqual("Boiled Mutton", dropDownPage.GetJuicySelectValue());
        }
    }
}

