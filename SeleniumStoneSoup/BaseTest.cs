using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SeleniumStoneSoup.Setup;

namespace SeleniumStoneSoup
{
    [TestFixture]
    public abstract class BaseTest
    {
        public IWebDriver Driver { get; set; }

        [OneTimeSetUp]
        public virtual void FixtureSetup()
        {
            Driver = new TestDriverFactory().CreateDriver();
        }

        [TearDown]
        public virtual void TestCleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                //TODO:  Reporting
                //TestContext.CurrentContext.Test.ClassName
                //TestContext.CurrentContext.Test.MethodName
            }
        }

        [OneTimeTearDown]
        public virtual void FixtureCleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Close();
            }
        }
    }
}
