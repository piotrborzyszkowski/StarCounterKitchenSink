﻿using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class TextPageTest : BaseTest
    {
        [Test]
        public void TextPage_TextPropagationOnUnfocus()
        {
            //driver.Navigate().GoToUrl(baseURL + "/Text");
            //var label = driver.FindElement(ByHelper.AnyControlLabel);
            //var originalText = label.Text;
            //driver.FindElement(ByHelper.AnyInput).Clear();
            //driver.FindElement(ByHelper.AnyInput).SendKeys("Marcin");
            //driver.FindElement(ByHelper.AnyInput).SendKeys(Keys.Tab);
            //this.WaitUntil(x => !label.Text.Equals(originalText));
            //Assert.AreEqual("Hi, Marcin!", driver.FindElement(ByHelper.AnyControlLabel).Text);
        }

        [Test]
        public void TextPage_TextPropagationWhileTyping()
        {
            //driver.Navigate().GoToUrl(baseURL + "/Text");
            //var label = driver.FindElement(ByHelper.NthControlLabel(1));
            //var originalText = label.Text;
            //driver.FindElement(ByHelper.NthInput(1)).Clear();
            //driver.FindElement(ByHelper.NthInput(1)).SendKeys("M");
            //this.WaitUntil(x => !label.Text.Equals(originalText));
            //Assert.AreEqual("Hi, M!", driver.FindElement(ByHelper.NthControlLabel(1)).Text);
        }
    }
}
