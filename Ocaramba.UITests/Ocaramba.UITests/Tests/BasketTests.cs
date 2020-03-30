// NUnit 3 tests
// See documentation : https://github.com/ObjectivityLtd/Ocaramba 

using System.Globalization;
using Allegro.AcceptanceTests.PageObjects;
using NUnit.Framework;

namespace Allegro.AcceptanceTests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class BasketTests : ProjectTestBase
    {
        [Test, Description("Test that add item to cart and checks that the item is indeed in a cart")]
        public void AddToBasketTest()
        {

            var homePage = new MainPage(this.DriverContext);
            homePage.OpenHomePage();
            homePage.AcceptDataConsent();
            var resultsPage = homePage.SearchForProduct("rower");
            resultsPage.ClickOnSecondHandCbx();
            resultsPage.EnterPriceFrom(201);
            var itemPage = resultsPage.ClickItem(0);
            
            var expected = itemPage.GetItemTitle();
            
            itemPage.ClickAddToCart();
            var basketPage = itemPage.ClickGoToCart();

            var actual = basketPage.GetFirstItemName();

            Assert.AreEqual(expected, actual);
        }
    }
}
