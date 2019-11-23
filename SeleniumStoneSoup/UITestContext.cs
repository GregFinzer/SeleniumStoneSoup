using System;
using AventStack.ExtentReports;
using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup
{
    public static class UiTestContext
    {
        [ThreadStatic] public static RemoteWebDriver Driver;
        [ThreadStatic] public static ExtentReports Extent;
    }
}
