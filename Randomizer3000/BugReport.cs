using System.Windows;
using System;

namespace Randomizer3000
{
    public class BugReport
    {
        public static void Create(Exception ex)
        {
            new Initialization().Start();
            WorkWithFiles.FileCreate("BugReports", $"{ DateTime.Now.ToString("ddMMyyyyhhmmssfff") }.log", $"{ ex }");
        }
        public static void Create(Exception ex, bool ShowErrMessage)
        {
            new Initialization().Start();
            WorkWithFiles.FileCreate("BugReports", $"{ DateTime.Now.ToString("ddMMyyyyhhmmssfff") }.log", $"{ ex }");
            if (ShowErrMessage) MessageBox.Show($"{ ex }");
        }
    }
}
