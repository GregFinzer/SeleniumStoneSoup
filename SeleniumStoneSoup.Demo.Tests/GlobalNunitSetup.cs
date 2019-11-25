using System.Diagnostics;
using System.IO;
using KellermanSoftware.Common;
using NUnit.Framework;
using SeleniumStoneSoup.Setup;

namespace SeleniumStoneSoup.Demo.Tests
{
    /// <summary>
    /// This will execute once for all the tests in the test project
    /// </summary>
    [SetUpFixture]
    public class GlobalNunitSetup
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            UiTestContext.Driver = TestDriverFactory.CreateDriver();
            UiTestContext.Extent = ExtentReportsFactory.CreateHtmlReporter(UiTestContext.Driver, FileUtil.GetCurrentDirectory());
        }

        [OneTimeTearDown]
        public virtual void FixtureCleanup()
        {
            WriteOutExtentReport();
            CloseBrowserDriver();
            ShowExtentReport();
        }

        private static void WriteOutExtentReport()
        {
            if (UiTestContext.Extent != null)
            {
                UiTestContext.Extent.Flush();
            }
        }

        private static void CloseBrowserDriver()
        {
            if (UiTestContext.Driver != null)
            {
                UiTestContext.Driver.Close();
                UiTestContext.Driver.Quit();
                UiTestContext.Driver = null;
            }
        }

        private static void ShowExtentReport()
        {
            string htmlFilePath = Path.Combine(FileUtil.GetCurrentDirectory(), "dashboard.html");
            ProcessUtil.Shell(htmlFilePath, string.Empty, ProcessWindowStyle.Maximized, false);
        }
    }
}
