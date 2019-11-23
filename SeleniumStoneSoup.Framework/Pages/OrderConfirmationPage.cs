namespace SeleniumStoneSoup.Demo.Framework.Pages
{
    public class OrderConfirmationPage : BaseStoneSoupPage
    {
        public OrderConfirmationPage(BaseStoneSoupTest test) : base(test)
        {
        }

        public override string Route => "Confirmed.html";
        public override string Title => "Order Confirmation";
    }
}
