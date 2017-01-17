using NUnit.Framework;

namespace KitchenSink.Test.Object
{
    [TestFixture]
    class NestedPartialsPageTest : BaseTest
    {
        [Test]
        public void NestedPartialsTest()
        {
            MainPage mainPage = new MainPage(Driver);
            NestedPartialsPage nestedPartialsPage = mainPage.GoToNestedPartialsPage();

            var divsBefore = nestedPartialsPage.CountChildDivs();
            nestedPartialsPage.AddChild();
            var divsAfter = nestedPartialsPage.CountChildDivs();

            Assert.Greater(divsAfter, divsBefore);
        }
    }
}
