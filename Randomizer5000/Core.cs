using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace Randomizer5000
{
    public static class Core
    {
        public static BitmapImage BitmapToImage(Bitmap Bitmap)
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
    }
}
