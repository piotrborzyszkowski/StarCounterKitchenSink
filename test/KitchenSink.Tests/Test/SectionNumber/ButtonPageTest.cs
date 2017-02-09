using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionNumber;
using KitchenSink.Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace KitchenSink.Tests.Test.SectionNumber
{
    [TestFixture(Config.Browser.Chrome)]
    [TestFixture(Config.Browser.Edge)]
    [TestFixture(Config.Browser.Firefox)]
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
            WaitUntil(x => _buttonPage.VegetablesButtonInfoLabel.Displayed);
            Assert.AreEqual("You don't have any carrots", _buttonPage.VegetablesButtonInfoLabel.Text);

            WaitUntil(x => _buttonPage.ButtonInlineScript.Displayed);
            _buttonPage.ClickButtonInlineScript();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.VegetablesButtonInfoLabel, "You have 1 imaginary carrots")));

            WaitUntil(x => _buttonPage.ButtonFunction.Displayed);
            _buttonPage.ClickButtonFunction();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.VegetablesButtonInfoLabel, "You have 2 imaginary carrots")));

            WaitUntil(x => _buttonPage.SpanFunction.Displayed);
            _buttonPage.ClickSpanFunction();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.VegetablesButtonInfoLabel, "You have 3 imaginary carrots")));
        }

        [Test]
        public void ButtonPage_SelfButton()
        {
            _buttonPage.ClickButonTakeOneRegeneratingCarrot();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.TakeOneRegeneratingCarrotLabel, "Currently Regenerating!")));
        }

        [Test]
        public void ButtonPage_SwitchButton()
        {
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.EnableCarrotEngineLabel, "Carrot engine is off")));

            _buttonPage.ClickEnableCarrotEngine();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.EnableCarrotEngineLabel, "Carrot engine is on")));
            _buttonPage.ClickEnableCarrotEngine();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.EnableCarrotEngineLabel, "Carrot engine is off")));
        }

        [Test]
        public void ButtonPage_DisabledButton()
        {
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.AddCarrotsLabel,
                "You don't have any carrots")));
            _buttonPage.ClickButtonAddCarrots();
            Assert.IsTrue(WaitUntil(ExpectedConditions.TextToBePresentInElement(_buttonPage.AddCarrotsLabel,
                "You have 1 imaginary carrots")));
        }
    }
}
