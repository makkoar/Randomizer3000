using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Drawing.Imaging;
using System.Windows.Input;
using System.Drawing;
using System.Windows;
using System.IO;
using System;

namespace Randomizer3000
{
    public class Core
    {
        public static DispatcherTimer Checker = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 10) };
        
        public static void InputBlockNotNumbers(TextBox textBox)
        {
            try
            {
                textBox.KeyDown += (s, e) =>
                {
                    switch (e.Key)
                    {
                        case Key.D0: case Key.D1: case Key.D2: case Key.D3: case Key.D4: case Key.D5: case Key.D6: case Key.D7: case Key.D8: case Key.D9: e.Handled = false; break;
                        default: e.Handled = true; break;
                    }
                };
            }
            catch (Exception ex) { BugReport.Create(ex); }
        }
        public static void InputBlock(TextBox textBox)
        {
            try { textBox.KeyDown += (s, e) => e.Handled = true; }
            catch (Exception ex) { BugReport.Create(ex); }
        }

        public static BitmapImage BitmapToImage(Bitmap Bitmap)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                BitmapImage Image = new BitmapImage();

                Bitmap.Save(memoryStream, ImageFormat.Bmp);
                Image.BeginInit();
                memoryStream.Seek(0, SeekOrigin.Begin);
                Image.StreamSource = memoryStream;
                Image.EndInit();
                return Image;
            }
            catch (Exception ex) { BugReport.Create(ex); return null; }
        }

        public static void CloseApp()
        {
            try { Application.Current.Shutdown(); }
            catch (Exception ex) { BugReport.Create(ex); }
        }
    }
}
