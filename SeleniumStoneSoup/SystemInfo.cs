using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SeleniumStoneSoup
{
    public static class SystemInfo
    {

        public static string GetOperatingSystem()
        {
            string results = "Unknown OS: " + System.Environment.OSVersion.ToString();

            try
            {
                // Get OperatingSystem information from the system namespace.
                System.OperatingSystem osInfo = System.Environment.OSVersion;

                // Determine the platform.
                switch (osInfo.Platform)
                {
                    //Platform is a Windows CE device
                    case System.PlatformID.WinCE:
                        results = "Windows CE";
                        break;

                    // Platform is Windows 95, Windows 98, 
                    // Windows 98 Second Edition, or Windows Me.
                    case System.PlatformID.Win32Windows:
                        switch (osInfo.Version.Minor)
                        {
                            case 0:
                                results = "Windows 95";
                                break;
                            case 10:
                                if (osInfo.Version.Revision.ToString() == "2222A")
                                    results = "Windows 98 Second Edition";
                                else
                                    results = "Windows 98";
                                break;
                            case 90:
                                results = "Windows Me";
                                break;
                        }
                        break;

                    // Platform is Windows NT 3.51, Windows NT 4.0, Windows 2000,
                    // or Windows XP.
                    case System.PlatformID.Win32NT:
                        results = GetOperatingSystemFromRegistry();
                        break;
                }

                return results;
            }
            catch
            {
                return results;
            }
        }

        private static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        private static string GetOperatingSystemFromRegistry()
        {
            string productName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string csdVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (productName != "")
            {
                return (productName.StartsWith("Microsoft") ? "" : "Microsoft ") + productName +
                       (csdVersion != "" ? " " + csdVersion : "");
            }
            return "";
        }
    }
}
