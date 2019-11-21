using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStoneSoup
{
    public enum TagNames
    {
        [Description("textarea")]
        TextArea,

        [Description("input")]
        Input,

        [Description("a")]
        Link,

        [Description("span")]
        Span,

        [Description("iframe")]
        InlineFrame,

        [Description("div")]
        Div,

        [Description("img")]
        Image
    }
}
