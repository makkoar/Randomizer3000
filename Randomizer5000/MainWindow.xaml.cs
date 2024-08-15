namespace Randomizer5000;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        //Закрытие всего приложения при закрытии главного окна.
        Closing += (s, e) => Application.Current.Shutdown();

        btnGenPass.Click += (s, e) =>
        {
            Hide();
            _ = new WGenPass().ShowDialog();
            Show();
        };

        btnGenQR.Click += (s, e) =>
        {
            Hide();
            _ = new WGenQR().ShowDialog();
            Show();
        };

        btnGenMemes.Click += (s, e) =>
        {
            Hide();
            _ = new WGenMemes().ShowDialog();
            Show();
        };
    }
}