using NUnit.Framework;

namespace KitchenSink.Test.Boolean
{
    [TestFixture]
    class CheckboxPageTest : BaseTest
    {
        [Test]
        public void CheckboxPage_CheckboxUncheckedAndCheckedAgain()
        {
            MainPage mainPage = new MainPage(Driver);
            CheckboxPage checkboxPage = mainPage.GoToCheckboxPage();

            if (checkboxPage.GetCheckboxState())
            {
                Assert.AreEqual("You can drive", checkboxPage.GetInfoLabelString());
                checkboxPage.ChangeCheckboxState();
                Assert.AreEqual("You can't drive", checkboxPage.GetInfoLabelString());
            }

            if (!checkboxPage.GetCheckboxState())
            {
                Assert.AreEqual("You can't drive", checkboxPage.GetInfoLabelString());
                checkboxPage.ChangeCheckboxState();
                Assert.AreEqual("You can drive", checkboxPage.GetInfoLabelString());
            }
        }
    }
}
