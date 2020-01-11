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
    public class Linped
    {
        private long _pedidoId;
        private int _linea;
        private string _articuloId;
        private decimal _importe;
        private int _cantidad;

        public long PedidoID
        {
            get { return _pedidoId; }
            set { _pedidoId = value; }
        }
        public int Linea {
            get { return _linea; }
            set { _linea = value; }
        }
        public string ArticuloID {
            get { return _articuloId; }
            set
            {
                _articuloId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public decimal Importe {
            get { return _importe; }
            set { _importe = value; }
        }
        public int Cantidad {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public Linped()
        {
            PedidoID = 0;
            Linea = 0;
            ArticuloID = "";
            Importe = 0;
            Cantidad = 0;
        }

        public Linped(long pedidoId, int linea, string articuloId, decimal importe, int cantidad)
        {
            PedidoID = pedidoId;
            Linea = linea;
            ArticuloID = articuloId;
            Importe = importe;
            Cantidad = cantidad;
        }

        public Linped(Linped linped)
        {
            PedidoID = linped.PedidoID;
            Linea = linped.Linea;
            ArticuloID = linped.ArticuloID;
            Importe = linped.Importe;
            Cantidad = linped.Cantidad;
        }

        public override string ToString()
        {
            return $"{PedidoID}#{Linea}#{ArticuloID}#{Importe}#{Cantidad}";
        }
    }
}
