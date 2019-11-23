using NUnit.Framework;

namespace SeleniumStoneSoup.Demo.Framework
{
    public class BaseTest : BaseStoneSoupTest
    {
        public Demo.Framework.Pages.Pages Pages { get; set; }

        [SetUp]
        public void Initialize()
        {
            Pages = new Demo.Framework.Pages.Pages(this);
        }
    }
}
