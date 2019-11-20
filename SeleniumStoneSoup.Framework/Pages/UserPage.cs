using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup.Framework.Pages
{
    public class UserPage : BaseStoneSoupPage
    {
        public UserPage(RemoteWebDriver driver) : base(driver)
        {
        }

        public IWebElement TitleDropDown => Driver.FindElementById("TitleId");
        public IWebElement InitialTextBox => Driver.FindElementByName("Initial");
        public IWebElement FirstNameTextBox => Driver.FindElementByName("FirstName");
        public IWebElement MiddleNameTextBox => Driver.FindElementByName("MiddleName");

        public IWebElement SaveButton => Driver.FindElementByName("Save");

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=&Password=&Login=Login");
        }

        public void FillForm()
        {
            TitleDropDown.SelectDropdown("Ms.");
            InitialTextBox.SetText("Lady");
            FirstNameTextBox.SetText("Christy");
            MiddleNameTextBox.SetText("Ann");

            SaveButton.Click();
        }
    }
}
