﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SeleniumStoneSoup.Setup
{
    public static class WebDriverFactory
    {
        /// <summary>
        /// This method will create a local driver, as it takes the LocalDriver configuration object
        /// </summary>
        /// <param name="configuration">An instance of the LocalDriverConfiguration object.</param>
        /// <returns>Driver that meets the configuration</returns>
        public static IWebDriver Create(LocalDriverConfiguration configuration)
        {
            //A simple switch statement to determine which driver/service to create.
            switch (configuration.Browser)
            {
                case "headlesschrome":
                case "headless-chrome":
                case "chrome-headless":
                    var options = new ChromeOptions();
                    options.AddArgument("--headless");
                    return new ChromeDriver(options);
                case "chrome":
                    return new ChromeDriver();
                case "internet explorer":
                case "ie":
                    return new InternetExplorerDriver();
                    break;
                case "firefox":
                    return new FirefoxDriver();
                case "edge":
                    return new EdgeDriver();
                //If a string isn't matched, it will default to ChromeDriver
                default:
                    return new ChromeDriver();
            }
        }

        //TODO:  Remote later

        ///// <summary>
        ///// This method will create a remotedriver, as it takes the RemoteDriver configuration object
        ///// </summary>
        ///// <param name="configuration"></param>
        ///// <returns></returns>
        //public IWebDriver Create(RemoteDriverConfiguration configuration)
        //{
        //    //Will need to construct the remoteServerUri so it can be passed to the remoteWebDriver.
        //    var remoteServer = BuildRemoteServer(configuration.SeleniumHubUrl, configuration.SeleniumHubPort);

        //    switch (configuration.Browser)
        //    {
        //        //Switch on browser name
        //        //Create a DesiredCapabilities for the required driver.
        //        case "firefox":
        //            _capabilities = DesiredCapabilities.Firefox();
        //            break;

        //        case "chrome":
        //            _capabilities = DesiredCapabilities.Chrome();
        //            break;

        //        case "internet explorer":
        //            _capabilities = DesiredCapabilities.InternetExplorer();
        //            break;
        //    }

        //    //This method adds additional information to the desired capabilities, in this instance browser version and operating system.
        //    SetCapabilities(configuration.Platform, configuration.BrowserVersion);

        //    //We then create a new RemoteWebDriver with the Uri created earlier and the desired capabilities object.
        //    //This would then call your GRID instance and find a match and start the browser on the matching node.
        //    _driver = new RemoteWebDriver(new Uri(remoteServer), _capabilities);

        //    //Return the driver to the calling class.
        //    return _driver;
        //}

        ///// <summary>
        ///// Adds additional required capabilities to the desiredCapabilities object.
        ///// </summary>
        ///// <param name="platform">OS enum, conversation is done at Configuration level.</param>
        ///// <param name="browserVersion">Version number of browser, note that this is a string.</param>
        //private void SetCapabilities(PlatformType platform, string browserVersion)
        //{
        //    _capabilities.SetCapability(CapabilityType.Platform, new Platform(platform));
        //    _capabilities.SetCapability(CapabilityType.Version, browserVersion);
        //}

        ///// <summary>
        ///// Build a Uri for your GRID Hub instance
        ///// </summary>
        ///// <param name="remoteServer">The hostname or IP address of your GRID instance, include the http://</param>
        ///// <param name="remoteServerPort">Port of your GRID Hub instance</param>
        ///// <returns>The correct Uri as a string</returns>
        //private static string BuildRemoteServer(string remoteServer, int remoteServerPort)
        //{
        //    return string.Format("{0}:{1}/wd/hub", remoteServer, remoteServerPort);
        //}
    }
}
