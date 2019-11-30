using NUnit.Framework;
using OpenQA.Selenium;
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

        [Test]
        public void CanLoginInsideAnIFrame()
        {
            Pages.PageWithIFrame.GoTo();
            Pages.PageWithIFrame.IsOnPage();
            Pages.PageWithIFrame.HasExpectedTitle();
            Driver.WaitReadyState();
            IWebElement frame = Driver.GetIFrame();
            Driver.SwitchTo().Frame(frame);
            Driver.WaitReadyState();
            Pages.Login.LoginValidUser();
            Driver.WaitReadyState();
            Driver.FindElementByName("order");



        }

    }
}
