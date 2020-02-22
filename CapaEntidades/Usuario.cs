///<author>Francisco José Ferrer Rodríguez<author>
using System;
using Utils;

namespace Capa_entidades
{
    /// <summary>
    /// Modelo de la clase Usuario
    /// </summary>
    /// <para>Esta clase es el modelo del tipo Usuario del sistema.</para>
    /// <para>Dispone de Getters and Setters de todos los atributos, así como 3 tipos de constructor.</para>
    public class Usuario
    {
        private long _usuarioId;
        private string _email;
        private string _password;
        private string _nombre;
        private string _apellidos;
        private string _dni;
        private string _telefono;
        private string _calle;
        private string _calle2;
        private string _codpos;
        private string _puebloId;
        private string _provinciaId;
        private DateTime? _nacido;

        /// <summary>
        /// Getter y Setter del atributo UsuarioID
        /// </summary>
        public long UsuarioID
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        /// <summary>
        /// Getter y Setter del atributo Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }

        /// <summary>
        /// Getter y Setter del atributo Password
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// Getter y Setter del atributo Nombre
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }

        /// <summary>
        /// Getter y Setter del atributo Apellidos
        /// </summary>
        public string Apellidos
        {
            get { return _apellidos; }
            set
            {
                _apellidos = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }

        /// <summary>
        /// Getter y Setter del atributo Dni
        /// </summary>
        public string Dni
        {
            get { return _dni; }
            set
            {
                _dni = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }

        /// <summary>
        /// Getter y Setter del atributo Telefono
        /// </summary>
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        /// <summary>
        /// Getter y Setter del atributo Calle
        /// </summary>
        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        /// <summary>
        /// Getter y Setter del atributo Calle2
        /// </summary>
        public string Calle2
        {
            get { return _calle2; }
            set { _calle2 = value; }
        }

        /// <summary>
        /// Getter y Setter del atributo Codpos
        /// </summary>
        public string Codpos
        {
            get { return _codpos; }
            set { _codpos = value; }
        }

        /// <summary>
        /// Getter y Setter del atributo PuebloID
        /// </summary>
        public string PuebloID
        {
            get { return _puebloId; }
            set
            {
                _puebloId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }

        /// <summary>
        /// Getter y Setter del atributo ProvinciaID
        /// </summary>
        public string ProvinciaID
        {
            get { return _provinciaId; }
            set
            {
                _provinciaId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }

        /// <summary>
        /// Getter y Setter del atributo Nacido
        /// </summary>
        public DateTime? Nacido
        {
            get { return _nacido; }
            set { _nacido = value; }
        }

        /// <summary>
        /// Constructor vacío de la clase Usuario
        /// </summary>
        public Usuario()
        {
            Email = "";
            Password = "";
            Nombre = "";
            Apellidos = "";
            Dni = "";
            Telefono = "";
            Calle = "";
            Calle2 = "";
            Codpos = "";
            PuebloID = "";
            ProvinciaID = "";
            Nacido = new DateTime();
        }

        /// <summary>
        /// Constructor con parámetros de la clase Usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="dni"></param>
        /// <param name="telefono"></param>
        /// <param name="calle"></param>
        /// <param name="calle2"></param>
        /// <param name="codpos"></param>
        /// <param name="puebloId"></param>
        /// <param name="provinciaId"></param>
        /// <param name="nacido"></param>
        public Usuario(string email, string password, string nombre, string apellidos,
            string dni, string telefono, string calle, string calle2, string codpos, string puebloId,
            string provinciaId, DateTime nacido)
        {
            Email = email;
            Password = password;
            Nombre = nombre;
            Apellidos = apellidos;
            Dni = dni;
            Telefono = telefono;
            Calle = calle;
            Calle2 = calle2;
            Codpos = codpos;
            PuebloID = puebloId;
            ProvinciaID = provinciaId;
            Nacido = nacido;
        }

        /// <summary>
        /// Constructor copia de la clase Usuario
        /// </summary>
        /// <param name="usuario"></param>
        public Usuario(Usuario usuario)
        {
            Email = usuario.Email;
            Password = usuario.Password;
            Nombre = usuario.Nombre;
            Apellidos = usuario.Apellidos;
            Dni = usuario.Dni;
            Telefono = usuario.Telefono;
            Calle = usuario.Calle;
            Calle2 = usuario.Calle2;
            Codpos = usuario.Codpos;
            PuebloID = usuario.PuebloID;
            ProvinciaID = usuario.ProvinciaID;
            Nacido = usuario.Nacido;
        }

        /// <summary>
        /// Sobrescrimiento del método ToString que devuelve la información del usuario
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{_usuarioId}#{_email}#{_password}#{_nombre}#{_apellidos}#{_dni}#{_telefono}#" +
                $"{_calle}#{_calle2}#{_codpos}#{_puebloId}#{_provinciaId}#{_nacido}";
        }

    }
}