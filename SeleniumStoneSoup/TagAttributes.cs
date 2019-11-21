using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStoneSoup
{
    public enum TagAttributes
    {
        [Description("id")]
        Id,

        [Description("name")]
        Name,

        [Description("class")]
        Class,

        [Description("value")]
        Value,

        [Description("onclick")]
        OnClick,

        [Description("src")]
        Src,

        [Description("title")]
        Title,

        [Description("href")]
        Href,

        [Description("type")]
        Type,

        [Description("style")]
        Style,

        [Description("rel")]
        Rel,

        [Description("data-policy-id")]
        DataPolicyId

    }
}
