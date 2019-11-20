using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumStoneSoup
{
    public static class IWebElementExtensions
    {
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string GetDropdownText(IWebElement element)
        {
            var selectedOptions = new SelectElement(element).AllSelectedOptions;

            if (!selectedOptions.Any())
                return string.Empty;

            return selectedOptions.First().Text;
        }

        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public static void SelectDropdown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }
    }
}
