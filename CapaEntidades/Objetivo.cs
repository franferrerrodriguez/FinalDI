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
    public class Objetivo
    {
        private string _objetivoId;
        private string _tipo;
        private string _montura;
        private string _focal;
        private string _apertura;
        private string _especiales;

        public string ObjetivoID
        {
            get { return _objetivoId; }
            set
            {
                _objetivoId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public string Montura
        {
            get { return _montura; }
            set { _montura = value; }
        }
        public string Focal
        {
            get { return _focal; }
            set { _focal = value; }
        }
        public string Apertura
        {
            get { return _apertura; }
            set { _apertura = value; }
        }
        public string Especiales
        {
            get { return _especiales; }
            set { _especiales = value; }
        }

        public Objetivo()
        {
            ObjetivoID = "";
            Tipo = "";
            Montura = "";
            Focal = "";
            Apertura = "";
            Especiales = "";
        }

        public Objetivo(string objetivoId, string tipo, string montura, string focal, string apertura, string especiales)
        {
            ObjetivoID = objetivoId;
            Tipo = tipo;
            Montura = montura;
            Focal = focal;
            Apertura = apertura;
            Especiales = especiales;
        }

        public Objetivo(Objetivo objetivo)
        {
            ObjetivoID = objetivo.ObjetivoID;
            Tipo = objetivo.Tipo;
            Montura = objetivo.Montura;
            Focal = objetivo.Focal;
            Apertura = objetivo.Apertura;
            Especiales = objetivo.Especiales;
        }

        public override string ToString()
        {
            return $"{ObjetivoID}#{Tipo}#{Montura}#{Focal}#{Apertura}#{Especiales}";
        }
    }
}
