///<author>Francisco José Ferrer Rodríguez<author>
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{
    public class Camara
    {
        [Key]
        [ForeignKey("articulo")]
        public string CamaraID { get; set; }
        public string Resolucion { get; set; }
        public string Sensor { get; set; }
        public string Tipo { get; set; }
        public string Factor { get; set; }
        public string Objetivo{ get; set;}
        public string Pantalla { get; set; }
        public string Zoom { get; set; }
    }
}
