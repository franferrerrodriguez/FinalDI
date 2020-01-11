using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class Constants
    {
        public const string
            ERROR_NOTNULL_STRING = "Campo de tipo 'String' obligatorio.",
            ERROR_NOTNULL_DATE = "Campo de tipo 'DateTime' obligatorio.",
            ERROR_VALIDATE_NOMBRE = "Error al validar el campo 'Nombre'.",
            ERROR_VALIDATE_APELLIDOS = "Error al validar el campo 'Apellidos'.",
            ERROR_VALIDATE_EMAIL = "Error al validar el campo 'Email'.",
            ERROR_VALIDATE_PASSWORD = "Error al validar el campo 'Password'.",
            ERROR_VALIDATE_NIFNIE = "Error al validar el campo 'NIF/NIE'.",
            ERROR_VALIDATE_TELEFONO = "Error al validar el campo 'Teléfono'.",
            ERROR_VALIDATE_CP = "Error al validar el campo 'Código Postal'.",
            ERROR_VALIDATE_NACDATE = "Error al validar el campo 'Fecha Nacimiento'.",
            ERROR_INSERCION_DESCONOCIDO = "La inserción ha fallado. Motivos desconocidos.",
            ERROR_BORRADO_DESCONOCIDO = "El borrado ha fallado. Motivos desconocidos.",
            ERROR_BORRADO_USUARIO_PEDIDOS = "El borrado ha fallado. El usuario tiene pedidos asignados.",
            ERROR_INSERCION_DUPLICADO = "La inserción ha fallado. El registro ya existe en el sistema.",
            OK_INSERCION = "El registro ha sido insertado correctamente.",
            OK_MODIFICACION = "El registro ha sido modificado correctamente.",
            OK_BORRADO = "El registro ha sido borrado correctamente.";
    }
}