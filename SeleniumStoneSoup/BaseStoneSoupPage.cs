using System;
using System.Collections.Generic;
using System.Linq;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumStoneSoup.Setup;

namespace SeleniumStoneSoup
{
    public abstract class BaseStoneSoupPage
    {
        public abstract string Route { get; }
        public abstract string Title { get; }

        protected BaseStoneSoupPage(BaseStoneSoupTest baseStoneSoupTest)
        {
            Driver = baseStoneSoupTest.Driver;
            Test = baseStoneSoupTest;
        }

        public RemoteWebDriver Driver { get; set; }
        public BaseStoneSoupTest Test { get; set; }

        public virtual void GoTo()
        {
            string url = StringUtil.UrlCombineSafe(TestConfiguration.ApplicationUrl, Route);
            Driver.Navigate().GoToUrl(url);
            HasNoJavaScriptErrors();
        }

        public virtual void HasExpectedTitle()
        {
            if (!Driver.TitleContains(Title))
                throw new NoSuchElementException($"HasExpectedTitle failed. Driver.TitleContains does not contain: {Title}");

            Test.PassedStep("HasExpectedTitle: " + Title);
        }

        public virtual void IsOnPage()
        {
            if (!Driver.Url.ToLower().Contains(Route.ToLower()))
                throw new NoSuchElementException($"IsOnPage failed. Driver.Url.Contains(Route) does not contain: {Route}");

            Test.PassedStep("IsOnPage: " + Route);
        }

        public virtual void HasNoJavaScriptErrors()
        {
            var errorStrings = new List<string>
            {
                "SyntaxError",
                "EvalError",
                "ReferenceError",
                "RangeError",
                "TypeError",
                "URIError"
            };

            List<LogEntry> jsErrors = new List<LogEntry>();

            try
            {
                jsErrors = Driver.Manage().Logs.GetLog(LogType.Browser).Where(x => errorStrings.Any(e => x.Message.Contains(e))).ToList();
            }
            catch (Exception e)
            {
                Test.ExtentTest.Log(Status.Debug, "HasNoJavaScriptErrors driver cannot get the browser log");
                return;
            }

            if (jsErrors.Any())
            {
                Assert.Fail("JavaScript error(s):" + Environment.NewLine + jsErrors.Aggregate("", (s, entry) => s + entry.Message + Environment.NewLine));
            }

            Test.PassedStep("HasNoJavaScriptErrors");
        }
    }
}
