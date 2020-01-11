///<author>Francisco José Ferrer Rodríguez<author>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{
    public class Memoria
    {

        [Key]
        [ForeignKey("articulo")]
        public string MemoriaID { get; set; }
        public string Tipo { get; set; }
    }
}
