using NUnit.Framework;

namespace SeleniumStoneSoup.Framework
{
    public class BaseTest : BaseStoneSoupTest
    {
        public Pages.Pages Pages { get; set; }

        [SetUp]
        public void Initialize()
        {
            Pages = new Pages.Pages(Driver);
        }
    }
}
