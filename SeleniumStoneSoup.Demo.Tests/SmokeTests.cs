using NUnit.Framework;
using SeleniumStoneSoup.Demo.Framework;

namespace SeleniumStoneSoup.Demo.Tests
{
    public class SmokeTests : BaseTest
    {
        [Test]
        public void CanLogin()
        {
            Pages.Login.GoTo();
            Pages.Login.IsOnPage();
            Pages.Login.HasExpectedTitle();
            Pages.Login.LoginValidUser();
            Pages.Order.IsOnPage();
        }

        [Test]
        public void CanOrder()
        {
            Pages.Login.GoTo();
            Pages.Login.LoginValidUser();
            Pages.Order.OrderLoadedPotatoSoup();
            Pages.OrderConfirmation.IsOnPage();
        }

    }
}
