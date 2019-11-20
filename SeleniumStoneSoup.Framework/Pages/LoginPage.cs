using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup.Demo.Framework.Pages
{
    public class LoginPage : BaseStoneSoupPage
    {
        public LoginPage(RemoteWebDriver driver) : base(driver)
        {
        }

        public IWebElement UserNameTextbox => Driver.FindElementByName("UserName");
        public IWebElement PasswordTextbox => Driver.FindElementByName("Password");
        public IWebElement LoginButton => Driver.FindElementByName("Login");

        public override string Route
        {
            get
            {
                return "login.html";
            }
        }

        public void LoginValidUser()
        {
            UserNameTextbox.SetText("jdoe");
            PasswordTextbox.SetText("secret");
            LoginButton.Submit();
        }
    }
}
