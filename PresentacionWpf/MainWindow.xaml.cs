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
                    MessageBox.Show("Informes_Facturas");
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
            panel_Main.Children.Clear();
        }

        public void SetUserControlChildren(UserControl uc = null)
        {
            CloseUserControl();
            if (uc != null)
                panel_Main.Children.Add(uc);
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

    }

}