///<author>Francisco José Ferrer Rodríguez<author>
using System;
using Utils;

namespace Capa_entidades
{
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

        public long UsuarioID
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Apellidos
        {
            get { return _apellidos; }
            set
            {
                _apellidos = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Dni
        {
            get { return _dni; }
            set
            {
                _dni = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }
        public string Calle2
        {
            get { return _calle2; }
            set { _calle2 = value; }
        }
        public string Codpos
        {
            get { return _codpos; }
            set { _codpos = value; }
        }
        public string PuebloID
        {
            get { return _puebloId; }
            set
            {
                _puebloId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }
        public string ProvinciaID
        {
            get { return _provinciaId; }
            set
            {
                _provinciaId = value ?? throw new Exception(Constants.ERROR_NOTNULL_STRING);
            }
        }

        public DateTime? Nacido
        {
            get { return _nacido; }
            set { _nacido = value; }
        }

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

        public override string ToString()
        {
            return $"{_usuarioId}#{_email}#{_password}#{_nombre}#{_apellidos}#{_dni}#{_telefono}#" +
                $"{_calle}#{_calle2}#{_codpos}#{_puebloId}#{_provinciaId}#{_nacido}";
        }

    }
}