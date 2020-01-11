using Capa_entidades;
using Capa_presentacion;
using CapaNegocio;
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
    /// Clase encargada de la ficha de productos
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class FichaProductosForm : Form
    {
        private Utilities.Modos modo;
        private Form formParent;
        private ProductosNegocio productosNegocio;
        private List<Articulo> listArticulos;

        /// <summary>
        /// Constructor de clase FichaProductosForm
        /// </summary>
        ///  <param name="modo">(Utilities.Modos) modo</param>
        ///  <param name="formParent">(Form) formParent</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public FichaProductosForm(Utilities.Modos modo, Form formParent = null)
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
        private void ConsultarProductosForm_Load(object sender, EventArgs e)
        {
            Utilities.SetTitulo(modo, labelTitleFichaProductosForm, "productos");

            try
            {
                comboBoxFichaProductosForm.DataSource = productosNegocio.LeerTiposArticulos();
                RefreshTable(listArticulos);
            }
            catch (Exception ex)
            {
                MainForm.MostrarExcepcion(ex);
            }

            if (modo.Equals(Utilities.Modos.Seleccionar) || modo.Equals(Utilities.Modos.Consultar))
            {
                textBoxIdFichaProductosForm.ReadOnly = true;
                textBoxNombreFichaProductosForm.ReadOnly = true;
                textBoxMarcaFichaProductosForm.ReadOnly = true;
                textBoxEspecificacionesFichaProductosForm.ReadOnly = true;
                textBoxPvpFichaProductosForm.ReadOnly = true;
                buttonGuardarFichaProductosForm.Hide();
            }
            else if (modo.Equals(Utilities.Modos.Modificar))
            {
                textBoxIdFichaProductosForm.ReadOnly = true;
                textBoxNombreFichaProductosForm.ReadOnly = true;
                textBoxMarcaFichaProductosForm.ReadOnly = true;
                textBoxEspecificacionesFichaProductosForm.ReadOnly = true;
                textBoxPvpFichaProductosForm.ReadOnly = false;
                buttonGuardarFichaProductosForm.Show();
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

            if(listArticulos != null)
            {
                dataGridFichaProductosForm.DataSource = listArticulos;

                dataGridFichaProductosForm.Columns["UrlImagen"].Visible = false;
                dataGridFichaProductosForm.Columns["Imagen"].Visible = false;
                dataGridFichaProductosForm.Columns["TipoArticuloId"].Visible = false;
                dataGridFichaProductosForm.Columns["Especificaciones"].Visible = false;
                dataGridFichaProductosForm.Columns["ArticuloId"].ReadOnly = true;
                dataGridFichaProductosForm.Columns["Nombre"].ReadOnly = true;
                dataGridFichaProductosForm.Columns["MarcaId"].ReadOnly = true;
                dataGridFichaProductosForm.Columns["Pvp"].ReadOnly = true;

                dataGridFichaProductosForm.Refresh();
            }

        }

        /// <summary>
        /// Método keyup para filtrar por nombre de producto
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(KeyEventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxFiltrarConsultarProductos_KeyUp(object sender, KeyEventArgs e)
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
        private void comboBoxTipoArticuloConsultarProductos_SelectedIndexChanged(object sender, EventArgs e)
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
            TipoArticulo tipoArticulo = (TipoArticulo)comboBoxFichaProductosForm.SelectedItem;
            try
            {
                List<Articulo> filtro = productosNegocio.LeerArticulosPorFiltro(listArticulos, textBoxFiltrarFichaProductosForm.Text, tipoArticulo.TipoArticuloID);
                RefreshTable(filtro);
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }
        }

        /// <summary>
        /// Método click para seleccionar artículo de la tabla y hacer la acción correspondiente
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(DataGridViewCellEventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void dataGridFichaProductosForm_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MenuDinamicoCamara(false);
            MenuDinamicoMemoria(false);
            MenuDinamicoObjetivo(false);
            MenuDinamicoTv(false);

            Articulo articulo = (Articulo)dataGridFichaProductosForm.CurrentRow.DataBoundItem;
            textBoxIdFichaProductosForm.Text = articulo.ArticuloID;
            textBoxNombreFichaProductosForm.Text = articulo.Nombre;
            textBoxMarcaFichaProductosForm.Text = articulo.MarcaID;
            textBoxEspecificacionesFichaProductosForm.Text = articulo.Especificaciones;
            textBoxPvpFichaProductosForm.Text = articulo.Pvp.ToString();

            try
            {
                switch (articulo.TipoArticuloID)
                {
                    case 1:
                        Tv tv = productosNegocio.LeerTv(articulo.ArticuloID);
                        MenuDinamicoTv(true);
                        SetValueTextBoxDinamico("Panel", tv.Panel);
                        SetValueTextBoxDinamico("Pantalla", tv.Pantalla.ToString());
                        SetValueTextBoxDinamico("Resolucion", tv.Resolucion);
                        SetValueTextBoxDinamico("HdReadyFullHd", tv.Hdreadyfullhd);
                        SetValueTextBoxDinamico("Tdt", tv.Tdt ? "Si" : "No");
                        break;
                    case 2:
                        Memoria memoria = productosNegocio.LeerMemoria(articulo.ArticuloID);
                        MenuDinamicoMemoria(true);
                        SetValueTextBoxDinamico("Tipo", memoria.Tipo);
                        break;
                    case 3:
                        Camara camara = productosNegocio.LeerCamara(articulo.ArticuloID);
                        MenuDinamicoCamara(true);
                        SetValueTextBoxDinamico("Resolucion", camara.Resolucion);
                        SetValueTextBoxDinamico("Sensor", camara.Sensor);
                        SetValueTextBoxDinamico("Tipo", camara.Tipo);
                        SetValueTextBoxDinamico("Factor", camara.Factor);
                        SetValueTextBoxDinamico("Objetivo", camara.Objetivo);
                        SetValueTextBoxDinamico("Pantalla", camara.Pantalla);
                        SetValueTextBoxDinamico("Zoom", camara.Zoom);
                        break;
                    case 4:
                        Objetivo objetivo = productosNegocio.LeerObjetivo(articulo.ArticuloID);
                        MenuDinamicoObjetivo(true);
                        SetValueTextBoxDinamico("Tipo", objetivo.Tipo);
                        SetValueTextBoxDinamico("Montura", objetivo.Montura);
                        SetValueTextBoxDinamico("Focal", objetivo.Focal);
                        SetValueTextBoxDinamico("Apertura", objetivo.Apertura);
                        SetValueTextBoxDinamico("Especiales", objetivo.Especiales);
                        break;
                }
            }
            catch (Exception ex)
            {
                MainForm.MostrarExcepcion(ex);
            }
        }

        /// <summary>
        /// Método que establecer un valor para los textBox creados dinámicamente
        /// </summary>
        /// <param name="name">(string) name</param>
        /// <param name="value">(string) value</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void SetValueTextBoxDinamico(string name, string value)
        {
            if (Controls.Find("dynamicTextBox" + name, true).Length > 0)
                Controls.Find("dynamicTextBox" + name, true)[0].Text = value;
        }

        /// <summary>
        /// Método que crear el menú dinámico
        /// </summary>
        /// <param name="name1">(string) name1</param>
        /// <param name="title1">(string) title1</param>
        /// <param name="name2">(string) name2</param>
        /// <param name="title2">(string) title2</param>
        /// <param name="x">(int) x</param>
        /// <param name="y">(int) y</param>
        /// <param name="create">(bool) create</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void CreateMenuDinamico(string name1, string title1, string name2, string title2, int x, int y, bool create)
        {
            string prefixLabel = "dynamicLabel";
            string prefixTextbox = "dynamicTextBox";

            if (!String.IsNullOrEmpty(name1))
            {
                Label label1 = new Label();
                label1.Height = 14;
                label1.Width = 100;
                label1.Location = new Point(x, y);
                label1.Text = title1;
                label1.Name = prefixLabel + name1;

                TextBox textBox1 = new TextBox();
                textBox1.Height = 23;
                textBox1.Width = 176;
                textBox1.Location = new Point(x + 3, y + 15);
                textBox1.Name = prefixTextbox + name1;
                textBox1.ReadOnly = true;

                if (create)
                {
                    Controls.Add(label1);
                    Controls.Add(textBox1);
                }
            }

            if (!String.IsNullOrEmpty(name2))
            {
                Label label2 = new Label();
                label2.Height = 14;
                label2.Width = 100;
                label2.Location = new Point(x + 181, y);
                label2.Text = title2;
                label2.Name = prefixLabel + name2;

                TextBox textBox2 = new TextBox();
                textBox2.Height = 23;
                textBox2.Width = 176;
                textBox2.Location = new Point(x + 184, y + 15);
                textBox2.Name = prefixTextbox + name2;
                textBox2.ReadOnly = true;

                if (create)
                {
                    Controls.Add(label2);
                    Controls.Add(textBox2);
                }
            }

            if (create)
            {
                labelDetallesSubtipoFichaProductosForm.Show();
                labelDetallesSubtipoSeparadorFichaProductosForm.Show();
            }
            else
            {
                labelDetallesSubtipoFichaProductosForm.Hide();
                labelDetallesSubtipoSeparadorFichaProductosForm.Hide();
                Controls.Remove(Controls.Find(prefixLabel + name1, true).Length > 0 ? Controls.Find(prefixLabel + name1, true)[0] : null);
                Controls.Remove(Controls.Find(prefixLabel + name2, true).Length > 0 ? Controls.Find(prefixLabel + name2, true)[0] : null);
                Controls.Remove(Controls.Find(prefixTextbox + name1, true).Length > 0 ? Controls.Find(prefixTextbox + name1, true)[0] : null);
                Controls.Remove(Controls.Find(prefixTextbox + name2, true).Length > 0 ? Controls.Find(prefixTextbox + name2, true)[0] : null);
            }
        }

        /// <summary>
        /// Método que crear el menú dinámico para el tipo Camara
        /// </summary>
        /// <param name="create">(bool) create</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void MenuDinamicoCamara(bool create)
        {
            CreateMenuDinamico("Resolucion", "Resolución:", "Sensor", "Sensor:", 382, 275, create);
            CreateMenuDinamico("Tipo", "Tipo:", "Factor", "Factor:", 382, 315, create);
            CreateMenuDinamico("Objetivo", "Objetivo:", "Pantalla", "Pantalla:", 382, 355, create);
            CreateMenuDinamico("Zoom", "Zoom:", "", "", 382, 395, create);
        }

        /// <summary>
        /// Método que crear el menú dinámico para el tipo Memoria
        /// </summary>
        /// <param name="create">(bool) create</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void MenuDinamicoMemoria(bool create)
        {
            CreateMenuDinamico("Tipo", "Tipo:", "", "", 382, 275, create);
        }

        /// <summary>
        /// Método que crear el menú dinámico para el tipo Objetivo
        /// </summary>
        /// <param name="create">(bool) create</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void MenuDinamicoObjetivo(bool create)
        {
            CreateMenuDinamico("Tipo", "Tipo:", "Montura", "Montura:", 382, 275, create);
            CreateMenuDinamico("Focal", "Focal:", "Apertura", "Apertura:", 382, 315, create);
            CreateMenuDinamico("Especiales", "Especiales:", "", "", 382, 355, create);
        }

        /// <summary>
        /// Método que crear el menú dinámico para el tipo Tv
        /// </summary>
        /// <param name="create">(bool) create</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void MenuDinamicoTv(bool create)
        {
            CreateMenuDinamico("Panel", "Panel:", "Pantalla", "Pantalla:", 382, 275, create);
            CreateMenuDinamico("Resolucion", "Resolución:", "HdReadyFullHd", "Hd Ready Full Hd:", 382, 315, create);
            CreateMenuDinamico("Tdt", "Tdt:", "", "", 382, 355, create);
        }

        /// <summary>
        /// Método que comprueba que se introduzca una cantidad correcta
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(KeyPressEventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxPvpFichaProductosForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44 && e.KeyChar != 8) ? true : false;
        }

        /// <summary>
        /// Método click del botón guardar para guardar el producto
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonGuardarFichaProductosForm_Click(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo)dataGridFichaProductosForm.CurrentRow.DataBoundItem;
            try
            {
                articulo.Pvp = Convert.ToDecimal(textBoxPvpFichaProductosForm.Text);
                MessageBox.Show(productosNegocio.ActualizarArticulo(articulo));
                comboBoxFichaProductosForm.SelectedIndex = 0;
                RefreshTable();
            }
            catch (FormatException)
            {
                articulo.Pvp = 0;

            }
            catch (Exception ex)
            {
                MainForm.MostrarExcepcion(ex);
            }

        }

        /// <summary>
        /// Método click del botón cancelar para regresar al formulario anterior
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonCancelarConsultarProductos_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}