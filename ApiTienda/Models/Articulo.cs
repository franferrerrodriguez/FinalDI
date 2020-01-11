///<author>Francisco José Ferrer Rodríguez<author>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{
    // Articulo
    public class Articulo
    {
        [Key]
        public string ArticuloID { get; set; }
        public string Nombre { get; set; }
        public decimal? Pvp { get; set; }
        [ForeignKey("marca")]
        public string MarcaID { get; set; }
        public byte[] Imagen { get; set; }
        public string Urlimagen { get; set; }
        public string Especificaciones { get; set; }
        [ForeignKey("tipoArticulo")]
        public int? TipoArticuloID { get; set; }
    }
}
