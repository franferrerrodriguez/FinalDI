///<author>Francisco José Ferrer Rodríguez<author>
using System;
using System.Collections.Generic;
using Capa_entidades;
using System.Net.Http;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;
using Utils;

namespace Capa_datos
{
    public class UsuarioADO : ADO
    {

        // Leo todos los usuarios de la BD
        public List<Usuario> LeerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/usuarios").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaUsuarios;
        }
        public Usuario LeerUsuario(long id)
        {
            Usuario usuario = new Usuario();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/usuarios/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    usuario = JsonConvert.DeserializeObject<Usuario>(aux);
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return usuario;
        }

        // Creo un nuevo usuario en la BD
        public Usuario InsertarUsuario(Usuario usuario)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/usuarios", 
                    new StringContent(new JavaScriptSerializer().Serialize(usuario), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/usuarios/" + usuario.UsuarioID,
                    new StringContent(new JavaScriptSerializer().Serialize(usuario), Encoding.UTF8, "application/json")).Result;

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

        public bool BorrarUsuario(long id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/usuarios/" + id).Result;

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

        public Usuario LeerUsuariosByEmail(string email)
        {
            foreach (Usuario u in LeerUsuarios())
                if (u.Email.Equals(email))
                    return u;
            return null;
        }

        public bool ExisteUsuario(Usuario usuario)
        {
            foreach (Usuario u in LeerUsuarios())
                if (u.Email.Equals(usuario.Email) || u.Dni.Equals(usuario.Dni))
                    return true;
            return false;
        }

        public Usuario ExisteUsuarioByNombrePassword(string nombre, string password)
        {
            foreach (Usuario u in LeerUsuarios())
                if (u.Nombre.ToUpper().Equals(nombre.ToUpper()) && u.Password.Equals(Utilities.CalculateMD5Hash(password)))
                    return u;
            return null;
        }

        public List<Usuario> FiltrarPorNombre(List<Usuario> usuarios, string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
                return usuarios;
            List<Usuario> listaFiltrada = new List<Usuario>();
            foreach (Usuario u in usuarios)
                if (u.Nombre.ToUpper().Contains(nombre.ToUpper()))
                    listaFiltrada.Add(u);
            return listaFiltrada;
        }

        public List<Usuario> FiltrarPorApellidos(List<Usuario> usuarios, string apellidos)
        {
            if (String.IsNullOrEmpty(apellidos))
                return usuarios;
            List<Usuario> listaFiltrada = new List<Usuario>();
            foreach (Usuario u in usuarios)
                if (u.Apellidos.ToUpper().Contains(apellidos.ToUpper()))
                    listaFiltrada.Add(u);
            return listaFiltrada;
        }

        public List<Usuario> FiltrarPorEmail(List<Usuario> usuarios, string email)
        {
            if (String.IsNullOrEmpty(email))
                return usuarios;
            List<Usuario> listaFiltrada = new List<Usuario>();
            foreach (Usuario u in usuarios)
                if (u.Email.ToUpper().Contains(email.ToUpper()))
                    listaFiltrada.Add(u);
            return listaFiltrada;
        }

        public List<Usuario> FiltrarPorDocumento(List<Usuario> usuarios, string documento)
        {
            if (String.IsNullOrEmpty(documento))
                return usuarios;
            List<Usuario> listaFiltrada = new List<Usuario>();
            foreach (Usuario u in usuarios)
                if (u.Dni.ToUpper().Contains(documento.ToUpper()))
                    listaFiltrada.Add(u);
            return listaFiltrada;
        }

    }
}