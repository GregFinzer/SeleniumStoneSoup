using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup.Framework.Pages
{
    public class LoginPage : BaseStoneSoupPage
    {
        public LoginPage(RemoteWebDriver driver) : base(driver)
        {
        }

        public IWebElement UserNameTextbox => Driver.FindElementByName("UserName");
        public IWebElement PasswordTextbox => Driver.FindElementByName("Password");
        public IWebElement LoginButton => Driver.FindElementByName("Login");

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
        }

        public void LoginValidUser()
        {
            UserNameTextbox.SetText("jdoe");
            PasswordTextbox.SetText("secret");
            LoginButton.Submit();
        }
    }
}
