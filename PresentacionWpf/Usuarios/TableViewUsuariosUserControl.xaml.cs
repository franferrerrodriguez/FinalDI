using Capa_entidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class TableViewUsuariosUserControl : UserControl
    {
        private Utilities.Modos modo;
        private Window windowParent;
        private UsuariosNegocio usuariosNegocio;
        private List<Usuario> listUsuarios;

        public TableViewUsuariosUserControl(Utilities.Modos modo, Window windowParent = null, Usuario usuario = null)
        {
            InitializeComponent();
            this.modo = modo;
            this.windowParent = windowParent;

            try
            {
                usuariosNegocio = new UsuariosNegocio();
                listUsuarios = usuariosNegocio.LeerUsuarios();
                RefreshTable(listUsuarios);
            }
            catch (Exception e)
            {
                //MainForm.MostrarExcepcion(e);
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
                    //MainForm.MostrarExcepcion(e);
                }
            }

            if (listUsuarios != null)
            {
                dataGrid.DataContext = listUsuarios;
            }

        }

        private void dataGridListaModificarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)dataGrid.CurrentCell.Item;
            MessageBox.Show(usuario.Nombre);



            /*if (modo.Equals(Utilities.Modos.Modificar))
            {
                Form form = ((MainForm)MdiParent).childrenMdi(new FichaUsuariosForm(Utilities.Modos.Modificar, this, usuario));
                form.Show();
            }
            else if (modo.Equals(Utilities.Modos.Eliminar))
            {
                if (Utilities.ConfirmDialog("Eliminar usuario", $"¿Está seguro que desea eliminar al usuario (ID: {usuario.UsuarioID} - Nombre: {usuario.Nombre} {usuario.Apellidos})?"))
                {
                    try
                    {
                        MessageBox.Show(usuariosNegocio.EliminarUsuario(usuario));
                        RefreshTable();
                    }
                    catch (Exception ex)
                    {
                        MainForm.MostrarExcepcion(ex);
                    }
                }
            }
            else if (modo.Equals(Utilities.Modos.Seleccionar))
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

    }
}