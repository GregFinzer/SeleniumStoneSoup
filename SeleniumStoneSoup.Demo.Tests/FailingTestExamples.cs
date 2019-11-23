using NUnit.Framework;
using SeleniumStoneSoup.Demo.Framework;

namespace SeleniumStoneSoup.Demo.Tests
{
    [TestFixture]
    public class FailingTestExamples : BaseTest
    {
        [Test]
        public void FailingTest()
        {
            Pages.Login.GoTo();
            Driver.FindElementById("SomeElementThatDoesNotExist");
        }
    }
}
