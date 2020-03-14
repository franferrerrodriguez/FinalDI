using Capa_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class LinpedNegocio
    {
        private long _pedidoId;
        private int _linea;
        private string _articuloId;
        private string _nombreArticulo;
        private decimal _importe;
        private int _cantidad;

        public long PedidoID
        {
            get { return _pedidoId; }
            set { _pedidoId = value; }
        }
        public int Linea
        {
            get { return _linea; }
            set { _linea = value; }
        }
        public string ArticuloID
        {
            get { return _articuloId; }
            set { _articuloId = value; }
        }
        public string NombreArticulo
        {
            get { return _nombreArticulo; }
            set { _nombreArticulo = value; }
        }
        public decimal Importe
        {
            get { return _importe; }
            set { _importe = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public LinpedNegocio(Linped linped, Articulo articulo)
        {
            PedidoID = linped.PedidoID;
            Linea = linped.Linea;
            ArticuloID = linped.ArticuloID;
            NombreArticulo = articulo.Nombre;
            Importe = linped.Importe;
            Cantidad = linped.Cantidad;
        }

        public static List<LinpedNegocio> GenerarListLinped(List<Linped> listLinpeds)
        {
            List<LinpedNegocio> list = new List<LinpedNegocio>();
            ProductosNegocio productosNegocio = new ProductosNegocio();
            foreach (Linped linped in listLinpeds)
            {
                list.Add(new LinpedNegocio(linped, productosNegocio.LeerArticulo(linped.ArticuloID)));
            }
            return list;
        }
    }
}