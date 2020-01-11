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
using System.Windows.Forms.DataVisualization.Charting;
using Utils;

namespace CapaPresentacion.Estadisticas
{
    /// <summary>
    /// Clase encargada de la ficha de estadísticas de pedidos por días del mes
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class FichaEstadisticasPedidosDiaMes : Form
    {
        private Utilities.Modos modo;
        private Form formParent;
        private PedidosNegocio pedidosNegocio;
        private ProductosNegocio productosNegocio;
        private string[] meses;
        private string[] anos;
        private int mes;
        private int ano;

        /// <summary>
        /// Constructor de clase FichaEstadisticasPedidosDiaMes
        /// </summary>
        /// <param name="modo">(Utilities.Modos) modo</param>
        /// <param name="formParent">(Form) formParent</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public FichaEstadisticasPedidosDiaMes(Utilities.Modos modo, Form formParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            this.formParent = formParent;

            try
            {
                pedidosNegocio = new PedidosNegocio();
                productosNegocio = new ProductosNegocio();
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
        private void FichaEstadisticasPedidosMes_Load(object sender, EventArgs e)
        {
            Utilities.SetTitulo(modo, labelTitleFichaEstadisticasDiaMesForm, "pedidos por días");

            chartNumeroPedidosMes.Titles.Add("Pedidos por días (Mes-Año)");

            meses = Utilities.GetMeses();
            comboBoxMesFichaEstadisticasNumeroPedidosMes.Items.AddRange(meses);
            comboBoxMesFichaEstadisticasNumeroPedidosMes.SelectedIndex = DateTime.Now.Month - 1;
            mes = comboBoxMesFichaEstadisticasNumeroPedidosMes.SelectedIndex + 1;

            anos = Utilities.GetAnos();
            comboBoxAnoFichaEstadisticasNumeroPedidosMes.Items.AddRange(anos);
            comboBoxAnoFichaEstadisticasNumeroPedidosMes.SelectedIndex = 0;
            ano = Convert.ToInt32(comboBoxAnoFichaEstadisticasNumeroPedidosMes.SelectedItem.ToString());

            RefreshChart();
        }

        /// <summary>
        /// Método que refresca el gráfico
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void RefreshChart()
        {
            try
            {
                chartNumeroPedidosMes.Series[0].Points.Clear();

                int numDays = DateTime.DaysInMonth(new DateTime(ano, 1, 1).Year, new DateTime(9999, mes, 1).Month);
                int[] days = new int[numDays];

                DateTime fechaInicio = new DateTime(ano, mes, 1);
                DateTime fechaFin = new DateTime(ano, mes, days.Length);

                double[] puntos = pedidosNegocio.LeerPedidosEntreFechas(fechaInicio, fechaFin);

                for (int i = 0; i < days.Length; i++)
                {
                    Series series = chartNumeroPedidosMes.Series[0];
                    chartNumeroPedidosMes.Series[0].Points.AddXY(days[i], puntos[i]);
                }
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }
        }

        /// <summary>
        /// Método changeCommited del mes que refresca el gráfico
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void comboBoxMesFichaEstadisticasDiaMesForm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            mes = comboBoxMesFichaEstadisticasNumeroPedidosMes.SelectedIndex + 1;
            RefreshChart();
        }

        /// <summary>
        /// Método changeCommited del año que refresca el gráfico
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void comboBoxAnoFichaEstadisticasDiaMesForm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ano = Convert.ToInt32(comboBoxAnoFichaEstadisticasNumeroPedidosMes.SelectedItem.ToString());
            RefreshChart();
        }

        /// <summary>
        /// Método click del botón cancelar para regresar al formulario anterior
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void buttonCancelarFichaEstadisticasDiaMesForm_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}