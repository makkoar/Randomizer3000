namespace Randomizer3000
{
    public partial class WGenMemes : Window
    {
        public WGenMemes()
        {
            InitializeComponent();

            //BGenMemes.Click += (s, e) => GenMemes(Image, grid);

            //DispatcherTimer Timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 100) };
            //Timer.Tick += (s, e) =>
            //{
            //    if (Network.ProgressEnable)
            //    {
            //        ProgressBarStatus.Visibility = Visibility.Visible;
            //        ProgressBar.Visibility = Visibility.Visible;

            //        ProgressBarStatus.Text = $"{ Network.Progress } / 2292";
            //        ProgressBar.Value = Network.Progress;
            //    }
            //    else
            //    {
            //        ProgressBarStatus.Visibility = Visibility.Hidden;
            //        ProgressBar.Visibility = Visibility.Hidden;
            //    }
            //};

            //Timer.Start();
        }

        public static void GenMemes(Image Image, Grid Grid)
        {
            //try
            //{
            //    string CacheName = "CacheMemes.tmp";
            //    if (!File.Exists($@"Assets\Cache\{ CacheName }")) new Network() { CacheName = CacheName }.DownloadingCache(Grid);
            //    else
            //    {
            //        StreamReader ReadCacheMemes = new StreamReader($@"Assets\Cache\{ CacheName }");
            //        List<string> Lines = new List<string>();

            //        Lines.AddRange(ReadCacheMemes.ReadToEnd().Split('\n', ';'));
            //        ReadCacheMemes.Close();
            //    _1:
            //        string Obj = Lines[new Random().Next(1, Lines.Count)];
            //        try
            //        {
            //            Network.FileUpload(Obj, $"Assets\\Images");
            //            Image.Source = (new ImageSourceConverter()).ConvertFromString($"Assets\\Images\\{ Obj.Split('/')[5] }") as ImageSource;
            //        }
            //        catch (Exception ex) { BugReport.Create(ex); goto _1; }
            //    }
            //}
            //catch (Exception ex) { BugReport.Create(ex); }
        }
    }
}
