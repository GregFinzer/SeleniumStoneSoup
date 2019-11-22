using OpenQA.Selenium.Remote;

namespace SeleniumStoneSoup.Demo.Framework.Pages
{
    public class OrderConfirmationPage : BaseStoneSoupPage
    {
        public OrderConfirmationPage(RemoteWebDriver driver) : base(driver)
        {
        }

        public override string Route => "Confirmed.html";
        public override string Title => "Order Confirmation";
    }
}
