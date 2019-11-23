using System;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup
{
    [TestFixture]
    public abstract class BaseStoneSoupTest
    {
        public RemoteWebDriver Driver => UiTestContext.Driver;
        public ExtentReports Extent => UiTestContext.Extent;
        public ExtentTest ExtentTest { get; set; }


        [SetUp]
        public void TestInitialize()
        {
            ExtentTest = Extent.CreateTest(TestContext.CurrentContext.Test.ClassName + "." +
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
                ExtentTest.Pass("Passing ScreenShot").AddScreenCaptureFromPath(GetScreenShotPath());
            }
        }

        public void PassedStep(string message)
        {
            ExtentTest.Log(Status.Pass, message);
        }

        public void FailedStep(string message)
        {
            ExtentTest.Log(Status.Fail, message);
        }

        public void PassedStepScreenShot(string message)
        {
            string classMethod = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.MethodName}";
            string fileName = $"{classMethod}_{FileUtil.FilterFileName(message)}";
            TakeScreenShot(fileName);
            ExtentTest.Log(Status.Pass, message).AddScreenCaptureFromPath(GetScreenShotPath(fileName));
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
                string classMethod = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.MethodName}";
                
                return Path.Combine(FileUtil.GetCurrentDirectory(),
                    "Screenshots",
                    $"{classMethod}.jpg");
            }

            return Path.Combine(FileUtil.GetCurrentDirectory(),
                "Screenshots",
                $"{screenShotName}.jpg");
        }


    }
}
