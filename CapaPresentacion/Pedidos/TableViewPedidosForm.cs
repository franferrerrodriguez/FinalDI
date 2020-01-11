using Capa_entidades;
using Capa_presentacion;
using CapaNegocio;
using CapaPresentacion.Productos;
using CapaPresentacion.Usuarios;
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

namespace CapaPresentacion.Pedidos
{
    /// <summary>
    /// Clase encargada de la lista de pedidos
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class TableViewPedidosForm : Form
    {
        private Utilities.Modos modo;
        private Form formParent;
        private PedidosNegocio pedidosNegocio;
        private List<Pedido> listPedidos;

        /// <summary>
        /// Constructor de clase TableViewPedidosForm
        /// </summary>
        /// <param name="modo">(Utilities.Modos) modo</param>
        /// <param name="formParent">(Form) formParent</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public TableViewPedidosForm(Utilities.Modos modo, Form formParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            this.formParent = formParent;
            try
            {
                pedidosNegocio = new PedidosNegocio();
                listPedidos = pedidosNegocio.LeerPedidos();
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
        private void TableViewPedidosForm_Load(object sender, EventArgs e)
        {
            Utilities.SetTitulo(modo, labelTitleTableViewTableViewPedidosForm, "pedidos");

            dateTimeFechaInicioTableViewTableViewPedidosForm.Value = new DateTime(2000,01,01);
            dateTimeFechaFinTableViewTableViewPedidosForm.Value = new DateTime(2050, 01, 01);
            RefreshTable(listPedidos);
        }

        /// <summary>
        /// Método que refresca y actualiza la tabla de pedidos
        /// </summary>
        /// <param name="listPedidos">(List<Pedido>) lista de pedidos</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void RefreshTable(List<Pedido> listPedidos = null)
        {
            if (listPedidos == null)
            {
                try
                {
                    listPedidos = pedidosNegocio.LeerPedidos();
                    this.listPedidos = listPedidos;
                }
                catch (Exception e)
                {
                    MainForm.MostrarExcepcion(e);
                }
            }

            if (listPedidos != null)
            {
                dataGridListaTableViewTableViewPedidosForm.DataSource = listPedidos;

                dataGridListaTableViewTableViewPedidosForm.Columns["PedidoID"].Width = 168;
                dataGridListaTableViewTableViewPedidosForm.Columns["UsuarioID"].Width = 168;
                dataGridListaTableViewTableViewPedidosForm.Columns["Fecha"].Width = 168;
                dataGridListaTableViewTableViewPedidosForm.Columns["ImporteTotal"].Width = 168;

                dataGridListaTableViewTableViewPedidosForm.Refresh();
            }

        }

        /// <summary>
        /// Método click del botón guardar para seleccionar el usuario
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonSeleccionarUsuarioFichaPedidosForm_Click(object sender, EventArgs e)
        {
            TableViewUsuariosForm f = new TableViewUsuariosForm(Utilities.Modos.Seleccionar, this);
            f.ShowDialog();
        }

        /// <summary>
        /// Método que establece usuario para filtro de tabla
        /// </summary>
        /// <param name="id">(string) id</param>
        /// <param name="nombre">(string) nombre</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void SetUsuario(string id, string nombre)
        {
            textBoxIdUsuarioTableViewTableViewPedidosForm.Text = id;
            textBoxNombreUsuarioTableViewTableViewPedidosForm.Text = nombre;
            Filtrar();
        }

        /// <summary>
        /// Método closeup para filtrar por fecha inicio
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void dateTimeFechaInicioTableViewTableViewPedidosForm_CloseUp(object sender, EventArgs e)
        {
            Filtrar();
        }

        /// <summary>
        /// Método closeup para filtrar por fecha fin
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void dateTimeFechaFinTableViewTableViewPedidosForm_CloseUp(object sender, EventArgs e)
        {
            Filtrar();
        }

        /// <summary>
        /// Método para filtrar pedidos
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void Filtrar()
        {
            DateTime fechaInicio = dateTimeFechaInicioTableViewTableViewPedidosForm.Value;
            DateTime fechaFin = dateTimeFechaFinTableViewTableViewPedidosForm.Value;
            try
            {
                RefreshTable(pedidosNegocio.LeerPedidosPorFiltro(listPedidos, textBoxIdUsuarioTableViewTableViewPedidosForm.Text, fechaInicio, fechaFin));
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }
        }

        /// <summary>
        /// Método click para seleccionar pedido de la tabla y hacer la acción correspondiente
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void dataGridListaTableViewTableViewPedidosForm_Click(object sender, EventArgs e)
        {
            Pedido pedido = (Pedido)dataGridListaTableViewTableViewPedidosForm.CurrentRow.DataBoundItem;
            if (modo.Equals(Utilities.Modos.Modificar))
            {
                Form form = ((MainForm)MdiParent).childrenMdi(new FichaPedidosForm(Utilities.Modos.Modificar, this, pedido));
                form.Show();
            }
            else if (modo.Equals(Utilities.Modos.Eliminar))
            {
                if(Utilities.ConfirmDialog("Eliminar pedido", $"¿Está seguro que desea eliminar el pedido (ID: {pedido.PedidoID} - Total líneas: {pedido.ListLinped.Count()})?"))
                {
                    try
                    {
                        MessageBox.Show(pedidosNegocio.EliminarPedido(pedido));
                        RefreshTable();
                    }
                    catch (Exception ex)
                    {
                        MainForm.MostrarExcepcion(ex);
                    }
                }
            }
            else if (modo.Equals(Utilities.Modos.Consultar))
            {
                if (formParent.GetType().Equals(typeof(FacturaForm)))
                {
                    FacturaForm f = new FacturaForm(pedido);
                    f.Show();
                }
            }
        }

        /// <summary>
        /// Método click del botón que quita el usuario elegido en la ficha de usuario
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonQuitarUsuarioFichaPedidosForm_Click(object sender, EventArgs e)
        {
            if (!textBoxIdUsuarioTableViewTableViewPedidosForm.Text.Equals(""))
            {
                textBoxIdUsuarioTableViewTableViewPedidosForm.Text = "";
                textBoxNombreUsuarioTableViewTableViewPedidosForm.Text = "";
                RefreshTable();
            }

        }

        /// <summary>
        /// Método click del botón cancelar para regresar al formulario anterior
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonCancelarTableViewTableViewPedidosForm_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}