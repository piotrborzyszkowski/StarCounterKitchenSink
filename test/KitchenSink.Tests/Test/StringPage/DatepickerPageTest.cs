using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.StringPage;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.StringPage
{
    [TestFixture]
    class DatepickerPageTest : BaseTest
    {
        private DatepickerPage _datePicker;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _datePicker = _mainPage.GoToDatePickerPage();
        }

        [Test]
        public void DatepickerPage_SelectDate()
        {
            WaitUntil(x => _datePicker.DatePicker.Displayed);

            _datePicker.SelectDate("2016-01-01");

            Assert.AreEqual("2016", _datePicker.YearInput.GetAttribute("value"));
            Assert.AreEqual("January", _datePicker.MonthInput.GetAttribute("value"));
            Assert.AreEqual("1", _datePicker.DayInput.GetAttribute("value"));
        }
    }
}
