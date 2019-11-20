using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup.Demo.Framework.Pages
{
    public class Pages
    {
        public RemoteWebDriver Driver { get; set; }

        public Pages(RemoteWebDriver driver)
        {
            Driver = driver;
        }

        public LoginPage Login => new LoginPage(Driver);
        public UserPage User => new UserPage(Driver);
    }
}
