///<author>Francisco José Ferrer Rodríguez<author>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{
    public class Stock
    {
        [Key]
        [ForeignKey("Articulo")]
        public string ArticuloID { get; set; }
        public int? Disponible { get; set; }
        public string Entrega { get; set; }
    }

}
