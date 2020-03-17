using Capa_entidades;
using Capa_presentacion;
using CapaNegocio;
using CapaPresentacion.Informes;
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

namespace CapaPresentacion
{
    /// <summary>
    /// Clase encargada de la generación de reportes de facturas
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class FacturaForm : Form
    {
        private Pedido pedido;
        private PedidosNegocio pedidosNegocio;
        private ProductosNegocio productosNegocio;
        private UsuariosNegocio usuariosNegocio;
        public List<EFactura> facturas = new List<EFactura>();
        public List<ArticuloFactura> detalles = new List<ArticuloFactura>();
        public List<TotalesFactura> totalesFactura = new List<TotalesFactura>();
        private Usuario usuarioEmpresa;
        private Usuario usuarioCliente;
        private List<Linped> listLinpeds;

        /// <summary>
        /// Constructor de clase FacturaForm
        /// </summary>
        /// <param name="pedido">(Pedido) pedido</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public FacturaForm(Pedido pedido = null)
        {
            if(pedido != null)
            {
                InitializeComponent();
                this.pedido = pedido;

                try
                {
                    pedidosNegocio = new PedidosNegocio();
                    productosNegocio = new ProductosNegocio();
                    usuariosNegocio = new UsuariosNegocio();
                    usuarioEmpresa = LoginForm.GetUsuarioLogado();
                    usuarioCliente = usuariosNegocio.LeerUsuario(pedido.UsuarioID);
                    listLinpeds = pedidosNegocio.LeerLinped(pedido.PedidoID);
                }
                catch (Exception e)
                {
                    MainForm.MostrarExcepcion(e);
                }
                
            }
        }

        /// <summary>
        /// Método load del report
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", facturas));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", detalles));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TotalesFactura", totalesFactura));

            try
            {
                EFactura f1 = new EFactura();
                f1.Nombre = "FACTURA";
                f1.NombreEmpresa = usuarioEmpresa.Nombre;
                f1.DireccionEmpresa = !String.IsNullOrEmpty(usuarioEmpresa.Calle) ? usuarioEmpresa.Calle : usuarioEmpresa.Calle2;

                Provincia provinciaEmpresa = usuariosNegocio.LeerProvincia(usuarioEmpresa.ProvinciaID);
                f1.ProvinciaEmpresa = provinciaEmpresa.Nombre;
                f1.DocumentoEmpresa = usuarioEmpresa.Dni;

                Localidad localidadEmpresa = usuariosNegocio.LeerLocalidad(usuarioEmpresa.ProvinciaID, usuarioEmpresa.PuebloID);
                f1.LocalidadEmpresa = localidadEmpresa.Nombre;
                f1.CpEmpresa = usuarioEmpresa.Codpos;

                f1.NombreCliente = usuarioCliente.Nombre;
                f1.DireccionCliente = !String.IsNullOrEmpty(usuarioCliente.Calle) ? usuarioCliente.Calle : usuarioCliente.Calle2;

                Provincia provinciaCliente = usuariosNegocio.LeerProvincia(usuarioCliente.ProvinciaID);
                f1.ProvinciaCliente = provinciaCliente.Nombre;
                f1.DocumentoCliente = usuarioCliente.Dni;

                Localidad localidadCliente = usuariosNegocio.LeerLocalidad(usuarioCliente.ProvinciaID, usuarioCliente.PuebloID);
                f1.LocalidadCliente = localidadCliente.Nombre;
                f1.CpCliente = usuarioCliente.Codpos;

                facturas.Add(f1);

                f1.NumeroFactura = pedido.PedidoID.ToString();
                f1.FechaFacturacion = pedido.Fecha;

                int idLinea = 1;
                foreach (Linped l in listLinpeds)
                {
                    Articulo a = productosNegocio.LeerArticulo(l.ArticuloID);
                    detalles.Add(new ArticuloFactura(idLinea++, l.Cantidad, a.Nombre, l.Importe, 21, 0, l.Cantidad * l.Importe));
                }

                totalesFactura.Add(new TotalesFactura(pedidosNegocio.CalcularBaseImponible(listLinpeds), pedidosNegocio.GetIva(), pedidosNegocio.CalcularTotalIva(listLinpeds), pedidosNegocio.CalcularImporteTotal(listLinpeds)));

            }
            catch (Exception ex)
            {
                MainForm.MostrarExcepcion(ex);
            }

            reportViewer1.RefreshReport();
        }

    }
}