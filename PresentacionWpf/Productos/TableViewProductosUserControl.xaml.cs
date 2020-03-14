﻿using Capa_entidades;
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

            FichaPedidosUserControl uc = (FichaPedidosUserControl)userControlParent;

            //listLinpeds
            MessageBox.Show(articulo.ArticuloID);
            /*usuario = (Usuario)dataGrid.CurrentCell.Item;

            if (modo.Equals(Modos.Modificar))
            {
                mainWindow.SetUserControlChildren(Modos.Insertar, new FichaUsuariosUserControl(Modos.Modificar, mainWindow, this));
            }
            else if (modo.Equals(Modos.Eliminar))
            {
                if (ConfirmDialog("Eliminar usuario", $"¿Está seguro que desea eliminar al usuario (ID: {usuario.UsuarioID} - Nombre: {usuario.Nombre} {usuario.Apellidos})?"))
                {
                    try
                    {
                        MessageBox.Show(usuariosNegocio.EliminarUsuario(usuario));
                        RefreshTable();
                    }
                    catch (Exception ex)
                    {
                        mainWindow.SetStatusException(ex);
                    }
                }
            }*/
            /*else if (modo.Equals(Modos.Seleccionar))
            {
                if (formParent.GetType().Equals(typeof(FichaPedidosForm)))
                {
                    FichaPedidosForm f = (FichaPedidosForm)formParent;
                    f.textBoxIdUsuarioFichaPedidosForm.Text = usuario.UsuarioID.ToString();
                    f.textBoxNombreUsuarioFichaPedidosForm.Text = usuario.Nombre;
                }
                else if (formParent.GetType().Equals(typeof(TableViewPedidosForm)))
                {
                    TableViewPedidosForm f = (TableViewPedidosForm)formParent;
                    f.SetUsuario(usuario.UsuarioID.ToString(), usuario.Nombre);
                }

                Close();
            }*/
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