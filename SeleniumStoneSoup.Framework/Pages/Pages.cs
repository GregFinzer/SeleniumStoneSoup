namespace SeleniumStoneSoup.Demo.Framework.Pages
{
    public class Pages
    {
        public BaseStoneSoupTest Test { get; set; }

        public Pages(BaseStoneSoupTest test)
        {
            Test = test;
        }

        public LoginPage Login => new LoginPage(Test);
        public OrderPage Order => new OrderPage(Test);
        public OrderConfirmationPage OrderConfirmation => new OrderConfirmationPage(Test);
        public PageWithIFrame PageWithIFrame => new PageWithIFrame(Test);
    }
}
