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
    public class Camara
    {
        private string _camaraId;
        private string _resolucion;
        private string _sensor;
        private string _tipo;
        private string _factor;
        private string _objetivo;
        private string _pantalla;
        private string _zoom;

        public string CamaraID
        {
            get { return _camaraId; }
            set
            {
                _camaraId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Resolucion
        {
            get { return _resolucion; }
            set { _resolucion = value; }
        }
        public string Sensor
        {
            get { return _sensor; }
            set { _sensor = value; }
        }
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public string Factor
        {
            get { return _factor; }
            set { _factor = value; }
        }
        public string Objetivo
        {
            get { return _objetivo; }
            set { _objetivo = value; }
        }
        public string Pantalla
        {
            get { return _pantalla; }
            set { _pantalla = value; }
        }
        public string Zoom
        {
            get { return _zoom; }
            set { _zoom = value; }
        }

        public Camara()
        {
            CamaraID = "";
            Resolucion = "";
            Sensor = "";
            Tipo = "";
            Factor = "";
            Objetivo = "";
            Pantalla = "";
            Zoom = "";
        }

        public Camara(string camaraId, string resolucion, string sensor, string tipo, string factor, string objetivo, string pantalla, string zoom)
        {
            CamaraID = camaraId;
            Resolucion = resolucion;
            Sensor = sensor;
            Tipo = tipo;
            Factor = factor;
            Objetivo = objetivo;
            Pantalla = pantalla;
            Zoom = zoom;
        }

        public Camara(Camara camara)
        {
            CamaraID = camara.CamaraID;
            Resolucion = camara.Resolucion;
            Sensor = camara.Sensor;
            Tipo = camara.Tipo;
            Factor = camara.Factor;
            Objetivo = camara.Objetivo;
            Pantalla = camara.Pantalla;
            Zoom = camara.Zoom;
        }

        public override string ToString()
        {
            return $"{CamaraID}#{Resolucion}#{Sensor}#{Tipo}#{Factor}#{Objetivo}#{Pantalla}#{Zoom}";
        }
    }
}
