using System;
using OpenQA.Selenium;

namespace SeleniumStoneSoup.Demo.Framework.Pages
{
    public class OrderPage : BaseStoneSoupPage
    {
        public OrderPage(BaseStoneSoupTest test) : base(test)
        {
        }

        public IWebElement MenuItem => Driver.FindElementById("menuItem");
        public IWebElement Quantity => Driver.FindElementById("quantity");
        public IWebElement SpicyLevel => Driver.FindElementById("spicyLevel");
        public IWebElement Birthday => Driver.FindElementById("birthday");
        public IWebElement FavoriteColor => Driver.FindElementById("favoriteColor");
        public IWebElement FacebookPage => Driver.FindElementById("facebookPage");
        public IWebElement SexMale => Driver.GetRadioByNameAndValue("sex", "male");
        public IWebElement SexFemale => Driver.GetRadioByNameAndValue("sex", "female");
        public IWebElement Agree => Driver.FindElementById("agree");
        public IWebElement OrderTime => Driver.FindElementById("orderTime");
        public IWebElement Phone => Driver.FindElementById("phone");
        public IWebElement Email => Driver.FindElementById("email");
        public IWebElement Address => Driver.FindElementById("address");
        public IWebElement ZipCode => Driver.FindElementById("zipCode");
        public IWebElement DriverNotes => Driver.FindElementById("driverNotes");
        public IWebElement SubmitOrder => Driver.FindElementById("submitOrder");

        public override string Route => "Order.html";
        public override string Title => "Order";

        public void OrderLoadedPotatoSoup()
        {
            FillInOrderSection();
            FillInBirthdaySection();
            FillInDeliveryInformation();
            Test.PassedStepScreenShot("Before Submit");
            SubmitOrder.Submit();
        }

        private void FillInDeliveryInformation()
        {
            Driver.SetTimeField(OrderTime, DateTime.Today.AddHours(12).AddMinutes(30));

            Phone.SetText("3108675309");
            Email.SetText("bradgillis@bradgillis.com");
            Address.SetText("4 Sentimental Street");
            ZipCode.SetText("90210");
            DriverNotes.SetText("The password for the gated community is 5309");
            Test.PassedStep("FillInDeliveryInformation");
        }

        private void FillInBirthdaySection()
        {
            Driver.SetDateField(Birthday, new DateTime(1957, 6,15));

            Driver.SetValue(FavoriteColor, "#8000ff");
            FacebookPage.SetText("https://www.facebook.com/brad.gillis.125");
            SexMale.Click();
            Agree.Click();
            Test.PassedStep("FillInBirthdaySection");
        }

        private void FillInOrderSection()
        {
            MenuItem.SelectDropdownByText("We will Rock you Loaded Potato Cheese Soup");
            Quantity.SetText("2");
            SpicyLevel.SetText("5");
            Test.PassedStep("FillInOrderSection");
        }
    }
}
