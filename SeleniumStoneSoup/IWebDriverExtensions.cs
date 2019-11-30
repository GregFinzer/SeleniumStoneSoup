using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumStoneSoup
{
    public static class IWebDriverExtensions
    {
        [ThreadStatic]
        private static string _mainWindowHandler;

        public static IWebElement GetRadioByNameAndValue(this IWebDriver driver, string name, string value)
        {
            return driver.FindElement(By.XPath($"//input[@name='{name}' and @value='{value}']"));
        }

        public static void SetTimeField(this IWebDriver driver, IWebElement element, DateTime dateTime)
        {
            string time = dateTime.ToString("HH:mm:ss");
            SetValue(driver, element, time);
        }

        public static void SetDateField(this IWebDriver driver, IWebElement element, DateTime dateTime)
        {
            string isoDateString = dateTime.ToString("yyyy-MM-dd");
            SetValue(driver, element, isoDateString);
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

        public static bool ElementExists(this IWebDriver driver, By by)
        {
            return driver.FindElements(by).Count > 0;
        }

        public static bool TitleContains(this IWebDriver driver, string text)
        {
            return driver?.Title.ToLower().Contains(text.ToLower()) ?? false;
        }


        public static void NavigateBack(this IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public static void Refresh(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        public static void AlertAccept(this IWebDriver driver)
        {
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            driver.SwitchTo().DefaultContent();
        }

        public static void WaitReadyState(this IWebDriver driver)
        {
            var ready = new Func<bool>(() => (bool)ExecuteJavaScript(driver, "return document.readyState == 'complete'"));
            Contract.Assert(WaitHelper.SpinWait(ready, TimeSpan.FromSeconds(60), TimeSpan.FromMilliseconds(100)));
        }

        public static void WaitAjax(this IWebDriver driver)
        {
            var ready = new Func<bool>(() => (bool)ExecuteJavaScript(driver,"return (typeof($) === 'undefined') ? true : !$.active;"));
            Contract.Assert(WaitHelper.SpinWait(ready, TimeSpan.FromSeconds(60), TimeSpan.FromMilliseconds(100)));
        }

        public static Screenshot GetScreenshot(this IWebDriver driver)
        {
            WaitReadyState(driver);

            return ((ITakesScreenshot)driver).GetScreenshot();
        }

        public static void SaveScreenshot(this IWebDriver driver, string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);

            if (directory != null)
            {
                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            GetScreenshot(driver).SaveAsFile(filePath, ScreenshotImageFormat.Jpeg);
        }

        public static void SwitchToIFrame(this IWebDriver driver, IWebElement iFrame)
        {
            if (_mainWindowHandler == null)
                _mainWindowHandler = driver.CurrentWindowHandle;

            driver.SwitchTo().Frame(iFrame);
        }

        public static void SwitchToMainWindow(this IWebDriver driver)
        {
            if (_mainWindowHandler != null)
            {
                driver.SwitchTo().Window(_mainWindowHandler);
            }
        }

        public static void SwitchToDefaultContent(this IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public static void SwitchToPopupWindow(this IWebDriver driver)
        {
            if (_mainWindowHandler == null)
                _mainWindowHandler = driver.CurrentWindowHandle;

            foreach (var handle in driver.WindowHandles.Where(handle => handle != _mainWindowHandler)) // TODO:
            {
                driver.SwitchTo().Window(handle);
            }
        }

        public static object ExecuteJavaScript(this IWebDriver driver, string javaScript, params object[] args)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)driver;

            return javaScriptExecutor.ExecuteScript(javaScript, args);
        }

        public static void WaitUntilElementIsVisible(this IWebDriver I, By selector)
        {
            I.Wait().Until(d => d.FindElements(selector).Any());

            I.Wait().Until(d => d.FindElements(selector).ElementIsAttached());
        }

        public static void SetValue(this IWebDriver driver, IWebElement element, string value)
        {
            ExecuteJavaScript(driver,$"arguments[0].setAttribute('value', '{value}')", element);
        }

        public static WebDriverWait Wait(this IWebDriver driver, int timeout = 60)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
        }

        private static bool ElementIsAttached(this ICollection<IWebElement> elements)
        {
            try
            {
                elements.Any(d => d.Displayed);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetBodyText(this IWebDriver driver)
        {
            return driver.FindElement(By.TagName("body")).Text;
        }

        public static ReadOnlyCollection<IWebElement> GetAllElements(this IWebDriver driver)
        {
            return driver.FindElements(By.CssSelector("*"));
        }

        public static ReadOnlyCollection<IWebElement> GetElements(
            this IWebDriver driver,
            By by)
        {
            return driver.FindElements(by);
        }

        public static ReadOnlyCollection<IWebElement> GetAllInputElements(
            this IWebDriver driver,
            By by)
        {
            return driver.FindElements(By.TagName("input"));
        }

        public static IWebElement GetForm(this IWebDriver driver)
        {
            return driver.FindElements(By.TagName("form")).First();
        }

        public static IWebElement GetIFrame(this IWebDriver driver)
        {
            return driver.FindElements(By.TagName("iframe")).First();
        }
    }
}
