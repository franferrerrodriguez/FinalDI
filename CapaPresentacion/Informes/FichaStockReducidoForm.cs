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

namespace CapaPresentacion.Informes
{
    /// <summary>
    /// Clase FichaStockReducidoForm
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class FichaStockReducidoForm : Form
    {
        private Utilities.Modos modo;
        private Form formParent;

        /// <summary>
        /// Constructor de clase FichaStockReducidoForm
        /// </summary>
        /// <param name="modo">(Utilities.Modos) modo</param>
        /// <param name="formParent">(Form) formParent</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public FichaStockReducidoForm(Utilities.Modos modo, Form formParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            this.formParent = formParent;
        }

        /// <summary>
        /// Método load del formulario
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void FichaStockReducidoForm_Load(object sender, EventArgs e)
        {
            Utilities.SetTitulo(modo, labelTitleFichaStockReducidoForm, "stock reducido");
        }

        /// <summary>
        /// Método que comprueba que se introduzca stock mínimo correcto
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(KeyPressEventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxFiltrarFichaProductosForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) ? true : false;
        }

        /// <summary>
        /// Método que genera el informe de stock mínimo
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(KeyPressEventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonGuardarFichaStockReducidoForm_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxFichaStockReducidoForm.Text))
            {
                Form f = new StockReducidoForm(Convert.ToInt32(textBoxFichaStockReducidoForm.Text));
                f.Show();
            }
            else
                MessageBox.Show("Debe introducir un límite de stock.");
        }

        /// <summary>
        /// Método click del botón cancelar para regresar al formulario anterior
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonCancelarFichaStockReducidoForm_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
