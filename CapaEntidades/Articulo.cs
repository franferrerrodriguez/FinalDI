///<author>Francisco José Ferrer Rodríguez<author>
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Capa_entidades
{
    public class Articulo
    {
        private string _articuloId;
        private string _nombre;
        private decimal? _pvp;
        private string _marcaId;
        private byte[] _image;
        private string _urlImagen;
        private string _especificaciones;
        private long? _tipoArticuloId;

        public string ArticuloID
        {
            get { return _articuloId; }
            set {
                _articuloId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public decimal? Pvp
        {
            get { return _pvp; }
            set { _pvp = value; }
        }
        public string MarcaID
        {
            get { return _marcaId; }
            set { _marcaId = value; }
        }
        public byte[] Imagen
        {
            get { return _image; }
            set { _image = value; }
        }
        public string UrlImagen
        {
            get { return _urlImagen; }
            set { _urlImagen = value; }
        }
        public string Especificaciones
        {
            get { return _especificaciones; }
            set { _especificaciones = value; }
        }
        public long? TipoArticuloID
        {
            get { return _tipoArticuloId; }
            set { _tipoArticuloId = value; }
        }

        public Articulo()
        {
            ArticuloID = "";
            Nombre = "";
            Pvp = 0;
            MarcaID = "";
            Imagen = new byte[0];
            UrlImagen = "";
            Especificaciones = "";
            TipoArticuloID = 0;
        }

        public Articulo(string articuloId, string nombre, decimal? pvp, string marcaId, byte[] image,
            string urlImagen, string especificaciones, long? tipoArticuloId)
        {
            ArticuloID = articuloId;
            Nombre = nombre;
            Pvp = pvp;
            MarcaID = marcaId;
            Imagen = image;
            UrlImagen = urlImagen;
            Especificaciones = especificaciones;
            TipoArticuloID = tipoArticuloId;
        }

        public Articulo(Articulo articulo)
        {
            ArticuloID = articulo.ArticuloID;
            Nombre = articulo.Nombre;
            Pvp = articulo.Pvp;
            MarcaID = articulo.MarcaID;

            if(articulo.Imagen != null)
            {
                byte[] Image = new byte[articulo.Imagen.Length];
                for (int i = 0; i < Image.Length; i++)
                    Image[i] = articulo.Imagen[i];
                Imagen = Image;
            }

            UrlImagen = articulo.UrlImagen;
            Especificaciones = articulo.Especificaciones;
            TipoArticuloID = articulo.TipoArticuloID;
        }

        public override string ToString()
        {
            return $"{ArticuloID}#{Nombre}#{Pvp}#{MarcaID}#{Imagen}#{UrlImagen}#{Especificaciones}#{TipoArticuloID}";
        }
    }
}
