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
    public class Localidad
    {
        private string _localidadId;
        private string _nombre;
        private string _provinciaId;

        public string LocalidadID
        {
            get { return _localidadId; }
            set
            {
                _localidadId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string ProvinciaID
        {
            get { return _provinciaId; }
            set
            {
                _provinciaId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }

        public Localidad()
        {
            LocalidadID = "";
            Nombre = "";
            ProvinciaID = "";
        }

        public Localidad(string nombre, string provinciaId)
        {
            Nombre = nombre;
            ProvinciaID = provinciaId;
        }

        public Localidad(Localidad localidad)
        {
            Nombre = localidad.Nombre;
            ProvinciaID = localidad.ProvinciaID;
        }

        public override string ToString()
        {
            return $"{LocalidadID}#{Nombre}#{ProvinciaID}";
        }
    }
}