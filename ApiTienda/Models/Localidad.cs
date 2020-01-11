///<author>Francisco José Ferrer Rodríguez<author>
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{
    public class Localidad
    {
        public string LocalidadID { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Provincia")]
        public string ProvinciaID { get; set; }
    }
}