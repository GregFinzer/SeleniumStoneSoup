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

        /// <summary>
        /// Extract Filename from a path
        /// </summary>
        /// <param name="fullPath">A fully qualified path ending in a filename</param>
        /// <returns>The extracted file name</returns>
        public static string ExtractFileName(string fullPath)
        {
            return System.IO.Path.GetFileName(fullPath);
        }

        /// <summary>
        /// Check to see if a file exists
        /// </summary>
        /// <param name="sPath">The file path</param>
        /// <returns>True if it exists</returns>
        public static bool FileExists(string sPath)
        {
            return System.IO.File.Exists(sPath);
        }
    }
}
