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
            UtilsControl.SetTitulo(modo, labelTitle, "usuarios");
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
                mainWindow.SetUserControlChildren(new FichaUsuariosUserControl(Modos.Modificar, mainWindow, this));
            }
            else if (modo.Equals(Modos.Eliminar))
            {
                if (ConfirmDialog("Eliminar usuario", $"¿Está seguro que desea eliminar al usuario (ID: { usuario.UsuarioID } - Nombre: { usuario.Nombre } { usuario.Apellidos })?"))
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
            else if (modo.Equals(Modos.Seleccionar))
            {
                if(userControlParent != null)
                {
                    if (typeof(FichaPedidosUserControl).Equals(userControlParent.GetType()))
                    {
                        FichaPedidosUserControl uc = (FichaPedidosUserControl)userControlParent;
                        uc.textBoxUsuarioId.Text = usuario.UsuarioID.ToString();
                        uc.textBoxUsuarioNombre.Text = usuario.Nombre;
                    }
                    else if (typeof(TableViewPedidosUserControl).Equals(userControlParent.GetType()))
                    {
                        TableViewPedidosUserControl uc = (TableViewPedidosUserControl)userControlParent;
                        uc.SetUsuario(usuario.UsuarioID.ToString(), usuario.Nombre);
                    }
                    else
                    {
                        mainWindow.SetStatusException(new Exception("Error. Falta selección por definir en TableViewPedidosUserControl."));
                    }
                }

                Close();
            }
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