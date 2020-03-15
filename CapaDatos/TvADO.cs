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
    public class TvADO : ADO
    {

        // Leo todos los tvs de la BD
        public List<Tv> LeerTvs()
        {
            List<Tv> listaTvs = new List<Tv>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/tv").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaTvs = JsonConvert.DeserializeObject<List<Tv>>(aux);
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

            return listaTvs;
        }
        public Tv LeerTv(string id)
        {
            Tv tv = new Tv();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/tv/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    tv = JsonConvert.DeserializeObject<Tv>(aux);
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

            return tv;
        }
        // Creo un nuevo tv en la BD
        public Tv InsertarTv(Tv tv)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/tv",
                    new StringContent(new JavaScriptSerializer().Serialize(tv), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Tv>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarTv(Tv tv)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/tv/" + tv.TvID,
                    new StringContent(new JavaScriptSerializer().Serialize(tv), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarTv(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/tv/" + id).Result;

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