using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Test.Boolean
{
    [TestFixture]
    class ButtonPageTest : BaseTest
    {
        private ButtonPage _buttonPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mainPage = new MainPage(Driver);
            _buttonPage = mainPage.GoToButtonPage();
        }

        [Test]
        public void ButtonPage_RegularButton()
        {

            Assert.AreEqual("You don't have any carrots", _buttonPage.InfoLabel.Text);

            _buttonPage.ClickButton1();
            Assert.AreEqual("You have 1 imaginary carrots", _buttonPage.InfoLabel.Text);
            _buttonPage.ClickButton2();
            Assert.AreEqual("You have 2 imaginary carrots", _buttonPage.InfoLabel.Text);
            _buttonPage.ClickSpan();
            Assert.AreEqual("You have 3 imaginary carrots", _buttonPage.InfoLabel.Text);
        }

        [Test]
        public void ButtonPage_SelfButton()
        {
            //_buttonPage.ClickSelfButton1();
            //Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.SelfButtonLabel, "Currently Regenerating!")));
            _buttonPage.ClickSelfButton2();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.SelfButtonLabel, "Currently Regenerating!")));
        }

        [Test]
        public void ButtonPage_SwitchButton()
        {
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.SwitchButtonLabel, "Carrot engine is off")));

            _buttonPage.ClickSwitchButton();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.SwitchButtonLabel, "Carrot engine is on")));
            _buttonPage.ClickSwitchButton();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.SwitchButtonLabel, "Carrot engine is off")));
        }

        [Test]
        public void ButtonPage_DisabledButton()
        {
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.DisableButtonLabel,
                "You don't have any carrots")));
            _buttonPage.ClickDisableButton();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.DisableButtonLabel,
                "You have 1 imaginary carrots")));
        }
    }
}
