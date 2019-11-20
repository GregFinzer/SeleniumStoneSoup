using OpenQA.Selenium.Remote;
using SeleniumStoneSoup.Setup;

namespace SeleniumStoneSoup
{
    public abstract class BaseStoneSoupPage
    {
        public abstract string Route { get; }

        protected BaseStoneSoupPage(RemoteWebDriver driver)
        {
            Driver = driver;
        }

        public RemoteWebDriver Driver { get; set; }

        public virtual void GoTo()
        {
            string url = StringUtil.UrlCombineSafe(TestConfiguration.ApplicationUrl, Route);
            Driver.Navigate().GoToUrl(url);
        }

    }
}
