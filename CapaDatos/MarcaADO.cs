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
    public class MarcaADO : ADO
    {

        // Leo todos los marcas de la BD
        public List<Marca> LeerMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/marcas").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaMarcas = JsonConvert.DeserializeObject<List<Marca>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaMarcas;
        }
        public Marca LeerMarca(int id)
        {
            Marca marca = new Marca();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/marcas/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    marca = JsonConvert.DeserializeObject<Marca>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return marca;
        }
        // Creo un nuevo marca en la BD
        public Marca InsertarMarca(Marca marca)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/marcas",
                    new StringContent(new JavaScriptSerializer().Serialize(marca), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Marca>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarMarca(Marca marca)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/marcas/" + marca.MarcaID,
                    new StringContent(new JavaScriptSerializer().Serialize(marca), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarMarca(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/marcas/" + id).Result;

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