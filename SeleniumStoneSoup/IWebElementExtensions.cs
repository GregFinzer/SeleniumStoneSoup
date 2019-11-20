using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumStoneSoup
{
    public static class IWebElementExtensions
    {
        public static void SetText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string GetDropdownValue(IWebElement element)
        {
            var selectedOptions = new SelectElement(element).AllSelectedOptions;

            if (!selectedOptions.Any())
                return string.Empty;

            return selectedOptions.First().GetAttribute("value");
        }

        public static void SelectDropdownByText(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        public static void SelectDropdownByValue(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByValue(value);
            
        }


    }
}
