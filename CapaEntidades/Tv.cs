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
    public class Tv
    {
        private string _tvId;
        private string _panel;
        private sbyte? _pantalla;
        private string _resolucion;
        private string _hdReadyFullHd;
        private bool _tdt;

        public string TvID
        {
            get { return _tvId; }
            set
            {
                _tvId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Panel
        {
            get { return _panel; }
            set { _panel = value; }
        }
        public sbyte? Pantalla
        {
            get { return _pantalla; }
            set { _pantalla = value; }
        }
        public string Resolucion
        {
            get { return _resolucion; }
            set { _resolucion = value; }
        }
        public string Hdreadyfullhd
        {
            get { return _hdReadyFullHd; }
            set { _hdReadyFullHd = value; }
        }
        public bool Tdt
        {
            get { return _tdt; }
            set { _tdt = value; }
        }

        public Tv()
        {
            TvID = "";
            Panel = "";
            Pantalla = 0;
            Resolucion = "";
            Hdreadyfullhd = "";
            Tdt = false;
        }

        public Tv(string tvId, string panel, sbyte pantalla, string resolucion, string hdReadyFullHd, bool tdt)
        {
            TvID = tvId;
            Panel = panel;
            Pantalla = pantalla;
            Resolucion = resolucion;
            Hdreadyfullhd = hdReadyFullHd;
            Tdt = tdt;
        }

        public Tv(Tv tv)
        {
            TvID = tv.TvID;
            Panel = tv.Panel;
            Pantalla = tv.Pantalla;
            Resolucion = tv.Resolucion;
            Hdreadyfullhd = tv.Hdreadyfullhd;
            Tdt = tv.Tdt;
        }

        public override string ToString()
        {
            return $"{TvID}#{Panel}#{Pantalla}#{Resolucion}#{Hdreadyfullhd}#{Tdt}";
        }
    }
}
