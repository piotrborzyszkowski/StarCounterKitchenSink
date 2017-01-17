using KitchenSink.Test;
using NUnit.Framework;

namespace KitchenSink.Tests
{ 
    [TestFixture]
    class DatapickerPageTest : BaseTest
    {
        [Test]
        public void DatapickerTest()
        {
            MainPage mainPage = new MainPage(Driver);
            DatepickerPage datePicker = mainPage.GoToDatePickerPage();
            datePicker.SelectDate("2016-01-01");

            Assert.AreEqual("2016", datePicker.GetYear());
            Assert.AreEqual("styczeń", datePicker.GetMonth());
            Assert.AreEqual("1", datePicker.GetDay());
        }
    }
}
