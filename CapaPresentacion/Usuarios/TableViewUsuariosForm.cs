using Capa_entidades;
using Capa_presentacion;
using CapaNegocio;
using CapaPresentacion.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace CapaPresentacion.Usuarios
{
    /// <summary>
    /// Clase encargada de la lista de usuarios
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class TableViewUsuariosForm : Form
    {
        private Utilities.Modos modo;
        private Form formParent;
        private UsuariosNegocio usuariosNegocio;
        private List<Usuario> listUsuarios;

        /// <summary>
        /// Constructor de clase TableViewUsuariosForm
        /// </summary>
        /// <param name="modo">(Utilities.Modos) modo</param>
        /// <param name="formParent">(Form) formParent</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public TableViewUsuariosForm(Utilities.Modos modo, Form formParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            this.formParent = formParent;

            try
            {
                usuariosNegocio = new UsuariosNegocio();
                listUsuarios = usuariosNegocio.LeerUsuarios();
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }
        }

        /// <summary>
        /// Método load del formulario
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void ModificarUsuario_Load(object sender, EventArgs e)
        {
            Utilities.SetTitulo(modo, labelTitleTableViewTableViewUsuariosForm, "usuarios");
            RefreshTable(listUsuarios);
        }

        /// <summary>
        /// Método que refresca y actualiza la tabla de usuarios
        /// </summary>
        /// <param name="listUsuarios">(List<Usuario>) lista de usuarios</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void RefreshTable(List<Usuario> listUsuarios = null)
        {
            // Si listUsuarios no es null, podemos pasar un listUsuarios filtrado para mostrar en la tabla
            // Si listUsuarios es null, volveremos a cargar de la base de datos
            if(listUsuarios == null)
            {
                try
                {
                    listUsuarios = usuariosNegocio.LeerUsuarios();
                    this.listUsuarios = listUsuarios;
                }
                catch (Exception e)
                {
                    MainForm.MostrarExcepcion(e);
                }
            }

            if(listUsuarios != null)
            {
                dataGridListaTableViewUsuariosForm.DataSource = listUsuarios;

                dataGridListaTableViewUsuariosForm.Columns["Password"].Visible = false;
                dataGridListaTableViewUsuariosForm.Columns["Calle"].Visible = false;
                dataGridListaTableViewUsuariosForm.Columns["Calle2"].Visible = false;
                dataGridListaTableViewUsuariosForm.Columns["PuebloID"].Visible = false;
                dataGridListaTableViewUsuariosForm.Columns["ProvinciaID"].Visible = false;
                dataGridListaTableViewUsuariosForm.Columns["Nacido"].Visible = false;

                dataGridListaTableViewUsuariosForm.Refresh();
            }

        }

        /// <summary>
        /// Método keyUp para filtrar por nombre
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxFiltrarEditarUsuarios_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        /// <summary>
        /// Método keyUp para filtrar por apellidos
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxFiltrarApellidosTableViewUsuariosForm_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        /// <summary>
        /// Método keyUp para filtrar por email
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxFiltrarEmailTableViewUsuariosForm_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        /// <summary>
        /// Método keyUp para filtrar por documento
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxFiltrarDocumentoTableViewUsuariosForm_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        /// <summary>
        /// Método para filtrar usuarios
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void Filtrar()
        {
            try
            {
                List<Usuario> filtroUsuarios = usuariosNegocio.LeerUsuariosPorFiltro(listUsuarios,
                    textBoxFiltrarNombreTableViewUsuariosForm.Text,
                    textBoxFiltrarApellidosTableViewUsuariosForm.Text,
                    textBoxFiltrarEmailTableViewUsuariosForm.Text,
                    textBoxFiltrarDocumentoTableViewUsuariosForm.Text);
                RefreshTable(filtroUsuarios);
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }
        }

        /// <summary>
        /// Método click para seleccionar usuario de la tabla y hacer la acción correspondiente
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void dataGridListaModificarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)dataGridListaTableViewUsuariosForm.CurrentRow.DataBoundItem;
            if (modo.Equals(Utilities.Modos.Modificar))
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
                }else if (formParent.GetType().Equals(typeof(TableViewPedidosForm))){
                    TableViewPedidosForm f = (TableViewPedidosForm)formParent;
                    f.SetUsuario(usuario.UsuarioID.ToString(), usuario.Nombre);
                }

                Close();
            }

        }

        /// <summary>
        /// Método click del botón cancelar para regresar al formulario anterior
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonCancelarModificarUsuario_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}