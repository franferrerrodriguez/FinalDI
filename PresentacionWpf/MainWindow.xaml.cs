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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utils;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControl uc = null;

        public MainWindow(LoginWindow loginWindow)
        {
            InitializeComponent();
            textBoxUsername.Text = loginWindow.textBoxLoginUser.Text;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            openMenu.Visibility = Visibility.Collapsed;
            closeMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            openMenu.Visibility = Visibility.Visible;
            closeMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectUserControl(((ListViewItem)((ListView)sender).SelectedItem).Name);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !LoginNegocio.ExitApp();
            if (!e.Cancel)
                Environment.Exit(0);
        }

        private void SelectUserControl(string item)
        {
            switch (item)
            {
                case "Archivo_Salir":
                    if (LoginNegocio.ExitApp())
                        Environment.Exit(0);
                    break;
                case "Usuarios_Insertar":
                    panel_Main.Children.Clear();
                    uc = new FichaUsuariosUserControl(Utils.Utilities.Modos.Insertar, this);
                    panel_Main.Children.Add(uc);
                    break;
                case "Usuarios_Modificar":
                    panel_Main.Children.Clear();
                    uc = new TableViewUsuariosUserControl(Utils.Utilities.Modos.Modificar, this);
                    panel_Main.Children.Add(uc);
                    break;
                case "Usuarios_Eliminar":
                    panel_Main.Children.Clear();
                    uc = new TableViewUsuariosUserControl(Utils.Utilities.Modos.Eliminar, this);
                    panel_Main.Children.Add(uc);
                    break;
                case "Productos_Consultar":
                    MessageBox.Show("Productos_Consultar");
                    break;
                case "Pedidos_Nuevo":
                    MessageBox.Show("Pedidos_Nuevo");
                    break;
                case "Pedidos_ConsultarModificar":
                    MessageBox.Show("Pedidos_ConsultarModificar");
                    break;
                case "Estadisticas":
                    MessageBox.Show("Estadisticas");
                    break;
                case "Informes_Facturas":
                    MessageBox.Show("Informes_Facturas");
                    break;
            }
            if(uc != null)
            {
                uc.VerticalAlignment = VerticalAlignment.Top;
                uc.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }

    }
}