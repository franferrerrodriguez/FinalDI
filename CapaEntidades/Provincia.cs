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
    public class Provincia
    {
        private string _provinciaId;
        private string _nombre;
        private List<Localidad> _listLocalidades;

        public string ProvinciaID
        {
            get { return _provinciaId; }
            set
            {
                _provinciaId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
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
        public List<Localidad> ListLocalidades
        {
            get { return _listLocalidades; }
            set { _listLocalidades = value; }
        }

        public Provincia()
        {
            ProvinciaID = "";
            Nombre = "";
            ListLocalidades = new List<Localidad>();
        }

        public Provincia(string nombre, List<Localidad> listLocalidades)
        {
            Nombre = nombre;
            ListLocalidades = listLocalidades;
        }

        public Provincia(Provincia provincia)
        {
            Nombre = provincia.Nombre;
            ListLocalidades = provincia.ListLocalidades;
        }

        public override string ToString()
        {
            return $"{ProvinciaID}#{Nombre}#{ListLocalidades}";
        }
    }
}