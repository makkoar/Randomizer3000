using System.Collections.Generic;
using System.Windows.Controls;
using AngleSharp.Html.Parser;
using System.Threading.Tasks;
using AngleSharp.Dom;
using System.Net;
using System.IO;
using System;


namespace Randomizer3000
{
    public class Network
    {
        public string CacheName { get; set; } = "Cache.tmp";
        public static bool ProgressEnable = false;
        public static int Progress;

        public static string GetHtmlPageText(string url)
        {
            try { return new StreamReader(new WebClient().OpenRead(url)).ReadToEnd(); }
            catch (Exception ex) { BugReport.Create(ex); return null; }
        }
        public async void DownloadingCache(Grid Grid)
        {
            try
            {
                StreamWriter TempCache = new StreamWriter($@"Assets\Cache\{ CacheName }");
                ProgressEnable = true;
                new Notyfication() { Text = "Загрузка кеша началась!" }.Show(Grid, 1, 2, new TimeSpan(0, 0, 2));

                await Task.Run(() =>
                {
                    for (int i = 1; i <= 2292; i++)
                    {
                        List<string> Temp = new List<string>();
                        Temp.AddRange(AngleSharp("img", "src", GetHtmlPageText($@"http://1001mem.ru/new/{ i }")));
                    Temp:
                        foreach (string item in Temp)
                        {
                            if (item == "")
                            {
                                Temp.Remove(item);
                                goto Temp;
                            }
                            if (item.Split('/')[0] != "http:")
                            {
                                Temp.Remove(item);
                                goto Temp;
                            }
                            if (item.Split('/')[2].Split('.')[0] != "img")
                            {
                                Temp.Remove(item);
                                goto Temp;
                            }
                        }
                        if (Temp.Count != 0) TempCache.WriteLine(string.Join(@";", Temp));
                        Progress = i;
                    }
                });
                TempCache.Close();
                ProgressEnable = false;

                new Notyfication() { Text = "Загрузка кеша завершена!" }.Show(Grid, 1, 2, new TimeSpan(0, 0, 2));
            }
            catch (Exception ex) { BugReport.Create(ex); }
        }

        private static List<string> AngleSharp(string Tag, string Attribute, string Html)
        {
            try
            {
                List<string> hrefTags = new List<string>();
                foreach (IElement element in new HtmlParser().ParseDocument(Html).QuerySelectorAll(Tag)) hrefTags.Add(element.GetAttribute(Attribute));
                return hrefTags;
            }
            catch (Exception ex) { BugReport.Create(ex); return null; }
        }

        public static void FileUpload(string URL, string Puth)
        {
            try { new WebClient().DownloadFile(URL, $"{Puth}\\{ URL.Split('/')[5] }"); }
            catch (Exception ex) { BugReport.Create(ex); }
        }
        public static void FileUpload(string URL)
        {
            try { new WebClient().DownloadFile(URL, URL.Split('/')[5]); }
            catch (Exception ex) { BugReport.Create(ex); }
        }
    }
}
