using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;

namespace ProjectTemplate
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class PassWordWindow : Window
    {
        public PassWordWindow()
        {
            InitializeComponent();
            PassWordInput.Focus();
        }

        private void OK_Press(object sender, RoutedEventArgs e)
        {
            string password = ConfigurationManager.AppSettings["Password"];
            if(password.Equals(PassWordInput.Password))
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show(Properties.Resources.PassWordWrong);
                this.DialogResult = false;
            }
        }

        private void Cancel_Press(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.PassWordNull);
            this.DialogResult = false;
        }
    }
}
