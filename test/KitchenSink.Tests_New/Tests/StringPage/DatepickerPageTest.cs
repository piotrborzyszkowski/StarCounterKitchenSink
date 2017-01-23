using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.StringPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.StringPage
{
    [TestFixture]
    class DatepickerPageTest : BaseTest
    {
        private DatepickerPage _datePicker;

        [SetUp]
        public void SetUp()
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
