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
    public class Stock
    {
        private string _articuloId;
        private int? _disponible;
        public const string
                _DESCATALOGADO = "Descatalogado",
                _PROXIMAMENTE = "Próximamente",
                _24HORAS = "24 horas",
                _34SEMANAS = "3/4 días",
                _12SEMANAS = "1/2 semanas";
        private string _entrega;

        public string ArticuloID
        {
            get { return _articuloId; }
            set
            {
                _articuloId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public int? Disponible
        {
            get { return _disponible; }
            set { _disponible = value; }
        }
        public string Entrega
        {
            get { return _entrega; }
            set { _entrega = value; }
        }

        public Stock()
        {
            ArticuloID = "";
            Disponible = 0;
            Entrega = "";
        }

        public Stock(string articuloId, int disponible, string entrega)
        {
            ArticuloID = articuloId;
            Disponible = disponible;
            Entrega = entrega;
        }

        public Stock(Stock stock)
        {
            ArticuloID = stock.ArticuloID;
            Disponible = stock.Disponible;
            Entrega = stock.Entrega;
        }

        public override string ToString()
        {
            return $"{ArticuloID}#{Disponible}#{Entrega}";
        }
    }
}
