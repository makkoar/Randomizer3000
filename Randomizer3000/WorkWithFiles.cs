using System.IO;
using System;

namespace Randomizer3000
{
    public static class WorkWithFiles
    {
        public static void FileCreate(string Path, string FileName, string Text)
        {
            try
            {
                StreamWriter FileWriter = new StreamWriter($@"{ Path }\{ FileName }");
                FileWriter.WriteLine(Text);
                FileWriter.Close();
            }
            catch (Exception ex) { BugReport.Create(ex); }
        }
        public static void FileCreate(string FileName, string Text)
        {
            try
            {
                StreamWriter FileWriter = new StreamWriter(FileName);
                FileWriter.WriteLine(Text);
                FileWriter.Close();
            }
            catch (Exception ex) { BugReport.Create(ex); }
        }

        public static string ReadAllFile(string Path, string FileName)
        {
            try
            {
                StreamReader FileWriter = new StreamReader($@"{ Path }\{ FileName }");
                string Text = FileWriter.ReadToEnd();
                FileWriter.Close();
                return Text;
            }
            catch (Exception ex) { BugReport.Create(ex); return null; }
        }
        public static string ReadAllFile(string FileName)
        {
            try
            {
                StreamReader FileWriter = new StreamReader(FileName);
                string Text = FileWriter.ReadToEnd();
                FileWriter.Close();
                return Text;
            }
            catch (Exception ex) { BugReport.Create(ex); return null; }
        }
    }
}
