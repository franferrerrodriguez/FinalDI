///<author>Francisco José Ferrer Rodríguez<author>
using CapaPresentacion;
using CapaPresentacion.Informes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Capa_presentacion
{
    /// <summary>
    /// Clase Program encargada de la ejecución principal del programa
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    static class Program
    {
        /// <summary>
        /// Método estático Main encargado de arrancas la aplicación
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}