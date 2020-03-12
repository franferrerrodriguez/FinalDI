///<author>Francisco José Ferrer Rodríguez<author>
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;
using Capa_entidades;

namespace Capa_datos
{
    public class LocalidadADO : ADO
    {

        // Leo todos los localidades de la BD
        public List<Localidad> LeerLocalidades()
        {
            List<Localidad> listaLocalidades = new List<Localidad>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/localidades").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaLocalidades = JsonConvert.DeserializeObject<List<Localidad>>(aux);
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

            return listaLocalidades;
        }
        public Localidad LeerLocalidad(string id)
        {
            Localidad localidad = new Localidad();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/localidades/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    localidad = JsonConvert.DeserializeObject<Localidad>(aux);
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

            return localidad;
        }
        // Creo un nuevo localidad en la BD
        public Localidad InsertarLocalidad(Localidad localidad)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/localidades",
                    new StringContent(new JavaScriptSerializer().Serialize(localidad), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Localidad>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarLocalidad(Localidad localidad)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/localidades/" + localidad.LocalidadID,
                    new StringContent(new JavaScriptSerializer().Serialize(localidad), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarLocalidad(string id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/localidades/" + id).Result;

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