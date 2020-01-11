using Capa_entidades;
using Capa_presentacion;
using CapaNegocio;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    /// <summary>
    /// Clase encargada de la generación de reportes de stock reducido
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class StockReducidoForm : Form
    {
        private int limiteStock;
        public List<Articulo> articulos = new List<Articulo>();
        public List<Stock> stock = new List<Stock>();
        public ProductosNegocio productosNegocio;

        /// <summary>
        /// Constructor de clase StockReducidoForm
        /// </summary>
        /// <param name="limiteStock">(int) limiteStock</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public StockReducidoForm(int limiteStock)
        {
            InitializeComponent();
            this.limiteStock = limiteStock;

            try
            {
                productosNegocio = new ProductosNegocio();
                stock = productosNegocio.LeerStocks();
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }

        }

        /// <summary>
        /// Método load del report
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void StockReducidoForm_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            try
            {
                ReportParameter anyPara = new ReportParameter("limiteStock", limiteStock.ToString());

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { anyPara });

                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", articulos));

                foreach (Stock s in stock)
                    if (s.Disponible <= limiteStock)
                        articulos.Add(productosNegocio.LeerArticulo(s.ArticuloID));
            }
            catch (Exception ex)
            {
                MainForm.MostrarExcepcion(ex);
            }

            reportViewer1.RefreshReport();
        }
    }
}