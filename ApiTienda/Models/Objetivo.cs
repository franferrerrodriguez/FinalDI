///<author>Francisco José Ferrer Rodríguez<author>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{
    public class Objetivo
    {
        [Key]
        [ForeignKey("articulo")]
        public string ObjetivoID { get; set; }
        public string Tipo { get; set; }
        public string Montura { get; set; }
        public string Focal { get; set; }
        public string Apertura { get; set; }
        public string Especiales { get; set; }
    }
}
