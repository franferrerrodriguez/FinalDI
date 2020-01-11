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
    /// Clase encargada de la lógica de negocio de login
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public class LoginNegocio
    {
        private UsuarioADO usuarioAdo;
        private static bool _exit;
        private static int _intentos;

        public int Intentos
        {
            get { return _intentos; }
        }

        /// <summary>
        /// Constructor de clase LoginNegocio
        /// </summary>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public LoginNegocio()
        {
            usuarioAdo = new UsuarioADO();
            _exit = false;
            _intentos = 0;
        }

        /// <summary>
        /// Método encargado de comprobar el login del usuario
        /// </summary>
        ///  <param name="password">(String) password</param>
        ///  <param name="nombre">(String) nombre</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Usuario ComprobarLogin(String nombre, String password)
        {
            try
            {
                return usuarioAdo.ExisteUsuarioByNombrePassword(nombre, password);
            } catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método estático para salir de la aplicación
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public static bool ExitApp()
        {
            if (_exit)
                return true;
            else if(Utilities.ConfirmDialog("Salir de la aplicación", "¿Estás seguro que deseas salir de la aplicación?"))
            {
                _exit = true;
                return true;
            }
            return false;
        }
    }
}