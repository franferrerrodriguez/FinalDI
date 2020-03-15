using Capa_entidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Utils;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class FichaProductosUserControl : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private TableViewUsuariosUserControl tableViewUsuariosUserControl;
        private ProductosNegocio productosNegocio;

        public FichaProductosUserControl(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            tableViewUsuariosUserControl = (TableViewUsuariosUserControl)userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "productos");
            mainWindow.SetStatusException();

            productosNegocio = new ProductosNegocio();

            TextBox tx = new TextBox();
            tx.Margin = new Thickness(150,0,0,0);
            tx.Width = 200;
            tx.Height = 20;
            tx.Text = "ok";
            tx.HorizontalAlignment = HorizontalAlignment.Left;

        }

    }
}