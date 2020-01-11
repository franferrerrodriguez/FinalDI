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
    public class ObjetivoADO : ADO
    {

        // Leo todos los objetivos de la BD
        public List<Objetivo> LeerObjetivos()
        {
            List<Objetivo> listaObjetivos = new List<Objetivo>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/objetivos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaObjetivos = JsonConvert.DeserializeObject<List<Objetivo>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaObjetivos;
        }
        public Objetivo LeerObjetivo(string id)
        {
            Objetivo objetivo = new Objetivo();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/objetivos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    objetivo = JsonConvert.DeserializeObject<Objetivo>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return objetivo;
        }
        // Creo un nuevo objetivo en la BD
        public Objetivo InsertarObjetivo(Objetivo objetivo)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/objetivos",
                    new StringContent(new JavaScriptSerializer().Serialize(objetivo), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Objetivo>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarObjetivo(Objetivo objetivo)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/objetivos/" + objetivo.ObjetivoID,
                    new StringContent(new JavaScriptSerializer().Serialize(objetivo), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarObjetivo(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/objetivos/" + id).Result;

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