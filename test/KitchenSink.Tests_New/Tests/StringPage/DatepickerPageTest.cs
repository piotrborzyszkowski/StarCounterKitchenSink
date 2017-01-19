using NUnit.Framework;

namespace KitchenSink.Test.String
{
    [TestFixture]
    class DatepickerPageTest : BaseTest
    {
        private DatepickerPage _datePicker;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var mainPage = new MainPage(Driver);
            _datePicker = mainPage.GoToDatePickerPage();
        }

        [Test]
        public void DatepickerPage_SelectDate()
        {
            WaitUntil(x => _datePicker.DatePicker.Displayed);

            _datePicker.SelectDate("2016-01-01");

            Assert.AreEqual("2016", _datePicker.GetYear());
            Assert.AreEqual("January", _datePicker.GetMonth());
            Assert.AreEqual("1", _datePicker.GetDay());
        }
    }
}
