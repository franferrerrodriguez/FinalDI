using Capa_entidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentacionWpf
{
    public class ArticuloModel : Articulo
    {
        public string Nombre { get; set; }

        public ArticuloModel(Articulo articulo) : base(articulo)
        {
            Nombre = articulo.Nombre;
        }
    }

    public class TipoArticuloModel : TipoArticulo
    {
        public string Nombre { get; set; }
        public List<ArticuloModel> Articulos { get; set; }

        public TipoArticuloModel(TipoArticulo tipoArticulo, List<ArticuloModel> articulos) : base(tipoArticulo)
        {
            Nombre = tipoArticulo.Descripcion;
            Articulos = articulos;
        }
    }

    public class List : List<TipoArticuloModel>
    {
        public List()
        {
            AddRange(Generate());
        }

        public List<TipoArticuloModel> Generate()
        {
            ProductosNegocio productosNegocio = new ProductosNegocio();

            List<TipoArticulo> listTiposArticulos = productosNegocio.LeerTiposArticulos();
            List<Articulo> listArticulos = productosNegocio.LeerArticulos();

            List<TipoArticuloModel> listTiposArticulosModel = new List<TipoArticuloModel>();
            List<ArticuloModel> listArticulosModel = new List<ArticuloModel>();
            foreach (TipoArticulo tipoArticulo in listTiposArticulos)
            {
                foreach (Articulo articulo in listArticulos)
                    if (tipoArticulo.TipoArticuloID == 0 || tipoArticulo.TipoArticuloID == articulo.TipoArticuloID)
                        listArticulosModel.Add(new ArticuloModel(articulo));
                listTiposArticulosModel.Add(new TipoArticuloModel(tipoArticulo, listArticulosModel));
                listArticulosModel = new List<ArticuloModel>();
            }


            return listTiposArticulosModel;
        }

    }
}