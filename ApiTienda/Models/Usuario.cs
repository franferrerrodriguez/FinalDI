///<author>Francisco José Ferrer Rodríguez<author>
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{
    public class Usuario
    {
        [Key]
        public long UsuarioID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string Calle2 { get; set; }
        public string Codpos { get; set; }
        [ForeignKey("localidad")]
        public string PuebloID { get; set; }
        [ForeignKey("provincia")]
        public string ProvinciaID { get; set; }
        public DateTime? Nacido { get; set; }
    }
}
