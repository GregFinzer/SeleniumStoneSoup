using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStoneSoup.Demo.Framework.Pages
{
    public class PageWithIFrame : BaseStoneSoupPage
    {
        public PageWithIFrame(BaseStoneSoupTest baseStoneSoupTest) : base(baseStoneSoupTest)
        {
        }

        public override string Route => "PageWithIFrame.html";
        public override string Title => "Page With iFrame";
    }
}
