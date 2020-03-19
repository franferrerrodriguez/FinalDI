using Capa_entidades;
using CapaNegocio;
using System;
using System.Windows;

namespace PresentacionWpf
{
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
            textBoxLoginUser.Text = "aam@colegas.com";
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
                MessageBox.Show("Error en la combinación de email / contraseña. Por favor, inténtelo de nuevo.");
            }
        }

        public static Usuario GetUsuarioLogado()
        {
            return usuarioLogado;
        }

        public void Reset()
        {
            textBoxLoginUser.Text = "Email";
            textBoxLoginPassword.Text = "Contraseña";
        }
        
    }
}