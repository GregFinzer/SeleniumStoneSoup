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
    }
}
