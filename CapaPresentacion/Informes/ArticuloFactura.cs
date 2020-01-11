using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Informes
{
    /// <summary>
    /// Clase ArticuloFactura
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public class ArticuloFactura
    {
        /// <summary>
        /// Constructor de clase ArticuloFactura
        /// </summary>
        /// <param name="idLinea">(int) idLinea</param>
        /// <param name="cantidad">(int) cantidad</param>
        /// <param name="descripcion">(string) descripcion</param>
        /// <param name="importeBruto">(decimal) importeBruto</param>
        /// <param name="iva">(decimal) iva</param>
        /// <param name="totalIva">(decimal) totalIva</param>
        /// <param name="importeTotal">(decimal) importeTotal</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public ArticuloFactura(int idLinea, int cantidad, string descripcion, decimal importeBruto, decimal iva, decimal totalIva, decimal importeTotal)
        {
            IdLinea = idLinea;
            Cantidad = cantidad;
            Descripcion = descripcion;
            ImporteBruto = importeBruto;
            Iva = iva;
            TotalIva = totalIva;
            ImporteTotal = importeTotal;
        }

        public int IdLinea { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal ImporteBruto { get; set; }
        public decimal Iva { get; set; }
        public decimal TotalIva { get; set; }
        public decimal ImporteTotal { get; set; }
    }
}