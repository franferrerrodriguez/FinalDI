///<author>Francisco José Ferrer Rodríguez<author>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Capa_entidades
{
    public class Pedido
    {
        private long _pedidoId;
        private long _usuarioId;
        private DateTime _fecha;
        private List<Linped> _listLinped;
        private Decimal _importeTotal;

        public long PedidoID
        {
            get { return _pedidoId; }
            set { _pedidoId = value; }
        }
        public long UsuarioID
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set {
                if(value == null)
                    throw new Exception(Constants.ERROR_NOTNULL_DATE);
                _fecha = value;
            }
        }
        public List<Linped> ListLinped
        {
            get { return _listLinped; }
            set { _listLinped = value; }
        }
        public Decimal ImporteTotal {
            get { return CalcularImporteTotal(); }
        }

        public Pedido()
        {
            PedidoID = 0;
            UsuarioID = 0;
            Fecha = new DateTime();
            ListLinped = new List<Linped>();
        }

        public Pedido(long pedidoId, long usuarioId, DateTime fecha, List<Linped> listLinped)
        {
            PedidoID = pedidoId;
            UsuarioID = usuarioId;
            Fecha = fecha;
            ListLinped = listLinped;
        }

        public Pedido(Pedido pedido)
        {
            PedidoID = pedido.PedidoID;
            UsuarioID = pedido.UsuarioID;
            Fecha = pedido.Fecha;
            List<Linped> LineasPedido = new List<Linped>();
            foreach (Linped linea in pedido.ListLinped)
                LineasPedido.Add(linea);
            ListLinped = LineasPedido;
        }

        public override string ToString()
        {
            return $"{PedidoID}#{UsuarioID}#{Fecha}#{ImporteTotal}";
        }

        public Decimal CalcularImporteTotal()
        {
            decimal importe = 0;
            foreach (Linped l in ListLinped)
                importe += l.Importe * l.Cantidad;
            _importeTotal = importe;
            return _importeTotal;
        }
    }
}