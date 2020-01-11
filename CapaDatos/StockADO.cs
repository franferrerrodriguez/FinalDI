///<author>Francisco José Ferrer Rodríguez<author>
using System;
using System.Collections.Generic;
using Capa_entidades;
using System.Net.Http;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;

namespace Capa_datos
{
    public class StockADO : ADO
    {

        // Leo todos los stocks de la BD
        public List<Stock> LeerStocks()
        {
            List<Stock> listaStocks = new List<Stock>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/stock").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaStocks = JsonConvert.DeserializeObject<List<Stock>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaStocks;
        }
        public Stock LeerStock(int id)
        {
            Stock stock = new Stock();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/stock/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    stock = JsonConvert.DeserializeObject<Stock>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return stock;
        }
        // Creo un nuevo stock en la BD
        public Stock InsertarStock(Stock stock)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/stock",
                    new StringContent(new JavaScriptSerializer().Serialize(stock), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Stock>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarStock(Stock stock)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/stock/" + stock.ArticuloID,
                    new StringContent(new JavaScriptSerializer().Serialize(stock), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }

        public bool BorrarStock(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/stock/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }

    }
}