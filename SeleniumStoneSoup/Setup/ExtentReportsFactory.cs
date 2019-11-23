using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
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
            extent.AddSystemInfo("Operating System", SystemInfo.GetOperatingSystem());
            extent.AddSystemInfo("MachineName", System.Environment.MachineName);
            extent.AddSystemInfo("Driver", driver.GetType().FullName);
            return extent;
        }
    }
}
