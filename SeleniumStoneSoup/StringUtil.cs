using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStoneSoup
{
    public static class StringUtil
    {
        public static string UrlCombineSafe(string baseUrl, string url)
        {
            if (string.IsNullOrEmpty(baseUrl))
                return url;

            string result = string.Format("{0}/{1}", baseUrl.TrimEnd('/'), url.TrimStart('/'));

            if (!result.ToLower().StartsWith("http"))
            {
                result = "http://" + result;
            }

            return result;
        }
    }
}
