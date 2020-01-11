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
    /// Clase encargada de la ficha de pedidos
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class FichaPedidosForm : Form
    {
        private Utilities.Modos modo;
        private Form formParent;
        private Pedido pedido;
        private PedidosNegocio pedidosNegocio;
        private ProductosNegocio productosNegocio;
        private UsuariosNegocio usuariosNegocio;
        private List<Linped> listLinpeds;
        private DataTable dataTable;

        /// <summary>
        /// Constructor de clase FichaPedidosForm
        /// </summary>
        ///  <param name="modo">(Utilities.Modos) modo</param>
        ///  <param name="formParent">(Form) formParent</param>
        ///  <param name="pedido">(Pedido) pedido</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public FichaPedidosForm(Utilities.Modos modo, Form formParent = null, Pedido pedido = null)
        {
            InitializeComponent();
            this.modo = modo;
            this.formParent = formParent;
            this.pedido = pedido;

            try
            {
                pedidosNegocio = new PedidosNegocio();
                productosNegocio = new ProductosNegocio();
                usuariosNegocio = new UsuariosNegocio();
                listLinpeds = new List<Linped>();
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
        private void FichaPedidosForm_Load(object sender, EventArgs e)
        {
            Utilities.SetTitulo(modo, labelTitleFichaPedidosForm, "pedidos");

            if (modo.Equals(Utilities.Modos.Modificar))
            {
                CreateTable();
                textBoxIdFichaPedidosForm.ReadOnly = true;
                dateFechaFichaPedidosForm.Enabled = false;
                buttonSeleccionarUsuarioFichaPedidosForm.Hide();
                Cargar(this.pedido);
            }
        }


        /// <summary>
        /// Método que añade una línea de pedido
        /// </summary>
        /// <param name="articulo">(Articulo) articulo</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void AñadirLineaArticulo(Articulo articulo)
        {
            listLinpeds.Add(new Linped(0, 0, articulo.ArticuloID, articulo.Pvp??0, 0));
            RefreshTable();
        }

        /// <summary>
        /// Método que refresca y actualiza la tabla de líneas de pedido
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void RefreshTable()
        {
            try
            {
                int idLinea = 1;
                dataTable.Clear();
                List<Linped> tmpListLinpeds = new List<Linped>();
                Articulo articulo;
                decimal importe;
                foreach (Linped linped in listLinpeds)
                {
                    articulo = productosNegocio.LeerArticulo(linped.ArticuloID);
                    linped.Linea = idLinea;
                    tmpListLinpeds.Add(linped);
                    importe = linped.Importe;
                    if (linped.Cantidad > 0)
                        importe *= linped.Cantidad;
                    dataTable.Rows.Add(idLinea++, articulo.ArticuloID, articulo.Nombre, linped.Cantidad, importe);
                }

                listLinpeds = tmpListLinpeds;
                UpdateTotales();
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }
        }

        /// <summary>
        /// Método para actualizar los totales del pedido
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void UpdateTotales()
        {
            try
            {
                textBoxBiUsuarioFichaPedidosForm.Text = pedidosNegocio.CalcularBaseImponible(listLinpeds).ToString();
                textBoxIvaUsuarioFichaPedidosForm.Text = pedidosNegocio.GetIva().ToString();
                textBoxTotalIvaUsuarioFichaPedidosForm.Text = pedidosNegocio.CalcularTotalIva(listLinpeds).ToString();
                textBoxImporteTotalUsuarioFichaPedidosForm.Text = pedidosNegocio.CalcularImporteTotal(listLinpeds).ToString();
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }
        }

        /// <summary>
        /// Crea la tabla de pedidos
        /// En este caso se decide crear un DataTable en vez de asignar el DataSource a una lista de objetos como en otros casos
        /// Esto es debido a que queríamos ver y modificar la cantidad y una código y descripción del artículo y la clase Linped solo contiene el string IdArticulo
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void CreateTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Línea", Type.GetType("System.Int32"));
            dataTable.Columns.Add("IdArtículo", Type.GetType("System.String"));
            dataTable.Columns.Add("Descripción", Type.GetType("System.String"));
            dataTable.Columns.Add("Cantidad", Type.GetType("System.Int32"));
            dataTable.Columns.Add("Importe", Type.GetType("System.Decimal"));
            dataGridListaTableViewFichaPedidosForm.DataSource = dataTable;
            dataGridListaTableViewFichaPedidosForm.Columns["Línea"].ReadOnly = true;
            dataGridListaTableViewFichaPedidosForm.Columns["IdArtículo"].ReadOnly = true;
            dataGridListaTableViewFichaPedidosForm.Columns["Descripción"].ReadOnly = true;
            dataGridListaTableViewFichaPedidosForm.Columns["Descripción"].Width = 281;
            dataGridListaTableViewFichaPedidosForm.Columns["Importe"].ReadOnly = true;
        }

        /// <summary>
        /// Método click que abre ventana modal para buscar productos
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonSelectUsuarioFichaProductosForm_Click(object sender, EventArgs e)
        {
            TableViewUsuariosForm f = new TableViewUsuariosForm(Utilities.Modos.Seleccionar, this);
            f.ShowDialog();
        }

        /// <summary>
        /// Método click que abre ventana modal para buscar productos
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonSeleccionarArticuloFichaPedidosForm_Click(object sender, EventArgs e)
        {
            TableViewProductosForm f = new TableViewProductosForm(Utilities.Modos.Seleccionar, this);
            f.ShowDialog();
        }

        /// <summary>
        /// Método click que quita una línea de producto
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonQuitarArticuloFichaPedidosForm_Click(object sender, EventArgs e)
        {
            if(dataGridListaTableViewFichaPedidosForm.CurrentRow != null)
            {
                DataRowView dataRowView = (DataRowView)dataGridListaTableViewFichaPedidosForm.CurrentRow.DataBoundItem;
                int idLinea = Convert.ToInt32(dataRowView.Row.ItemArray[0]);
                listLinpeds.RemoveAt(idLinea - 1);
                RefreshTable();
            }
        }

        /// <summary>
        /// Método click del botón guardar para guardar el pedido
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonGuardarFichaPedidosForm_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxIdFichaPedidosForm.Text))
                MessageBox.Show("Debe seleccionar un Id de pedido antes de poder crear el pedido.");
            else if(String.IsNullOrEmpty(textBoxIdUsuarioFichaPedidosForm.Text))
                MessageBox.Show("Debe seleccionar un usuario antes de poder crear el pedido.");
            else if(listLinpeds.Count.Equals(0))
                MessageBox.Show("Debe introducir al menos una línea de artículo antes de poder crear el pedido.");
            else
            {
                try
                {
                    if (modo.Equals(Utilities.Modos.Insertar))
                    {
                        MessageBox.Show(pedidosNegocio.InsertarPedido(new Pedido(long.Parse(textBoxIdFichaPedidosForm.Text), long.Parse(textBoxIdUsuarioFichaPedidosForm.Text), dateFechaFichaPedidosForm.Value, listLinpeds)));
                    }
                    else if (modo.Equals(Utilities.Modos.Modificar))
                    {
                        MessageBox.Show(pedidosNegocio.ActualizarPedido(new Pedido(long.Parse(textBoxIdFichaPedidosForm.Text), long.Parse(textBoxIdFichaPedidosForm.Text), dateFechaFichaPedidosForm.Value, listLinpeds)));
                    }
                }
                catch (Exception ex)
                {
                    MainForm.MostrarExcepcion(ex);
                }
            }
        }

        /// <summary>
        /// Método que carga un pedido pasado por constructor en el formulario
        /// </summary>
        /// <param name="pedido">(Pedido) pedido</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void Cargar(Pedido pedido)
        {
            try
            {
                textBoxIdFichaPedidosForm.Text = pedido.PedidoID.ToString();
                dateFechaFichaPedidosForm.Value = pedido.Fecha;
                textBoxIdUsuarioFichaPedidosForm.Text = pedido.UsuarioID.ToString();
                Usuario usuario = usuariosNegocio.LeerUsuario(pedido.UsuarioID);
                textBoxNombreUsuarioFichaPedidosForm.Text = usuario.Nombre;

                listLinpeds = pedidosNegocio.LeerLinped(pedido.PedidoID);

                RefreshTable();
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }
        }

        /// <summary>
        /// Método establece y comprueba la cantidad en las líneas de pedido
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void dataGridListaTableViewFichaPedidosForm_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int idLinea = Convert.ToInt32(dataGridListaTableViewFichaPedidosForm.Rows[e.RowIndex].Cells[0].Value);
            int cantidad = 0;
            try
            {
                cantidad = Convert.ToInt32(dataGridListaTableViewFichaPedidosForm.Rows[e.RowIndex].Cells[3].Value);
            }
            catch (FormatException){ }
            listLinpeds[idLinea - 1].Cantidad = cantidad;
            RefreshTable();
        }

        /// <summary>
        /// Método que comprueba que se introduzca un id de pedido correcto
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(KeyPressEventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxIdFichaPedidosForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) ? true : false;
        }


        /// <summary>
        /// Método click del botón cancelar para regresar al formulario anterior
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonCancelarFichaPedidosForm_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}