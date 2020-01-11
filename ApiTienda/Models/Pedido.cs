///<author>Francisco José Ferrer Rodríguez<author>
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tienda.Models
{
    public class Pedido
    {
        [Key]
        public long PedidoID { get; set; }
        [ForeignKey("Usuario")]
        public long UsuarioID { get; set; }
        public DateTime Fecha { get; set; }
    }
}
