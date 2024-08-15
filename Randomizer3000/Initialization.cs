using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System;

namespace Randomizer3000
{
    public class Initialization
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        public void Start()
        {
            try
            {
                EACDirectory(new List<string> {
                "Assets",
                @"Assets\Images",
                @"Assets\Cache",
                @"BugReports"
            });

                if (GetModuleHandle("SbieDll.dll") != IntPtr.Zero) Core.CloseApp();
            }
            catch (Exception ex) { BugReport.Create(ex); }
        }

        private void EACDirectory(List<string> Puths)
        {
            try { foreach (string Puth in Puths) if (!Directory.Exists(Puth)) Directory.CreateDirectory(Puth); }
            catch (Exception ex) { BugReport.Create(ex); }
        }
    }
}
