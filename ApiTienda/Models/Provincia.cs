///<author>Francisco José Ferrer Rodríguez<author>
using System.ComponentModel.DataAnnotations;

namespace API_Tienda.Models
{
    public class Provincia
    {
        [Key]
        public string ProvinciaID { get; set; }
        public string Nombre { get; set; }
    }
}
