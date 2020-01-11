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
    public class CamaraADO : ADO
    {

        // Leo todos los camaras de la BD
        public List<Camara> LeerCamaras()
        {
            List<Camara> listaCamaras = new List<Camara>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/camaras").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaCamaras = JsonConvert.DeserializeObject<List<Camara>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaCamaras;
        }
        public Camara LeerCamara(string id)
        {
            Camara camara = new Camara();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/camaras/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    camara = JsonConvert.DeserializeObject<Camara>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return camara;
        }
        // Creo un nuevo camara en la BD
        public Camara InsertarCamara(Camara camara)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/camaras",
                    new StringContent(new JavaScriptSerializer().Serialize(camara), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Camara>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarCamara(Camara camara)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/camaras/" + camara.CamaraID,
                    new StringContent(new JavaScriptSerializer().Serialize(camara), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarCamara(string id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/camaras/" + id).Result;

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