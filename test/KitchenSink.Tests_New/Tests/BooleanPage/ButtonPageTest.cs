using NUnit.Framework;

namespace KitchenSink.Test.Boolean
{
    [TestFixture]
    class ButtonPageTest : BaseTest
    {
        [Test]
        public void ButtonPage_RegularButton()
        {
            MainPage mainPage = new MainPage(Driver);
            ButtonPage buttonPage = mainPage.GoToButtonPage();

            Assert.IsTrue(buttonPage.CheckRegularButtonLabelText("You don't have any carrots"));

            buttonPage.ClickButton1();
            Assert.IsTrue(buttonPage.CheckRegularButtonLabelText("You have 1 imaginary carrots"));
            buttonPage.ClickButton2();
            Assert.IsTrue(buttonPage.CheckRegularButtonLabelText("You have 2 imaginary carrots"));
            buttonPage.ClickSpan();
            Assert.IsTrue(buttonPage.CheckRegularButtonLabelText("You have 3 imaginary carrots"));
        }

        [Test]
        public void ButtonPage_SelfButton()
        {
            MainPage mainPage = new MainPage(Driver);
            ButtonPage buttonPage = mainPage.GoToButtonPage();

            //buttonPage.ClickSelfButton1();
            //Assert.IsTrue(buttonPage.CheckSelfButtonLabelText("Currently Regenerating!"));
            buttonPage.ClickSelfButton2();
            Assert.IsTrue(buttonPage.CheckSelfButtonLabelText("Currently Regenerating!"));
        }

        [Test]
        public void ButtonPage_SwitchButton()
        {
            MainPage mainPage = new MainPage(Driver);
            ButtonPage buttonPage = mainPage.GoToButtonPage();

            Assert.IsTrue(buttonPage.CheckSwitchButtonLabelText("Carrot engine is off"));

            buttonPage.ClickSwitchButton();
            Assert.IsTrue(buttonPage.CheckSwitchButtonLabelText("Carrot engine is on"));
            buttonPage.ClickSwitchButton();
            Assert.IsTrue(buttonPage.CheckSwitchButtonLabelText("Carrot engine is off"));
        }

        [Test]
        public void ButtonPage_DisabledButton()
        {
            MainPage mainPage = new MainPage(Driver);
            ButtonPage buttonPage = mainPage.GoToButtonPage();

            Assert.IsTrue(buttonPage.CheckDisableButtonLabelText("You don't have any carrots"));

            buttonPage.ClickDisableButton();
            Assert.IsTrue(buttonPage.CheckDisableButtonLabelText("You have 1 imaginary carrots"));
        }
    }
}
