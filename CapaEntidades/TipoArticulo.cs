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
    public class TipoArticulo
    {
        private int _tipoArticuloId;
        private string _descripcion;

        public int TipoArticuloID
        {
            get { return _tipoArticuloId; }
            set { _tipoArticuloId = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }

        public TipoArticulo()
        {
            TipoArticuloID = 0;
            Descripcion = "";
        }

        public TipoArticulo(int tipoArticuloId, string descripcion)
        {
            TipoArticuloID = tipoArticuloId;
            Descripcion = descripcion;
        }

        public TipoArticulo(TipoArticulo tipoArticulo)
        {
            TipoArticuloID = tipoArticulo.TipoArticuloID;
            Descripcion = tipoArticulo.Descripcion;
        }

        public override string ToString()
        {
            return $"{TipoArticuloID}#{Descripcion}";
        }

    }
}
