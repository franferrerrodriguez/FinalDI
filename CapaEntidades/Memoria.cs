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
    public class Memoria
    {
        private string _memoriaId;
        private string _tipo;

        public string MemoriaID
        {
            get { return _memoriaId; }
            set
            {
                _memoriaId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public Memoria()
        {
            MemoriaID = "";
            Tipo = "";
        }

        public Memoria(string memoriaId, string tipo)
        {
            MemoriaID = memoriaId;
            Tipo = tipo;
        }

        public Memoria(Memoria memoria)
        {
            MemoriaID = memoria.MemoriaID;
            Tipo = memoria.Tipo;
        }

        public override string ToString()
        {
            return $"{MemoriaID}#{Tipo}";
        }
    }
}
