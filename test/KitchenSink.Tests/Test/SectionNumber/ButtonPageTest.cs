using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionNumber;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionNumber
{
    [TestFixture(Config.Browser.Chrome, "Running Button Page Test on Chrome")]
    [TestFixture(Config.Browser.Edge, "Running Button Page Test on Edge")]
    [TestFixture(Config.Browser.Firefox, "Running Button Page Test on Firefox")]
    class ButtonPageTest : BaseTest
    {
        private ButtonPage _buttonPage;
        private MainPage _mainPage;

        public ButtonPageTest(Config.Browser browser) : base(browser)
        {
        }


        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _buttonPage = _mainPage.GoToButtonPage();
        }

        [Test]
        public void ButtonPage_RegularButton()
        {
            WaitUntil(x => _buttonPage.InfoLabel.Displayed);
            Assert.AreEqual("You don't have any carrots", _buttonPage.InfoLabel.Text);

            WaitUntil(x => _buttonPage.CarrotsButton1.Displayed);
            _buttonPage.ClickButton1();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.InfoLabel, "You have 1 imaginary carrots")));

            WaitUntil(x => _buttonPage.CarrotsButton2.Displayed);
            _buttonPage.ClickButton2();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.InfoLabel, "You have 2 imaginary carrots")));

            WaitUntil(x => _buttonPage.CarrotsSpan.Displayed);
            _buttonPage.ClickSpan();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.InfoLabel, "You have 3 imaginary carrots")));
        }

        [Test]
        public void ButtonPage_SelfButton()
        {
            _buttonPage.ClickSelfButton();
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
