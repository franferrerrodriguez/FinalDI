///<author>Francisco José Ferrer Rodríguez<author>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{

    // Lineas de pedido
    public class Linped
    {
        [ForeignKey("Pedido")]
        public long PedidoID { get; set; }
        [Key]
        public int Linea { get; set; }
        [ForeignKey("Articulo")]
        public string ArticuloID { get; set; }
        public decimal Importe { get; set; }
        public int Cantidad { get; set; }
    }
}
