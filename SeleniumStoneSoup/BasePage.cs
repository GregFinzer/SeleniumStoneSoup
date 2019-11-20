using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup
{
    public abstract class BasePage
    {
        protected BasePage(RemoteWebDriver driver)
        {
            Driver = driver;
        }

        public RemoteWebDriver Driver { get; set; }

    }
}
