using System.Windows;
using System;

namespace Randomizer3000
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            try
            {
                Closing += (s, e) => Core.CloseApp();

                WGenPass wGenPass = new WGenPass();
                WGenQR wGenQR = new WGenQR();
                WGenMemes wGenMemes = new WGenMemes();

                BGenPass.Click += (s, e) => { Hide(); ReloadPass: try { wGenPass = new WGenPass(); wGenPass.ShowDialog(); } catch (Exception ex) { BugReport.Create(ex); wGenPass.Close(); goto ReloadPass; } Show(); Show(); };
                BGenQR.Click += (s, e) => { Hide(); ReloadQR: try { wGenQR = new WGenQR(); wGenQR.ShowDialog(); } catch (Exception ex) { BugReport.Create(ex); wGenQR.Close(); goto ReloadQR; } Show(); };
                BGenMemes.Click += (s, e) => { Hide(); ReloadMemes: try { wGenMemes = new WGenMemes(); wGenMemes.ShowDialog(); } catch (Exception ex) { BugReport.Create(ex); wGenMemes.Close(); goto ReloadMemes; } Show(); };
            }
            catch (Exception ex) { BugReport.Create(ex); }
        }
    }
}
