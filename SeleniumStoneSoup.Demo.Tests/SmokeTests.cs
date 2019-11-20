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
            Pages.Login.LoginValidUser();
        }

        [Test]
        public void CanFillInFormOnUserPage()
        {
            Pages.User.GoTo();
            Pages.User.FillForm();
        }
    }
}
