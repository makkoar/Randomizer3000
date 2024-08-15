using QRCoder;

namespace Randomizer5000;
public partial class WGenQR : Window
{
    public WGenQR()
    {
        InitializeComponent();
        Directory.CreateDirectory("QR-коды");

        Input.TextChanged += (s, e) => GenQR(Input.Text);

        btnSaveQR.Click += (s, e) =>
        {

            if (QRCodeImage.Source is BitmapSource bitmapSource)
            {
                using FileStream stream = new FileStream($"QR-коды\\{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png", FileMode.Create);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(stream);
                Notification.Show("QR-код сохранён.", new TimeSpan(0, 0, 2));
            }
            else Notification.Show("Не удалось сохранить QR-код, так как поле ввода пустое и QR-код не был сгенерирован.", new TimeSpan(0, 0, 2));
        };

        btnOpenFolder.Click += (s, e) =>
        {
            Directory.CreateDirectory("QR-коды");
            Process.Start(new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = "QR-коды",
                UseShellExecute = true
            });
        };
    }

    public void GenQR(string Text)
    {
        QRCodeImage.Source = null;
        try
        {
            if (!string.IsNullOrWhiteSpace(Text)) QRCodeImage.Source = Core.BitmapToImage(new QRCode(new QRCodeGenerator().CreateQrCode(Text, QRCodeGenerator.ECCLevel.Q)).GetGraphic(20));
            else Notification.Show("Поле ввода пустое. Пожалуйста введите текст.", new TimeSpan(0, 0, 2)); return;
        }
        catch (Exception ex) { Notification.Show($"Ошибка: {ex.Message}", new TimeSpan(0, 0, 2)); }
    }
}
