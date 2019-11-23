using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumStoneSoup.Demo.Framework;
using SeleniumStoneSoup.Setup;


namespace SeleniumStoneSoup.Tests
{
    [TestFixture]
    public class BaseStoneSoupTestTests : BaseTest
    {
        [Test]
        public void CanTakeScreenshot()
        {
            //Arrange
            string url = StringUtil.UrlCombineSafe(TestConfiguration.ApplicationUrl, "Login.html");
            Driver.Navigate().GoToUrl(url);

            //Act
            TakeScreenShot();
            string filePath = GetScreenShotPath();

            //Assert
            Assert.IsTrue(File.Exists(filePath));

            DeleteScreenShot();
        }
    }
}
