using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows;
using QRCoder;
using System;

namespace Randomizer3000
{
    public partial class WGenQR : Window
    {
        public WGenQR()
        {
            InitializeComponent();
            try
            {
                BGenQR.Click += (s, e) =>
                {
                    OpenFileDialog FileDialog = new OpenFileDialog { Filter = "Все файлы|*.*" };
                    if ((bool)FileDialog.ShowDialog()) GenQR(QrCodeImage, WorkWithFiles.ReadAllFile(FileDialog.FileName));
                    else new Notyfication() { Text = "Вы не выбрали файл!" }.Show(grid, 1, 2, new TimeSpan(0, 0, 2));
                };
            }
            catch (Exception ex) { BugReport.Create(ex); }
        }
        public void GenQR(Image Image, string Text)
        {
            try
            {
                Image.Source = null;
                if (Text == "") { new Notyfication() { Text = "Файл пустой" }.Show(grid, 1, 2, new TimeSpan(0, 0, 2)); return; }
                else
                    try { Image.Source = Core.BitmapToImage(new QRCode(new QRCodeGenerator().CreateQrCode(Text, QRCodeGenerator.ECCLevel.Q)).GetGraphic(20)); }
                    catch { new Notyfication() { Text = "Слишком большой файл! В файле должно быть не больше 3993 символов!" }.Show(grid, 1, 2, new TimeSpan(0, 0, 4)); }
            }
            catch (Exception ex) { BugReport.Create(ex); }
        }
    }
    
}
