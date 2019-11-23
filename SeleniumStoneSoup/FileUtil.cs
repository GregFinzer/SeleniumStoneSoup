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
        public static string FilterFileName(string fileName)
        {
            return FilterFileName(fileName, false);
        }

        /// <summary>
        /// Returns a valid filename, ignoring invalid characters
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="allowSpaces">If false, spaces will be turned into underscores</param>
        /// <returns></returns>
        public static string FilterFileName(string fileName, bool allowSpaces)
        {
            StringBuilder sb = new StringBuilder(fileName.Length);
            string currentChar;
            string sInvalid = "";

            for (int i = 0; i < System.IO.Path.GetInvalidFileNameChars().GetUpperBound(0); i++)
                sInvalid += System.IO.Path.GetInvalidFileNameChars()[i].ToString();

            for (int i = 0; i < System.IO.Path.GetInvalidPathChars().GetUpperBound(0); i++)
                sInvalid += System.IO.Path.GetInvalidPathChars()[i].ToString();

            sInvalid += System.IO.Path.VolumeSeparatorChar.ToString();
            sInvalid += System.IO.Path.PathSeparator.ToString();
            sInvalid += System.IO.Path.DirectorySeparatorChar.ToString();
            sInvalid += System.IO.Path.AltDirectorySeparatorChar.ToString();

            for (int i = 0; i < fileName.Length; i++)
            {
                currentChar = fileName.Substring(i, 1);

                if (!allowSpaces && currentChar == " ")
                    currentChar = "_";

                if (currentChar == "," || currentChar == "'")
                {
                    currentChar = "";
                }
                else if (sInvalid.IndexOf(currentChar) < 0)
                    sb.Append(currentChar);
            }

            return sb.ToString();
        }

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
