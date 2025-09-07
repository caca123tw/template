using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectTemplate
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        private void HandleOnAppStartup(object sender, StartupEventArgs e)
        {
            try
            {
                App.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }
        private void HandleOnAppExit(object sender, ExitEventArgs e)
        {
        }
    }
}
