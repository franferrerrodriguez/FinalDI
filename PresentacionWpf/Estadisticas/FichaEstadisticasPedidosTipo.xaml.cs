using Capa_entidades;
using CapaNegocio;
using System;
using System.Windows;
using System.Windows.Controls;
using Utils;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class FichaEstadisticasPedidosTipo : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;

        public FichaEstadisticasPedidosTipo(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "pedidos por tipo");
            mainWindow.SetStatusException();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close()
        {
            if (userControlParent != null && typeof(TableViewUsuariosUserControl).Equals(userControlParent.GetType()))
            {
                TableViewUsuariosUserControl uc = (TableViewUsuariosUserControl)userControlParent;
                mainWindow.SetUserControlChildren(userControlParent);
            }
            else
                mainWindow.SetUserControlChildren(userControlParent);
        }

    }
}