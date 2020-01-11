///<author>Francisco José Ferrer Rodríguez<author>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{
    public class Tv
    {
        [Key]
        [ForeignKey("articulo")]
        public string TvID { get; set; }
        public string Panel { get; set; }
        public int? Pantalla { get; set; }
        public string Resolucion { get; set; }
        public string Hdreadyfullhd { get; set; }
        public bool? Tdt { get; set; }
    }
}
