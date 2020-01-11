///<author>Francisco José Ferrer Rodríguez<author>
using System.ComponentModel.DataAnnotations;

namespace API_Tienda.Models
{
    public class tipoArticulo
    {
        [Key]
        public int TipoArticuloID { get; set; }
        public string Descripcion { get; set; }
    }
}
