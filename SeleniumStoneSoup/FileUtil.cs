using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStoneSoup
{
    public static class FileUtil
    {
        public static string GetCurrentDirectory()
        {
#if NETSTANDARD
            string basePath = AppContext.BaseDirectory;
#else
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
#endif
            return PathSlash(basePath);
        }

        public static String PathSlash(string path)
        {
            string separator = Convert.ToString(Path.DirectorySeparatorChar);

            if (path.Length == 0)
                return path;
            if (path.EndsWith(separator))
                return path;

            return path + separator;
        }
    }
}
