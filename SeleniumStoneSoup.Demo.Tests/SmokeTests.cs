using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumStoneSoup.Framework;

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
