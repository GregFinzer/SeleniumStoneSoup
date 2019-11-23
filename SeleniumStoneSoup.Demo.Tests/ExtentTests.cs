using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using SeleniumStoneSoup.Demo.Framework;
namespace SeleniumStoneSoup.Demo.Tests
{
    public class ExtentTests : BaseTest
    {
        //[Test]
        //public void ExtentReportDemo()
        //{
        //    Pages.Login.GoTo();
        //    string path = Path.Combine(FileUtil.GetCurrentDirectory(), "etentReport.html");

        //    var htmlReporter = new ExtentHtmlReporter(path);
        //    var extent = new ExtentReports();
        //    extent.AttachReporter(htmlReporter);

        //    extent.AddSystemInfo("Operating System", SystemInfo.GetOperatingSystem());
        //    extent.AddSystemInfo("MachineName", System.Environment.MachineName);
        //    extent.AddSystemInfo("Driver", Driver.GetType().FullName);
        //    extent.AddSystemInfo("URL", Driver.Url);

        //    var test = extent.CreateTest(TestContext.CurrentContext.Test.ClassName + "." +
        //                                 TestContext.CurrentContext.Test.MethodName);
        //    test.Log(Status.Info, "Starting");
        //    test.Log(Status.Pass, "Example pass");
        //    test.Log(Status.Fail, "Example fail");

        //    TakeScreenShot("test.jpg");
        //    //test.Pass("ScreenShot", MediaEntityBuilder.CreateScreenCaptureFromPath(GetScreenShotPath("Test.jpg")).Build());
        //    test.Pass("ScreenShot").AddScreenCaptureFromPath(GetScreenShotPath("Test.jpg"));

        //    extent.Flush();

        //}
    }
}
