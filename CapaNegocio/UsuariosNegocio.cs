using Capa_datos;
using Capa_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CapaNegocio
{
    /// <summary>
    /// Clase encargada de la lógica de negocio de usuarios
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public class UsuariosNegocio
    {
        private UsuarioADO usuarioAdo;
        private ProvinciaADO provinciaAdo;
        private LocalidadADO localidadAdo;
        private PedidoADO pedidoAdo;

        /// <summary>
        /// Constructor de clase UsuariosNegocio
        /// </summary>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public UsuariosNegocio()
        {
            usuarioAdo = new UsuarioADO();
            provinciaAdo = new ProvinciaADO();
            localidadAdo = new LocalidadADO();
            pedidoAdo = new PedidoADO();
        }

        /// <summary>
        /// Método encargado de leer usuario
        /// </summary>
        /// <param name="id">(long) id</param>
        /// <returns>Usuario</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Usuario LeerUsuario(long id)
        {
            try
            {
                return usuarioAdo.LeerUsuario(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer usuarios
        /// </summary>
        /// <returns>List<Usuario></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Usuario> LeerUsuarios()
        {
            try
            {
                return usuarioAdo.LeerUsuarios();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer usuarios filtrando por nombre, apellidos, email y documento
        /// </summary>
        ///  <param name="listUsuarios">(List<Usuario>) listUsuarios</param>
        ///  <param name="nombre">(string) nombre</param>
        ///  <param name="apellidos">(string) apellidos</param>
        ///  <param name="email">(string) email</param>
        ///  <param name="documento">(string) documento</param>
        /// <returns>List<Usuario></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Usuario> LeerUsuariosPorFiltro(List<Usuario> listUsuarios, string nombre, string apellidos, string email, string documento)
        {
            try
            {
                listUsuarios = FiltrarPorNombre(listUsuarios, nombre);
                listUsuarios = FiltrarPorApellidos(listUsuarios, apellidos);
                listUsuarios = FiltrarPorEmail(listUsuarios, email);
                listUsuarios = FiltrarPorDocumento(listUsuarios, documento);
                return listUsuarios;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de insertar usuario
        ///  <param name="usuario">(Usuario) usuario</param>
        /// </summary>
        /// <returns>string</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public string InsertarUsuario(Usuario usuario)
        {
            try
            {
                if (ExisteUsuario(usuario))
                    return Constants.ERROR_INSERCION_DUPLICADO;
                else if (usuarioAdo.InsertarUsuario(usuario) == null)
                    return Constants.ERROR_INSERCION_DESCONOCIDO;
                else
                    return Constants.OK_INSERCION;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de actualizar usuario
        ///  <param name="usuario">(Usuario) usuario</param>
        /// </summary>
        /// <returns>string</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public string ActualizarUsuario(Usuario usuario)
        {
            try
            {
                if (ExisteUsuario(usuario))
                    if (usuarioAdo.ActualizarUsuario(usuario))
                        return Constants.OK_MODIFICACION;
                    else
                        return Constants.ERROR_INSERCION_DESCONOCIDO;
                else
                    return Constants.ERROR_INSERCION_DESCONOCIDO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de eliminar usuario
        ///  <param name="usuario">(Usuario) usuario</param>
        /// </summary>
        /// <returns>string</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public string EliminarUsuario(Usuario usuario)
        {
            try
            {
                List<Pedido> listaPedidos = pedidoAdo.LeerPedidosByUsuarioEmail(usuario.Email);
                if (listaPedidos.Count == 0)
                    if (usuarioAdo.BorrarUsuario(usuario.UsuarioID))
                        return Constants.OK_BORRADO;
                    else
                        return Constants.ERROR_BORRADO_DESCONOCIDO;
                else
                    return Constants.ERROR_BORRADO_USUARIO_PEDIDOS;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de comprobar si un usuario existe
        /// <param name="usuario">(Usuario) usuario</param>
        /// </summary>
        /// <returns>bool</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public bool ExisteUsuario(Usuario usuario)
        {
            foreach (Usuario u in LeerUsuarios())
                if (u.Email.Equals(usuario.Email) || u.Dni.Equals(usuario.Dni))
                    return true;
            return false;
        }

        /// <summary>
        /// Método encargado de comprobar un usuario por nombre y contraseña
        /// <param name="nombre">(string) nombre</param>
        /// <param name="password">(string) password</param>
        /// </summary>
        /// <returns>Usuario</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Usuario ExisteUsuarioByNombrePassword(string nombre, string password)
        {
            foreach (Usuario u in LeerUsuarios())
                if (u.Nombre.ToUpper().Equals(nombre.ToUpper()) && u.Password.Equals(Utilities.CalculateMD5Hash(password)))
                    return u;
            return null;
        }

        /// <summary>
        /// Método encargado de filtrar usuarios por nombre
        /// </summary>
        ///  <param name="listUsuarios">(List<Usuario>) listUsuarios</param>
        ///  <param name="nombre">(string) nombre</param>
        /// <returns>List<Usuario></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
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
        /// Método encargado de filtrar usuarios por apellidos
        /// </summary>
        ///  <param name="listUsuarios">(List<Usuario>) listUsuarios</param>
        ///  <param name="apellidos">(string) apellidos</param>
        /// <returns>List<Usuario></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
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
        /// Método encargado de filtrar usuarios por email
        /// </summary>
        ///  <param name="listUsuarios">(List<Usuario>) listUsuarios</param>
        ///  <param name="email">(string) email</param>
        /// <returns>List<Usuario></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
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
        /// Método encargado de filtrar usuarios por documento
        /// </summary>
        ///  <param name="listUsuarios">(List<Usuario>) listUsuarios</param>
        ///  <param name="documento">(string) documento</param>
        /// <returns>List<Usuario></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
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

        /// <summary>
        /// Método encargado de leer provincias
        /// </summary>
        /// <returns>List<Provincia></returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public List<Provincia> LeerProvincias()
        {
            try
            {
                return provinciaAdo.LeerProvincias();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer provincia
        /// </summary>
        ///  <param name="provinciaId">(string) provinciaId</param>
        /// <returns>Provincia</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Provincia LeerProvincia(string provinciaId)
        {
            try
            {
                return provinciaAdo.LeerProvincia(provinciaId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método encargado de leer localidad
        /// </summary>
        ///  <param name="localidadId">(string) localidadId</param>
        /// <returns>Localidad</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Localidad LeerLocalidad(string localidadId)
        {
            try
            {
                return localidadAdo.LeerLocalidad(localidadId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}