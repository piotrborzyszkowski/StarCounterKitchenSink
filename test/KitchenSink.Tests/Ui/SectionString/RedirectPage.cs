﻿using KitchenSink.Tests.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests.Ui.SectionString
{
    public class RedirectPage : BasePage
    {
        public RedirectPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-fruit__button")]
        public IWebElement FruitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-vegetable__button")]
        public IWebElement VegetableButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-bread__button")]
        public IWebElement BreadButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-favourite-food__label")]
        public IWebElement InfoLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-morph__button")]
        public IWebElement MorphButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".kitchensink-test-redirect__button")]
        public IWebElement RedirectButton { get; set; }

        public void ClickButton(Config.Buttons button)
        {
            switch (Config.ButtonsDictionary[button])
            {
                case "Bread":
                    ClickOn(BreadButton); break;
                case "Vegetable":
                    ClickOn(VegetableButton); break;
                case "Fruit":
                    ClickOn(FruitButton); break;
                case "Morph":
                    ClickOn(MorphButton); break;
                case "Redirect":
                    ClickOn(RedirectButton); break;
            }
        }
    }
}