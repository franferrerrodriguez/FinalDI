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

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Close");
        }

        private void Button_Minimize(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Minimize");
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Login");
        }

        private void TextBlock_ForgotPassword(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Forgot password");
        }

    }
}