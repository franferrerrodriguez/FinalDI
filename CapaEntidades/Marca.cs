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
    public class Marca
    {
        private string _marcaId;
        private string _empresa;
        private byte[] _logo;

        public string MarcaID
        {
            get { return _marcaId; }
            set
            {
                _marcaId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }
        public byte[] Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }

        public Marca()
        {
            MarcaID = "";
            Empresa = "";
            Logo = new byte[0];
        }

        public Marca(string empresa, byte[] logo)
        {
            Empresa = empresa;
            Logo = logo;
        }

        public Marca(Marca marca)
        {
            Empresa = marca.Empresa;
            Logo = marca.Logo;
        }

        public override string ToString()
        {
            return $"{MarcaID}#{Empresa}#{Logo}";
        }
    }
}
