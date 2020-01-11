///<author>Francisco José Ferrer Rodríguez<author>
using System.ComponentModel.DataAnnotations;

namespace API_Tienda.Models
{
    public class Marca
    {
        [Key]
        public string MarcaID { get; set; }
        public string Empresa { get; set; }
        public byte[] Logo { get; set; }
    }
}
