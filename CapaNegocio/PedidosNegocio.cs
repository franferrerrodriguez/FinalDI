using Capa_datos;
using Capa_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CapaNegocio
{
    /// <summary>
    /// Clase encargada de la lógica de negocio de pedidos
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public class PedidosNegocio
    {
        private PedidoADO pedidoAdo;
        private ArticuloADO articuloAdo;
        private TipoArticuloADO tipoArticuloAdo;
        private LinpedADO linpedAdo;
        private UsuarioADO usuariosADO;
        private decimal iva;

        /// <summary>
        /// Constructor de clase PedidosNegocio
        /// </summary>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public PedidosNegocio()
        {
            pedidoAdo = new PedidoADO();
            articuloAdo = new ArticuloADO();
            tipoArticuloAdo = new TipoArticuloADO();
            linpedAdo = new LinpedADO();
            usuariosADO = new UsuarioADO();
            iva = 21;
        }

        /// <summary>
        /// Método encargado de leer pedidos por filtro
        /// </summary>
        ///  <param name="listPedidos">(List<Pedido>) listPedidos</param>
        ///  <param name="usuarioId">(string) usuarioId</param>
        ///  <param name="fechaInicio">(DateTime) fechaInicio</param>
        ///  <param name="fechaFin">(DateTime) fechaFin</param>
        /// <returns>List<Pedido></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Pedido> LeerPedidosPorFiltro(List<Pedido> listPedidos, string usuarioId, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (!String.IsNullOrEmpty(usuarioId))
                    listPedidos = FiltrarPedidoPorUsuario(listPedidos, long.Parse(usuarioId));
                listPedidos = FiltrarPedidoEntreFechas(listPedidos, fechaInicio, fechaFin);
                return listPedidos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer pedidos
        /// </summary>
        /// <returns>List<Pedido></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Pedido> LeerPedidos()
        {
            try
            {
                return pedidoAdo.LeerPedidos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Método encargado de leer líneas de pedido
        /// </summary>
        /// <returns>List<Linped></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Linped> LeerLinpeds()
        {
            try
            {
                return linpedAdo.LeerLinpeds();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer línea de pedido
        /// </summary>
        /// <param name="pedidoId">(long) pedidoId</param>
        /// <returns>Linped</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Linped> LeerLinped(long pedidoId)
        {
            try
            {
                return linpedAdo.LeerLinped(pedidoId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de obtener el iva
        /// </summary>
        /// <returns>decimal</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public decimal GetIva()
        {
            return iva;
        }

        /// <summary>
        /// Método encargado de calcular la base imponible
        /// </summary>
        /// <param name="listLinpeds">(List<Linped>) listLinpeds</param>
        /// <returns>decimal</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public decimal CalcularBaseImponible(List<Linped> listLinpeds)
        {
            decimal importe = 0;
            foreach (Linped l in listLinpeds)
                importe += l.Cantidad * l.Importe;
            return Math.Round(importe, 2);
        }

        /// <summary>
        /// Método encargado de calcular el total iva
        /// </summary>
        /// <param name="listLinpeds">(List<Linped>) listLinpeds</param>
        /// <returns>decimal</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public decimal CalcularTotalIva(List<Linped> listLinpeds)
        {
            decimal importe = 0;
            foreach (Linped l in listLinpeds)
                importe += CalcularIva(l.Cantidad * l.Importe);
            return Math.Round(importe, 2);
        }

        /// <summary>
        /// Método encargado de calcular el importe total
        /// </summary>
        /// <param name="listLinpeds">(List<Linped>) listLinpeds</param>
        /// <returns>decimal</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public decimal CalcularImporteTotal(List<Linped> listLinpeds)
        {
            decimal importe = 0;
            foreach (Linped l in listLinpeds)
                importe += l.Cantidad * l.Importe + CalcularIva(l.Cantidad * l.Importe);
            return Math.Round(importe, 2);
        }

        /// <summary>
        /// Método encargado de calcular el iva de un importe dado
        /// </summary>
        /// <param name="importe">(decimal) importe</param>
        /// <returns>decimal</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public decimal CalcularIva(decimal importe)
        {
            return (importe * (1 + (iva / 100))) - importe;
        }

        /// <summary>
        /// Método encargado de insertar un pedido
        /// </summary>
        /// <param name="pedido">(Pedido) pedido</param>
        /// <returns>string</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public string InsertarPedido(Pedido pedido)
        {
            try
            {
                if (ExistePedido(pedido))
                    return Constants.ERROR_INSERCION_DUPLICADO;
                else if (pedidoAdo.InsertarPedido(pedido) == null)
                    return Constants.ERROR_INSERCION_DESCONOCIDO;
                else
                {
                    foreach (Linped l in pedido.ListLinped)
                    {
                        l.PedidoID = pedido.PedidoID;
                        linpedAdo.InsertarLinped(l);
                    }
                    return Constants.OK_INSERCION;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de actualizar un pedido
        /// </summary>
        /// <param name="pedido">(Pedido) pedido</param>
        /// <returns>string</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public string ActualizarPedido(Pedido pedido)
        {
            try
            {
                if (ExistePedido(pedido) && pedidoAdo.ActualizarPedido(pedido) && linpedAdo.BorrarLinpedsByPedido(pedido.PedidoID))
                {
                    foreach (Linped l in pedido.ListLinped)
                    {
                        l.PedidoID = pedido.PedidoID;
                        linpedAdo.InsertarLinped(l);
                    }
                    return Constants.OK_MODIFICACION;
                }
                else
                    return Constants.ERROR_INSERCION_DESCONOCIDO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de eliminar un pedido
        /// </summary>
        /// <param name="pedido">(Pedido) pedido</param>
        /// <returns>string</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public string EliminarPedido(Pedido pedido)
        {
            try
            {
                if (pedidoAdo.BorrarPedido(pedido.PedidoID) && linpedAdo.BorrarLinpedsByPedido(pedido.PedidoID))
                    return Constants.OK_BORRADO;
                else
                    return Constants.ERROR_BORRADO_DESCONOCIDO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de comprobar si existe un pedido
        /// </summary>
        /// <param name="pedido">(Pedido) pedido</param>
        /// <returns>bool</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public bool ExistePedido(Pedido pedido)
        {
            foreach (Pedido p in LeerPedidos())
                if (p.PedidoID.Equals(pedido.PedidoID))
                    return true;
            return false;
        }

        /// <summary>
        /// Método encargado de obtener los totales de un pedido en formato para gráficas
        /// </summary>
        /// <param name="fechaInicio">(DateTime) fechaInicio</param>
        /// <param name="fechaFin">(DateTime) fechaFin</param>
        /// <returns>double[]</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public double[] TotalPedidosPorTipoFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                List<TipoArticulo> listTiposArticulo = tipoArticuloAdo.LeerTipoArticulos();
                List<Pedido> listPedidos = FiltrarPedidoEntreFechas(pedidoAdo.LeerPedidos(), fechaInicio, fechaFin);
                double[] totalPedidos = new double[listTiposArticulo.Count];

                foreach (Pedido pedido in listPedidos)
                    foreach (Linped l in linpedAdo.LeerLinped(pedido.PedidoID))
                    {
                        Articulo articulo = articuloAdo.LeerArticulo(l.ArticuloID);
                        foreach (TipoArticulo ta in listTiposArticulo)
                            if (articulo.TipoArticuloID == ta.TipoArticuloID)
                                totalPedidos[ta.TipoArticuloID - 1] += l.Cantidad;
                    }
                return totalPedidos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado obtener pedidos entre dos fechas
        /// </summary>
        /// <param name="fechaInicio">(DateTime) fechaInicio</param>
        /// <param name="fechaFin">(DateTime) fechaFin</param>
        /// <returns>double[]</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public double[] LeerPedidosEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                List<Pedido> listPedidos = FiltrarPedidoEntreFechas(pedidoAdo.LeerPedidos(), fechaInicio, fechaFin);
                double[] pedidos = new double[fechaFin.Day];
                int count;
                for (int i = 0; i < fechaFin.Day; i++)
                {
                    count = 0;
                    foreach (Pedido p in listPedidos)
                    {
                        if (p.Fecha.Day.Equals(i + 1))
                            count++;
                        pedidos[i] = count;
                    }
                }
                return pedidos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado obtener pedidos por usuarioId
        /// </summary>
        /// <param name="listPedidos">(List<Pedido>) listPedidos</param>
        /// <param name="usuarioId">(long) usuarioId</param>
        /// <returns>List<Pedido></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Pedido> FiltrarPedidoPorUsuario(List<Pedido> listPedidos, long usuarioId)
        {
            List<Pedido> tmpListPedidos = new List<Pedido>();
            foreach (Pedido pedido in listPedidos)
                if (pedido.UsuarioID.Equals(usuarioId))
                    tmpListPedidos.Add(pedido);
            return tmpListPedidos;
        }

        /// <summary>
        /// Método encargado filtrar pedidos entre dos fechas
        /// </summary>
        /// <param name="listPedidos">(List<Pedido>) listPedidos</param>
        /// <param name="fechaInicio">(DateTime) fechaInicio</param>
        /// <param name="fechaFin">(DateTime) fechaFin</param>
        /// <returns>List<Pedido></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Pedido> FiltrarPedidoEntreFechas(List<Pedido> listPedidos, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Pedido> tmpListPedidos = new List<Pedido>();
            foreach (Pedido pedido in listPedidos)
                if (pedido.Fecha >= fechaInicio && pedido.Fecha <= fechaFin)
                    tmpListPedidos.Add(pedido);
            return tmpListPedidos;
        }

        public long Max()
        {
            return pedidoAdo.Max();
        }

    }
}