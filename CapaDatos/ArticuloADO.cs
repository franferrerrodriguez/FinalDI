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
    public class ArticuloADO : ADO
    {

        // Leo todos los articulos de la BD
        public List<Articulo> LeerArticulos()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/articulos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaArticulos = JsonConvert.DeserializeObject<List<Articulo>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaArticulos;
        }
        public Articulo LeerArticulo(string id)
        {
            Articulo articulo = new Articulo();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/articulos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    articulo = JsonConvert.DeserializeObject<Articulo>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return articulo;
        }
        // Creo un nuevo articulo en la BD
        public Articulo InsertarArticulo(Articulo articulo)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/articulos",
                    new StringContent(new JavaScriptSerializer().Serialize(articulo), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Articulo>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarArticulo(Articulo articulo)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/articulos/" + articulo.ArticuloID,
                    new StringContent(new JavaScriptSerializer().Serialize(articulo), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarArticulo(string id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/articulos/" + id).Result;

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

        public List<Articulo> FiltrarPorNombre(List<Articulo> articulos, string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
                return articulos;
            List<Articulo> listaFiltrada = new List<Articulo>();
            foreach (Articulo a in articulos)
                if (a.Nombre.ToUpper().Contains(nombre.ToUpper()))
                    listaFiltrada.Add(a);
            return listaFiltrada;
        }

        public List<Articulo> FiltrarPorTipo(List<Articulo> articulos, long tipoArticulo)
        {
            if (tipoArticulo.Equals(0))
                return articulos;
            List<Articulo> listaFiltrada = new List<Articulo>();
            foreach (Articulo a in articulos)
                if (a.TipoArticuloID.Equals(tipoArticulo))
                    listaFiltrada.Add(a);
            return listaFiltrada;
        }

    }
}