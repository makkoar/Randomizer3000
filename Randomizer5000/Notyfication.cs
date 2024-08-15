namespace Randomizer5000;

public class Notification
{
    public async static void Show(string text, TimeSpan time)
    {
        Window? activeWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        if (activeWindow?.FindName("NotifyGrid") is not Grid grid) return;

        TextBox? Notifications = new()
        {
            Background = new SolidColorBrush(Color.FromRgb(30, 30, 30)),
            Cursor = Cursors.Arrow,
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(5),
            BorderBrush = Brushes.White,
            Foreground = Brushes.White,
            IsEnabled = false,
            TextWrapping = TextWrapping.Wrap,
            Text = text,
            Opacity = 0,
            MaxWidth = 200,
            MinHeight = 20
        };

        Grid.SetColumnSpan(Notifications, grid.ColumnDefinitions.Count + 1);
        Grid.SetRowSpan(Notifications, grid.RowDefinitions.Count + 1);
        _ = grid.Children.Add(Notifications);

        DoubleAnimation animOpacity = new(1, new TimeSpan(0, 0, 0, 1));
        Notifications.BeginAnimation(UIElement.OpacityProperty, animOpacity);

        await Task.Run(() => Thread.Sleep(time));

        animOpacity = new(0, new TimeSpan(0, 0, 0, 1));
        Notifications.BeginAnimation(UIElement.OpacityProperty, animOpacity);
        animOpacity.Completed += (s, e) => grid.Children.Remove(Notifications);
    }
}
