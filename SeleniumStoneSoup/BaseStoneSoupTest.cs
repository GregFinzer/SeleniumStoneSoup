using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using MongoDB.Driver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using SeleniumStoneSoup.Setup;

namespace SeleniumStoneSoup
{
    [TestFixture]
    public abstract class BaseStoneSoupTest
    {
        public RemoteWebDriver Driver => UiTestContext.Driver;

        public ExtentTest ExtentTest { get; set; }


        [SetUp]
        public void BaseInitialize()
        {
            ExtentTest = UiTestContext.Extent.CreateTest(TestContext.CurrentContext.Test.ClassName + "." +
                                                         TestContext.CurrentContext.Test.MethodName);
        }

        [TearDown]
        public virtual void TestCleanup()
        {
            TakeScreenShot();

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string message = TestContext.CurrentContext.Result.Message + Environment.NewLine
                                                                           + TestContext.CurrentContext.Result
                                                                               .StackTrace;

                ExtentTest.Fail(message).AddScreenCaptureFromPath(GetScreenShotPath());
            }
            else
            {
                ExtentTest.Pass("ScreenShot").AddScreenCaptureFromPath(GetScreenShotPath());
            }
        }

        public void DeleteScreenShot(string screenShotName = "")
        {
            string filePath = GetScreenShotPath(screenShotName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public void TakeScreenShot(string screenshotName = "")
        {
            Driver.SaveScreenshot(GetScreenShotPath(screenshotName));
        }

        public string GetScreenShotPath(string screenShotName = "")
        {
            if (String.IsNullOrEmpty(screenShotName))
            {
                return Path.Combine(FileUtil.GetCurrentDirectory(),
                    "Screenshots",
                    $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.MethodName}.jpg");
            }

            return Path.Combine(FileUtil.GetCurrentDirectory(),
                "Screenshots",
                $"{screenShotName}.jpg");
        }

        //[OneTimeTearDown]
        //public virtual void FixtureCleanup()
        //{
        //    if (Driver != null)
        //    {
        //        Driver.Close();
        //        Driver.Quit();
        //    }
        //}
    }
}
