using KitchenSink.Tests.Ui;
using KitchenSink.Tests.Ui.SectionObject;
using NUnit.Framework;

namespace KitchenSink.Tests.Test.SectionObject
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
            WaitUntil(x => _nestedPartialsPage.ChildDivs.Count > 0);
            var divsBefore = _nestedPartialsPage.ChildDivs.Count;
            _nestedPartialsPage.AddChild();
            WaitUntil(x => _nestedPartialsPage.ChildDivs.Count > divsBefore);
            var divsAfter = _nestedPartialsPage.ChildDivs.Count;

            Assert.Greater(divsAfter, divsBefore);
        }
    }
}
