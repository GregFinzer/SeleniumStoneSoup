using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumStoneSoup
{
    public static class IWebDriverExtensions
    {
        public static IWebElement GetRadioByNameAndValue(this IWebDriver driver, string name, string value)
        {
            return driver.FindElement(By.XPath($"//input[@name='{name}' and @value='{value}']"));
        }

        public static void ScrollIntoView(this IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void DoubleClick(this IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.DoubleClick(element).Perform();
        }
    }
}
