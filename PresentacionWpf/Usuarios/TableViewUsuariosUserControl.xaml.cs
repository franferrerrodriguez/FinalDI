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
    public partial class TableViewUsuariosUserControl : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private UsuariosNegocio usuariosNegocio;
        private List<Usuario> listUsuarios;
        public Usuario usuario;

        public TableViewUsuariosUserControl(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;

            mainWindow.SetStatusException();

            try
            {
                usuariosNegocio = new UsuariosNegocio();
                listUsuarios = usuariosNegocio.LeerUsuarios();
                RefreshTable(listUsuarios);
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
            }

        }

        public void RefreshTable(List<Usuario> listUsuarios = null)
        {
            if (listUsuarios == null)
            {
                try
                {
                    listUsuarios = usuariosNegocio.LeerUsuarios();
                    this.listUsuarios = listUsuarios;
                }
                catch (Exception e)
                {
                    mainWindow.SetStatusException(e);
                }
            }

            if (listUsuarios != null)
            {
                dataGrid.DataContext = listUsuarios;
            }

        }

        private void TextBoxFiltrarNombre_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        private void TextBoxFiltrarApellidos_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        private void TextBoxFiltrarEmail_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        private void TextBoxFiltrarDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {
            try
            {
                List<Usuario> filtroUsuarios = usuariosNegocio.LeerUsuariosPorFiltro(listUsuarios,
                    textBoxFiltrarNombre.Text,
                    textBoxFiltrarApellidos.Text,
                    textBoxFiltrarEmail.Text,
                    textBoxFiltrarDocumento.Text);
                RefreshTable(filtroUsuarios);
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
            }
        }

        private void DataGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            usuario = (Usuario)dataGrid.CurrentCell.Item;

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
            }
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
            mainWindow.SetUserControlChildren(Modos.Cerrar);
        }

    }
}