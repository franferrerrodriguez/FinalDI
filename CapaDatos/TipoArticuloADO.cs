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
    public class TipoArticuloADO : ADO
    {

        // Leo todos los tipos de artículo de la BD
        public List<TipoArticulo> LeerTipoArticulos()
        {
            List<TipoArticulo> listaTipoArticulos = new List<TipoArticulo>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/tipoArticulos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaTipoArticulos = JsonConvert.DeserializeObject<List<TipoArticulo>>(aux);
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

            return listaTipoArticulos;
        }
        public TipoArticulo LeerTipoArticulo(int id)
        {
            TipoArticulo tipoArticulo = new TipoArticulo();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/tipoArticulos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    tipoArticulo = JsonConvert.DeserializeObject<TipoArticulo>(aux);
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

            return tipoArticulo;
        }
        // Creo un nuevo tipo de artículo en la BD
        public TipoArticulo InsertarTipoArticulo(TipoArticulo tipoArticulo)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/tipoArticulos",
                    new StringContent(new JavaScriptSerializer().Serialize(tipoArticulo), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<TipoArticulo>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarTipoArticulo(TipoArticulo tipoArticulo)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/tipoArticulos/" + tipoArticulo.TipoArticuloID,
                    new StringContent(new JavaScriptSerializer().Serialize(tipoArticulo), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarTipoArticulo(int id)
        {
            try
            {

                HttpResponseMessage response = client.DeleteAsync("api/tipoArticulos/" + id).Result;

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