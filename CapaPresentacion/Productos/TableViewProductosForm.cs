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

namespace CapaPresentacion.Productos
{
    /// <summary>
    /// Clase encargada de la lista de pedidos
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class TableViewProductosForm : Form
    {
        private Utilities.Modos modo;
        private Form formParent;
        private ProductosNegocio productosNegocio;
        private List<Articulo> listArticulos;

        /// <summary>
        /// Constructor de clase TableViewProductosForm
        ///  <param name="modo">(Utilities.Modos) modo</param>
        ///  <param name="formParent">(Form) formParent</param>
        /// </summary>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public TableViewProductosForm(Utilities.Modos modo, Form formParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            this.formParent = formParent;

            try
            {
                productosNegocio = new ProductosNegocio();
                listArticulos = productosNegocio.LeerArticulos();
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
        private void TableViewProductosForm_Load(object sender, EventArgs e)
        {
            Utilities.SetTitulo(modo, labelTitleTableViewTableViewProductosForm, "productos");

            try
            {
                comboBoxTableViewProductosForm.DataSource = productosNegocio.LeerTiposArticulos();
                RefreshTable(listArticulos);
            }
            catch (Exception ex)
            {
                MainForm.MostrarExcepcion(ex);
            }

            if (modo.Equals(Utilities.Modos.Seleccionar) || modo.Equals(Utilities.Modos.Consultar))
            {
                buttonGuardarTableViewProductosForm.Hide();
            }
            else if (modo.Equals(Utilities.Modos.Modificar))
            {
                buttonGuardarTableViewProductosForm.Show();
            }
        }

        /// <summary>
        /// Método que refresca y actualiza la tabla de artículos
        /// </summary>
        /// <param name="listArticulos">(List<Articulo>) lista de artículos</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void RefreshTable(List<Articulo> listArticulos = null)
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
                    MainForm.MostrarExcepcion(e);
                }
            }

            if (listArticulos != null)
            {
                dataGridListaTableViewProductosForm.DataSource = listArticulos;

                dataGridListaTableViewProductosForm.Columns["Especificaciones"].Width = 180;
                dataGridListaTableViewProductosForm.Columns["UrlImagen"].Visible = false;
                dataGridListaTableViewProductosForm.Columns["Imagen"].Visible = false;

                dataGridListaTableViewProductosForm.Refresh();
            }

        }

        /// <summary>
        /// Método keyup para filtrar por nombre de producto
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(KeyEventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxFiltrarTableViewProductosForm_KeyUp(object sender, KeyEventArgs e)
        {
            Filtrar();
        }

        /// <summary>
        /// Método selectedItemChanged para filtrar por tipo de producto
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void comboBoxTableViewProductosForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        /// <summary>
        /// Método para filtrar productos
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void Filtrar()
        {
            TipoArticulo tipoArticulo = (TipoArticulo)comboBoxTableViewProductosForm.SelectedItem;
            try
            {
                List<Articulo> filtro = productosNegocio.LeerArticulosPorFiltro(listArticulos, textBoxFiltrarTableViewProductosForm.Text, tipoArticulo.TipoArticuloID);
                RefreshTable(filtro);
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }
        }

        /// <summary>
        /// Método click para seleccionar producto de la tabla y hacer la acción correspondiente
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void dataGridListaTableViewProductosForm_Click(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo)dataGridListaTableViewProductosForm.CurrentRow.DataBoundItem;
            if (formParent.GetType().Equals(typeof(FichaPedidosForm)))
            {
                FichaPedidosForm f = (FichaPedidosForm)formParent;
                f.AñadirLineaArticulo(articulo);
            }
            Close();
        }

        /// <summary>
        /// Método click del botón guardar para modificar el producto seleccionado en tabla
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonGuardarTableViewProductosForm_Click(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// Método click del botón cancelar para regresar al formulario anterior
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonCancelarTableViewProductosForm_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
