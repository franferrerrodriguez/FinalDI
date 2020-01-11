using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Informes
{
    /// <summary>
    /// Clase EFactura
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public class EFactura
    {
        public string Nombre { get; set; }
        public string NombreEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string LocalidadEmpresa { get; set; }
        public string CpEmpresa { get; set; }
        public string ProvinciaEmpresa { get; set; }
        public string DocumentoEmpresa { get; set; }
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string LocalidadCliente { get; set; }
        public string CpCliente { get; set; }
        public string ProvinciaCliente { get; set; }
        public string DocumentoCliente { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaFacturacion { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal Iva { get; set; }
        public decimal TotalIva { get; set; }
        public decimal TotalFactura { get; set; }
    }
}