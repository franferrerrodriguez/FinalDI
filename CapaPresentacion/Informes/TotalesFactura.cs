using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Informes
{
    public class TotalesFactura
    {
        public TotalesFactura()
        {

        }

        public TotalesFactura(decimal baseImponible, decimal iva, decimal totalIva, decimal totalFactura)
        {
            BaseImponible = baseImponible;
            Iva = iva;
            TotalIva = totalIva;
            TotalFactura = totalFactura;
        }

        public decimal BaseImponible { get; set; }
        public decimal Iva { get; set; }
        public decimal TotalIva { get; set; }
        public decimal TotalFactura { get; set; }
    }
}