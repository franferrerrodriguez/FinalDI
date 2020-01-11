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
    public class ProvinciaADO : ADO
    {

        // Leo todos los provincia de la BD
        public List<Provincia> LeerProvincias()
        {
            List<Provincia> listaProvincias = new List<Provincia>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/provincias").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaProvincias = JsonConvert.DeserializeObject<List<Provincia>>(aux);

                    LocalidadADO localidadAdo = new LocalidadADO();
                    List<Localidad> localidades = localidadAdo.LeerLocalidades();
                    
                    // Cargamos las localidades por cada provincia para tenerlas a mano
                    foreach(Provincia provincia in listaProvincias)
                        foreach (Localidad localidad in localidades)
                            if (localidad.ProvinciaID.Equals(provincia.ProvinciaID))
                                provincia.ListLocalidades.Add(localidad);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaProvincias;
        }
        public Provincia LeerProvincia(string id)
        {
            Provincia provincia = new Provincia();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/provincias/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    provincia = JsonConvert.DeserializeObject<Provincia>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return provincia;
        }
        // Creo un nuevo provincia en la BD
        public Provincia InsertarProvincia(Provincia provincia)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/provincias",
                    new StringContent(new JavaScriptSerializer().Serialize(provincia), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Provincia>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarProvincia(Provincia provincia)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/provincias/" + provincia.ProvinciaID,
                    new StringContent(new JavaScriptSerializer().Serialize(provincia), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarProvincia(string id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/provincias/" + id).Result;

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