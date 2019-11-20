using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup.Demo.Framework.Pages
{
    public class UserPage : BaseStoneSoupPage
    {
        public UserPage(RemoteWebDriver driver) : base(driver)
        {
        }

        public IWebElement TitleDropDown => Driver.FindElementById("TitleId");
        public IWebElement FirstNameTextBox => Driver.FindElementByName("FirstName");
        public IWebElement LastNameTextBox => Driver.FindElementByName("LastName");

        public IWebElement SaveButton => Driver.FindElementByName("Save");

        public override string Route => "index.html";

        public void FillForm()
        {
            TitleDropDown.SelectDropdownByText("Mrs.");
            FirstNameTextBox.SetText("Jennifer");
            LastNameTextBox.SetText("Lopez");

            SaveButton.Click();
        }
    }
}
