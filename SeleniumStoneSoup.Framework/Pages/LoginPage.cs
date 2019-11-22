using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup.Demo.Framework.Pages
{
    public class LoginPage : BaseStoneSoupPage
    {
        public LoginPage(RemoteWebDriver driver) : base(driver)
        {
        }

        public IWebElement UserNameTextbox => Driver.FindElementById("userName");
        public IWebElement PasswordTextbox => Driver.FindElementById("password");
        public IWebElement LoginButton => Driver.FindElementByName("login");

        public override string Route => "Login.html";
        public override string Title => "Login";

        public void LoginValidUser()
        {
            UserNameTextbox.SetText("bradgillis@bradgillis.com");
            PasswordTextbox.SetText("secret");
            LoginButton.Submit();
        }
    }
}
