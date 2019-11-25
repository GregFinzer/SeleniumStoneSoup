using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using KellermanSoftware.Common;
using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup.Setup
{
    public static class ExtentReportsFactory
    {
        public static ExtentReports CreateHtmlReporter(RemoteWebDriver driver, string folderPath)
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(folderPath);
            ExtentReports extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("MachineName", System.Environment.MachineName);
            extent.AddSystemInfo("Operating System", SystemInfo.GetOSVersion());
            extent.AddSystemInfo("CPU", SystemInfo.GetCPUInfo());
            extent.AddSystemInfo("Total RAM", SystemInfo.GetTotalRAM());
            extent.AddSystemInfo("Free Hard Drive Space", SystemInfo.GetFreeSpace(FileUtil.GetCurrentDriveLetter()));
            extent.AddSystemInfo("Driver", driver.GetType().FullName);
            return extent;
        }
    }
}
