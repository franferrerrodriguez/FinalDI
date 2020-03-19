using Capa_entidades;
using CapaNegocio;
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
        private MainWindow mainWindow;
        LoginNegocio loginNegocio;
        private static Usuario usuarioLogado;
        private int numIntentos;
        private static int maxIntentos = 3;

        public LoginWindow()
        {
            InitializeComponent();
            loginNegocio = new LoginNegocio();
            numIntentos = 0;
            Login();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            if (LoginNegocio.ExitApp())
                Environment.Exit(0);
        }

        private void Button_Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            textBoxLoginUser.Text = "alicia";
            textBoxLoginPassword.Text = "1234";
            Usuario usuario = loginNegocio.ComprobarLogin(textBoxLoginUser.Text, textBoxLoginPassword.Text);
            if (usuario != null)
            {
                mainWindow = new MainWindow(this);
                numIntentos = 0;
                Hide();
                usuarioLogado = usuario;
                mainWindow.Show();
            }
            else
            {
                numIntentos++;
                if (numIntentos.Equals(maxIntentos))
                {
                    Environment.Exit(0);
                }
                Reset();
                MessageBox.Show("Error en la combinación de login / password. Por favor, inténtelo de nuevo.");
            }
        }

        public static Usuario GetUsuarioLogado()
        {
            return usuarioLogado;
        }

        private void Reset()
        {
            textBoxLoginUser.Text = "Usuario";
            textBoxLoginPassword.Text = "Contraseña";
        }

        private void TextBlock_ForgotPassword(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Forgot password");
        }
        
    }
}