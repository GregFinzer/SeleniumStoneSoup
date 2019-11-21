using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumStoneSoup
{
    public static class IWebElementExtensions
    {
        private static readonly Regex whitespaces = new Regex(@"\s+", RegexOptions.Compiled);

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

        public static bool HasClass(this IWebElement element, string className)
        {
            return GetClasses(element).Contains(className);
        }

        public static List<string> GetClasses(this IWebElement element)
        {
            return whitespaces.Split(element.GetAttribute("class")).Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

        public static string GetAttribute(this IWebElement element, TagAttributes tagAttribute)
        {
            return element.GetAttribute(EnumHelper.GetEnumDescription(tagAttribute));
        }

        public static string ToDetailedString(this IWebElement element)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("- Tag: {0}", element.TagName);

            Point elementLocation = element.Location;
            builder.AppendLine().AppendFormat("- Location: {{X={0}, Y={1}}}", elementLocation.X, elementLocation.Y);

            Size elementSize = element.Size;
            builder.AppendLine().AppendFormat("- Size: {{Width={0}, Height={1}}}", elementSize.Width, elementSize.Height);

            string elementId = element.GetElementId();

            if (!string.IsNullOrEmpty(elementId))
                builder.AppendLine().AppendFormat("- Element ID: {0}", elementId);

            string elementText = element.Text?.Trim();

            if (!string.IsNullOrEmpty(elementText))
            {
                string elementTextSplitter = elementText.Contains(Environment.NewLine) ? Environment.NewLine : " ";
                builder.AppendLine().AppendFormat("- Text:{0}{1}", elementTextSplitter, elementText);
            }

            return builder.ToString();

        }

        public static string GetElementId(this IWebElement element)
        {
            PropertyInfo property = element.GetType().GetProperty(
                "Id",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            return property?.GetValue(element, new object[0]) as string;
        }

        public static string InnerHtml(this IWebElement webElement)
        {
            return webElement.GetAttribute("innerHTML");
        }

        public static string OuterHtml(this IWebElement webElement)
        {
            return webElement.GetAttribute("outerHTML");
        }
    }
}
