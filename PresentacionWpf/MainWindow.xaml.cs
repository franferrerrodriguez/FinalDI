using CapaNegocio;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static Utils.Utilities;

namespace PresentacionWpf
{
    public partial class MainWindow : Window
    {
        UserControl uc = null;
        LoginWindow loginWindow;

        public MainWindow(LoginWindow loginWindow)
        {
            InitializeComponent();
            this.loginWindow = loginWindow;
            textBoxUsername.Text = loginWindow.textBoxLoginUser.Text;
            SetStatusException();
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
                    SetUserControlChildren(new FichaUsuariosUserControl(Modos.Insertar, this));
                    break;
                case "Usuarios_Modificar":
                    SetUserControlChildren(new TableViewUsuariosUserControl(Modos.Modificar, this));
                    break;
                case "Usuarios_Eliminar":
                    SetUserControlChildren(new TableViewUsuariosUserControl(Modos.Eliminar, this));
                    break;
                case "Productos_Consultar":
                    SetUserControlChildren(new FichaProductosUserControl(Modos.Consultar, this));
                    break;
                case "Pedidos_Nuevo":
                    SetUserControlChildren(new FichaPedidosUserControl(Modos.Insertar, this));
                    break;
                case "Pedidos_ConsultarModificar":
                    SetUserControlChildren(new TableViewPedidosUserControl(Modos.Modificar, this));
                    break;
                case "Pedidos_Eliminar":
                    SetUserControlChildren(new TableViewPedidosUserControl(Modos.Eliminar, this));
                    break;
                case "Estadisticas_PedidosDiaMes":
                    SetUserControlChildren(new FichaEstadisticasPedidosDiaMes(Modos.Consultar, this));
                    break;
                case "Estadisticas_PedidosTipo":
                    SetUserControlChildren(new FichaEstadisticasPedidosTipo(Modos.Consultar, this));
                    break;
                case "Informes_Facturas":
                    SetUserControlChildren(new FichaFacturas(Modos.Consultar, this));
                    break;
            }
            if(uc != null)
            {
                uc.VerticalAlignment = VerticalAlignment.Top;
                uc.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }

        public void CloseUserControl()
        {
            MainPanel.Children.Clear();
        }

        public void SetUserControlChildren(UserControl uc = null)
        {
            CloseUserControl();
            if (uc != null)
                MainPanel.Children.Add(uc);
        }

        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SelectUserControl(((ListViewItem)((ListView)sender).SelectedItem).Name);
        }

        public void SetStatusException(Exception e = null)
        {
            if(e == null)
            {
                LabelStatus.Content = "Estado: Correcto";
                LabelStatus.FontSize = 10;
                LabelStatus.Foreground = Brushes.Green;
            }
            else
            {
                LabelStatus.Content = String.Format("Estado: {0}", e.Message);
                LabelStatus.FontSize = 8;
                LabelStatus.Foreground = Brushes.Red;
            }

        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (ConfirmDialog("Cerrar sesión", "¿Está seguro que desea cerrar sesión?"))
            {
                Hide();
                loginWindow.Reset();
                loginWindow.Show();
            }
        }
    }

}