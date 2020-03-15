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
    /// Clase encargada de la lógica de negocio de productos
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public class ProductosNegocio
    {
        private ArticuloADO articuloAdo;
        private StockADO stockAdo;
        private CamaraADO camaraAdo;
        private MemoriaADO memoriaAdo;
        private ObjetivoADO objetivoAdo;
        private TvADO tvAdo;
        private TipoArticuloADO tipoArticuloAdo;

        /// <summary>
        /// Constructor de clase ProductosNegocio
        /// </summary>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public ProductosNegocio()
        {
            articuloAdo = new ArticuloADO();
            stockAdo = new StockADO();
            camaraAdo = new CamaraADO();
            memoriaAdo = new MemoriaADO();
            objetivoAdo = new ObjetivoADO();
            tvAdo = new TvADO();
            tipoArticuloAdo = new TipoArticuloADO();
        }
        /// <summary>
        /// Método encargado de leer artículos
        /// </summary>
        /// <returns>List<Articulo></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Articulo> LeerArticulos()
        {
            try
            {
                return articuloAdo.LeerArticulos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer artículo
        /// </summary>
        ///  <param name="id">(string) id</param>
        /// <returns>Articulo</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Articulo LeerArticulo(string id)
        {
            try
            {
                return articuloAdo.LeerArticulo(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer cámara
        /// </summary>
        ///  <param name="id">(string) id</param>
        /// <returns>Articulo</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Camara LeerCamara(string id)
        {
            try
            {
                return camaraAdo.LeerCamara(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer memoria
        /// </summary>
        ///  <param name="id">(string) id</param>
        /// <returns>Articulo</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Memoria LeerMemoria(string id)
        {
            try
            {
                return memoriaAdo.LeerMemoria(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer objetivo
        /// </summary>
        ///  <param name="id">(string) id</param>
        /// <returns>Articulo</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Objetivo LeerObjetivo(string id)
        {
            try
            {
                return objetivoAdo.LeerObjetivo(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer tv
        /// </summary>
        ///  <param name="id">(string) id</param>
        /// <returns>Articulo</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Tv LeerTv(string id)
        {
            try
            {
                return tvAdo.LeerTv(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer artículos filtrando por nombre y tipoArticulo
        /// </summary>
        ///  <param name="listArticulos">(List<Articulo>) listArticulos</param>
        ///  <param name="nombre">(string) nombre</param>
        ///  <param name="tipoArticulo">(string) tipoArticulo</param>
        /// <returns>List<Articulo></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Articulo> LeerArticulosPorFiltro(List<Articulo> listArticulos, string nombre, long tipoArticulo)
        {
            try
            {
                if(!nombre.Equals(""))
                    listArticulos = articuloAdo.FiltrarPorNombre(listArticulos, nombre);
                listArticulos = articuloAdo.FiltrarPorTipo(listArticulos, tipoArticulo);
                return listArticulos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer tipos de artículos pedidos
        /// </summary>
        /// <returns>List<TipoArticulo></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<TipoArticulo> LeerTiposArticulos()
        {
            try
            {
                List<TipoArticulo> listTipoArticulo = new List<TipoArticulo>();
                listTipoArticulo.Add(new TipoArticulo(0, "Todos los artículos"));
                foreach (TipoArticulo t in tipoArticuloAdo.LeerTipoArticulos())
                    listTipoArticulo.Add(t);
                return listTipoArticulo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de actualizar pedido
        ///  <param name="articulo">(Articulo) articulo</param>
        /// </summary>
        /// <returns>string</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public string ActualizarArticulo(Articulo articulo)
        {
            try
            {
                if (articuloAdo.ActualizarArticulo(articulo))
                    return Constants.OK_MODIFICACION;
                else
                    return Constants.ERROR_INSERCION_DESCONOCIDO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer stock
        /// </summary>
        /// <returns>List<Stock></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Stock> LeerStocks()
        {
            try
            {
                return stockAdo.LeerStocks();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}

public class SubProductoDinamico
{
    public string NombreLabelLeft { get; set; }
    public string ValueTextBoxLeft { get; set; }
    public string NombreLabelRight { get; set; }
    public string ValueTextBoxRight { get; set; }

    public SubProductoDinamico(string nombreLabelLeft, string valueTextBoxLeft)
    {
        NombreLabelLeft = nombreLabelLeft;
        ValueTextBoxLeft = valueTextBoxLeft;
    }

    public SubProductoDinamico(string nombreLabelLeft, string valueTextBoxLeft, string nombreLabelRight, string valueTextBoxRight)
    {
        NombreLabelLeft = nombreLabelLeft;
        ValueTextBoxLeft = valueTextBoxLeft;
        NombreLabelRight = nombreLabelRight;
        ValueTextBoxRight = valueTextBoxRight;
    }

}