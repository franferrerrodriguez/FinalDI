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
    public class MemoriaADO : ADO
    {

        // Leo todos los memorias de la BD
        public List<Memoria> LeerMemorias()
        {
            List<Memoria> listaMemorias = new List<Memoria>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/memorias").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaMemorias = JsonConvert.DeserializeObject<List<Memoria>>(aux);
                }
                else
                {
                    throw new ExternalException(JsonConvert.SerializeObject(response));
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaMemorias;
        }
        public Memoria LeerMemoria(string id)
        {
            Memoria memoria = new Memoria();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/memorias/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    memoria = JsonConvert.DeserializeObject<Memoria>(aux);
                }
                else
                {
                    throw new ExternalException(JsonConvert.SerializeObject(response));
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return memoria;
        }
        // Creo un nuevo memoria en la BD
        public Memoria InsertarMemoria(Memoria memoria)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/memorias",
                    new StringContent(new JavaScriptSerializer().Serialize(memoria), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Memoria>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarMemoria(Memoria memoria)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/memorias/" + memoria.MemoriaID,
                    new StringContent(new JavaScriptSerializer().Serialize(memoria), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarMemoria(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/memorias/" + id).Result;

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