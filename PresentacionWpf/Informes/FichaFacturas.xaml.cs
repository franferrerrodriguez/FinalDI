using Capa_entidades;
using CapaNegocio;
using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class FichaFacturas : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;

        public FichaFacturas(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "facturas");
            mainWindow.SetStatusException();
            
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close()
        {
            mainWindow.SetUserControlChildren(userControlParent);
        }

    }
}