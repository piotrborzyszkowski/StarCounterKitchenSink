using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class DatepickerPageTest : BaseTest
    {
        [Test]
        public void Datepicker_SelectDate()
        {
            MainPage mainPage = new MainPage(Driver);
            DatepickerPage datePicker = mainPage.GoToDatePickerPage();
            datePicker.SelectDate("2016-01-01");

            Assert.AreEqual("2016", datePicker.GetYear());
            Assert.AreEqual("January", datePicker.GetMonth());
            Assert.AreEqual("1", datePicker.GetDay());
        }
    }
}
