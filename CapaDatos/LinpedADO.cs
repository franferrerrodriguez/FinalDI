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
    public class LinpedADO : ADO
    {

        // Leo todos los linpeds de la BD
        public List<Linped> LeerLinpeds()
        {
            List<Linped> listaLinpeds = new List<Linped>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/linpeds").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaLinpeds = JsonConvert.DeserializeObject<List<Linped>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaLinpeds;
        }
        public List<Linped> LeerLinped(long id)
        {
            List<Linped> linped = new List<Linped>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/linpeds/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    linped = JsonConvert.DeserializeObject<List<Linped>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return linped;
        }
        // Creo un nuevo linped en la BD
        public Linped InsertarLinped(Linped linped)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/linpeds",
                    new StringContent(new JavaScriptSerializer().Serialize(linped), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Linped>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarLinped(Linped linped)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/linpeds/" + linped.Linea,
                    new StringContent(new JavaScriptSerializer().Serialize(linped), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarLinped(long id, int idLinea)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/linpeds/" + id + "/" + idLinea).Result;

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

        public bool BorrarLinpedsByPedido(long id)
        {
            foreach (Linped l in LeerLinped(id))
                if(l.PedidoID.Equals(id) && !BorrarLinped(l.PedidoID, l.Linea))
                    return false;
            return true;
        }

    }
}