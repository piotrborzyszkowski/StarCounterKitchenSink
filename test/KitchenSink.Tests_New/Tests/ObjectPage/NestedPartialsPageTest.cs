using KitchenSink.Tests_New.Ui;
using KitchenSink.Tests_New.Ui.ObjectPage;
using NUnit.Framework;

namespace KitchenSink.Tests_New.Tests.ObjectPage
{
    [TestFixture]
    class NestedPartialsPageTest : BaseTest
    {
        private NestedPartialsPage _nestedPartialsPage;
        private MainPage _mainPage;

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPage(Driver).GoToMainPage();
            _nestedPartialsPage = _mainPage.GoToNestedPartialsPage();
        }

        [Test]
        public void NestedPartialsPage_AddNewChild()
        {
            WaitUntil(x => _nestedPartialsPage.CountChildDivs() > 0);
            var divsBefore = _nestedPartialsPage.CountChildDivs();
            _nestedPartialsPage.AddChild();
            WaitUntil(x => _nestedPartialsPage.CountChildDivs() > divsBefore);
            var divsAfter = _nestedPartialsPage.CountChildDivs();

            Assert.Greater(divsAfter, divsBefore);
        }
    }
}
