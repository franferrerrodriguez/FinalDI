using Capa_entidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Utils;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class TableViewProductosUserControl : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private ProductosNegocio productosNegocio;
        private List<Articulo> listArticulos;
        public Articulo articulo;

        public TableViewProductosUserControl(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            UtilsControl.SetTitulo(modo, labelTitle, "productos");
            mainWindow.SetStatusException();

            try
            {
                productosNegocio = new ProductosNegocio();
                comboBoxFiltrarTipo.DataContext = productosNegocio.LeerTiposArticulos();
                comboBoxFiltrarTipo.SelectedIndex = 0;
                listArticulos = productosNegocio.LeerArticulos();
                RefreshTable(listArticulos);
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
            }

        }

        public void RefreshTable(List<Articulo> listArticulos = null)
        {
            if (listArticulos == null)
            {
                try
                {
                    listArticulos = productosNegocio.LeerArticulos();
                    this.listArticulos = listArticulos;
                }
                catch (Exception e)
                {
                    mainWindow.SetStatusException(e);
                }
            }

            if (listArticulos != null)
            {
                dataGrid.DataContext = listArticulos;
            }

        }


        private void TextBoxFiltrarNombre_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {
            TipoArticulo tipoArticulo = (TipoArticulo)comboBoxFiltrarTipo.SelectedItem;
            try
            {
                List<Articulo> filtro = productosNegocio.LeerArticulosPorFiltro(listArticulos, textBoxFiltrarNombre.Text, tipoArticulo.TipoArticuloID);
                RefreshTable(filtro);
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
            }
        }

        private void DataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            articulo = (Articulo)dataGrid.CurrentCell.Item;
            
            if(userControlParent != null)
            {
                if (typeof(FichaPedidosUserControl).Equals(userControlParent.GetType()))
                {
                    FichaPedidosUserControl uc = (FichaPedidosUserControl)userControlParent;
                    uc.AnyadirLineaArticulo(articulo);
                }
            }
            
            Close();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close()
        {
            if (userControlParent != null && typeof(FichaPedidosUserControl).Equals(userControlParent.GetType()))
            {
                FichaPedidosUserControl uc = (FichaPedidosUserControl)userControlParent;
                mainWindow.SetUserControlChildren(userControlParent);
            }
            else
                mainWindow.SetUserControlChildren(userControlParent);
        }

    }
}