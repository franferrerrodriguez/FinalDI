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
using System.Windows.Forms.DataVisualization.Charting;
using Utils;

namespace CapaPresentacion.Estadisticas
{
    /// <summary>
    /// Clase encargada de la ficha de estadísticas de artículos vendidos por tipo en un mes y año concreto
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class FichaEstadisticasArticulosVendidos : Form
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
        /// Constructor de clase FichaEstadisticasArticulosVendidos
        /// </summary>
        ///  <param name="modo">(Utilities.Modos) modo</param>
        ///  <param name="formParent">(Form) formParent</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public FichaEstadisticasArticulosVendidos(Utilities.Modos modo, Form formParent = null)
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
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void FichaEstadisticasArticulosVendidos_Load(object sender, EventArgs e)
        {
            Utilities.SetTitulo(modo, labelTitleEstadisticasArticulosVendidosForm, "artículos vendidos por tipo");

            chartArticulosVendidos.Titles.Add("Artículos vendidos por tipo (Mes-Año)");

            meses = Utilities.GetMeses();
            comboBoxMesFichaEstadisticasArticulosVendidos.Items.AddRange(meses);
            comboBoxMesFichaEstadisticasArticulosVendidos.SelectedIndex = DateTime.Now.Month - 1;
            mes = comboBoxMesFichaEstadisticasArticulosVendidos.SelectedIndex + 1;

            anos = Utilities.GetAnos();
            comboBoxAnoFichaEstadisticasArticulosVendidos.Items.AddRange(anos);
            comboBoxAnoFichaEstadisticasArticulosVendidos.SelectedIndex = 0;
            ano = Convert.ToInt32(comboBoxAnoFichaEstadisticasArticulosVendidos.SelectedItem.ToString());

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
                chartArticulosVendidos.Series[0].Points.Clear();

                chartArticulosVendidos.Palette = ChartColorPalette.Pastel;

                int numDays = DateTime.DaysInMonth(new DateTime(ano, 1, 1).Year, new DateTime(9999, mes, 1).Month);
                int[] days = new int[numDays];

                DateTime fechaInicio = new DateTime(ano, mes, 1);
                DateTime fechaFin = new DateTime(ano, mes, days.Length);

                double[] puntos = pedidosNegocio.TotalPedidosPorTipoFecha(fechaInicio, fechaFin);

                int i = 0;
                foreach (TipoArticulo ta in productosNegocio.LeerTiposArticulos())
                    if (ta.TipoArticuloID > 0)
                    {
                        Series series = chartArticulosVendidos.Series[0];
                        chartArticulosVendidos.Series[0]["PieLabelStyle"] = "Disabled";
                        double porcentaje = puntos[i] == 0 ? 0 : Math.Round(puntos[i] * 100 / puntos.Sum(), 2);
                        chartArticulosVendidos.Series[0].Points.AddXY($"{ta.Descripcion} - {puntos[i]} ({porcentaje}%)", $"{puntos[i]}");
                        i++;
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
        private void comboBoxMesFichaEstadisticasArticulosVendidosForm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            mes = comboBoxMesFichaEstadisticasArticulosVendidos.SelectedIndex + 1;
            RefreshChart();
        }

        /// <summary>
        /// Método changeCommited del año que refresca el gráfico
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void comboBoxAnoFichaEstadisticasArticulosVendidosForm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ano = Convert.ToInt32(comboBoxAnoFichaEstadisticasArticulosVendidos.SelectedItem.ToString());
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