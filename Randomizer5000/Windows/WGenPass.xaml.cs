using Randomizer5000.Enums;
using System.Text.RegularExpressions;

namespace Randomizer5000;

public partial class WGenPass : Window
{
    private readonly Random rnd = new();
    private readonly List<char> Symbols = ['!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', ';', ':', ',', '.', '/', '?', '\\', '|', '`', '~', '[', ']', '{', '}'];

    public WGenPass()
    {
        InitializeComponent();

        Count.PreviewTextInput += (s, e) => e.Handled = !RNumbers().IsMatch(e.Text);

        Count.TextChanged += (s, e) =>
        {
            if (Count.Text is "0") Count.Text = "1";
        };

        C1.Unchecked += (s, e) => C1.IsChecked = (C2.IsChecked is false && C3.IsChecked is false && C4.IsChecked is false);
        C2.Unchecked += (s, e) => C2.IsChecked = (C1.IsChecked is false && C3.IsChecked is false && C4.IsChecked is false);
        C3.Unchecked += (s, e) => C3.IsChecked = (C1.IsChecked is false && C2.IsChecked is false && C4.IsChecked is false);
        C4.Unchecked += (s, e) => C4.IsChecked = (C1.IsChecked is false && C2.IsChecked is false && C3.IsChecked is false);

        btnGenPass.Click += (s, e) =>
        {
            PGenFlag flags = PGenFlag.None;
            if (C1.IsChecked == true) flags |= PGenFlag.UpCase;
            if (C2.IsChecked == true) flags |= PGenFlag.LowCase;
            if (C3.IsChecked == true) flags |= PGenFlag.Numbers;
            if (C4.IsChecked == true) flags |= PGenFlag.Symbols;
            Result.Text = GenPass(uint.TryParse(Count.Text, out uint count) ? count : 16, flags);
        };
    }

    private string GenPass(uint count, PGenFlag flags)
    {
        string result = string.Empty;

        List<int> GenList = [];
        if (flags.HasFlag(PGenFlag.UpCase)) GenList.Add(1);
        if (flags.HasFlag(PGenFlag.LowCase)) GenList.Add(2);
        if (flags.HasFlag(PGenFlag.Numbers)) GenList.Add(3);
        if (flags.HasFlag(PGenFlag.Symbols)) GenList.Add(4);

        _ = Parallel.For(0, count, (_) =>
        {
            switch (GenList[rnd.Next(0, GenList.Count)])
            {
                case 1: result += (char)rnd.Next('A', 'Z' + 1); break;
                case 2: result += (char)rnd.Next('a', 'z' + 1); break;
                case 3: result += rnd.Next(0, 10); break;
                case 4: result += Symbols[rnd.Next(0, Symbols.Count)]; break;
            }
        });

        Clipboard.SetText(result);
        Notification.Show("Пароль скопирован в буфер обмена!", new TimeSpan(0, 0, 2));
        return result;
    }

    [GeneratedRegex("^[0-9]+$")]
    private static partial Regex RNumbers();
}
