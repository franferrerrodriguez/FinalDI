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
    /// <summary>
    /// Clase encargada de las operaciones CRUD de Usuarios
    /// </summary>
    /// <remarks>
    /// <para>Esta clase puede ver, añadir, modificar y eliminar usuarios del sistema.</para>
    /// <para>Además incluye otras funcionalidades de búsqueda o filtrado.</para>
    /// </remarks>
    public class UsuarioADO : ADO
    {

        /// <summary>
        /// Lee todos los usuarios de la BD
        /// </summary>
        /// <returns></returns>
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
                else
                {
                    throw new ExternalException(JsonConvert.SerializeObject(response));
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaUsuarios;
        }

        /// <summary>
        /// Lee un usuario a partir del campo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                else
                {
                    throw new ExternalException(JsonConvert.SerializeObject(response));
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return usuario;
        }

        /// <summary>
        /// Crear un nuevo usuario en la BD
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Actualizar un usuario en la BD
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Borra un usuario a partir de su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Lee un usuario a partir del campo Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// instanceUsuario.LeerUsuariosByEmail("fran@fran.com")
        /// </code>
        /// </example>
        public Usuario LeerUsuariosByEmail(string email)
        {
            foreach (Usuario u in LeerUsuarios())
                if (u.Email.Equals(email))
                    return u;
            return null;
        }

        /// <summary>
        /// Para comprobar si un usuario existe en la BD
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// instanceUsuario.ExisteUsuario(usuario)
        /// </code>
        /// </example>
        public bool ExisteUsuario(Usuario usuario)
        {
            foreach (Usuario u in LeerUsuarios())
                if (u.Email.Equals(usuario.Email) || u.Dni.Equals(usuario.Dni))
                    return true;
            return false;
        }

        /// <summary>
        /// Para comprobar si las credenciales introducidas coinciden con algún usuario de la BD
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// Usuario u = instanceUsuario.ExisteUsuarioByNombrePassword("fran", "ferrer")
        /// </code>
        /// </example>
        public Usuario ExisteUsuarioByNombrePassword(string nombre, string password)
        {
            foreach (Usuario u in LeerUsuarios())
                if (u.Nombre.ToUpper().Equals(nombre.ToUpper()) && u.Password.Equals(Utilities.CalculateMD5Hash(password)))
                    return u;
            return null;
        }


        /// <summary>
        /// Filtra una lista de usuarios a partir del campo Nombre
        /// </summary>
        /// <param name="usuarios"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// instanceUsuario.FiltrarPorNombre(list, "fran")
        /// </code>
        /// </example>
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

        /// <summary>
        /// Filtra una lista de usuarios a partir del campo Apellidos
        /// </summary>
        /// <param name="usuarios"></param>
        /// <param name="apellidos"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// instanceUsuario.FiltrarPorNombre(list, "ferrer")
        /// </code>
        /// </example>
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

        /// <summary>
        /// Filtra una lista de usuarios a partir del campo Email
        /// </summary>
        /// <param name="usuarios"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// instanceUsuario.FiltrarPorNombre(list, "fran@fran.com")
        /// </code>
        /// </example>
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

        /// <summary>
        /// Filtra una lista de usuarios a partir del campo Documento
        /// </summary>
        /// <param name="usuarios"></param>
        /// <param name="documento"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// instanceUsuario.FiltrarPorNombre(list, "48640904K")
        /// </code>
        /// </example>
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