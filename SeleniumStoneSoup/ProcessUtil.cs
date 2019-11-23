using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStoneSoup
{
    public static class ProcessUtil
    {
        /// <summary>
        /// Execute an external program.
        /// </summary>
        /// <param name="sExecutablePath">Path and filename of the executable.</param>
        /// <param name="sArguments">Arguments to pass to the executable.</param>
        /// <param name="myWindowStyle">Window style for the process (hidden, minimized, maximized, etc).</param>
        /// <param name="bWaitUntilFinished">Wait for the process to finish.</param>
        /// <returns>Exit Code</returns>
        public static int Shell(string sExecutablePath, string sArguments, ProcessWindowStyle myWindowStyle, bool bWaitUntilFinished)
        {
            string sFileName = "";

            try
            {
                bool bDebug = false;
                Process p = new Process();
                string sAssemblyPath = FileUtil.PathSlash(FileUtil.GetCurrentDirectory()) + FileUtil.ExtractFileName(sExecutablePath);

                //Look for the file in the executing assembly directory
                if (FileUtil.FileExists(sAssemblyPath))
                {
                    sFileName = sAssemblyPath;
                    p.StartInfo.FileName = sAssemblyPath;
                }
                else // if there is no path to the file, an error will be thrown
                {
                    sFileName = sExecutablePath;
                    p.StartInfo.FileName = sExecutablePath;
                }

                p.StartInfo.Arguments = sArguments;

                if (bDebug)
                {
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                }
                else
                {
                    p.StartInfo.UseShellExecute = true;
                    p.StartInfo.WindowStyle = myWindowStyle;
                }

                //Start the Process
                p.Start();

                if (bWaitUntilFinished)
                {
                    p.WaitForExit();

                    while (!p.HasExited)
                        System.Threading.Thread.Sleep(500);
                }

                if (bWaitUntilFinished == true)
                    return p.ExitCode;
                else
                    return 0;
            }
            catch
            {
                string sMsg = "Shell Fail:  " + sFileName + "\n";
                sMsg += "Arguments:  " + sArguments;
                throw new Exception(sMsg);
            }
        }
    }
}
