using Capa_presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace CapaPresentacion.Acercade
{
    /// <summary>
    /// Clase encargada del módulo Acerca de...
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class AcercaDeForm : Form
    {
        private Utilities.Modos modo;
        private Form formParent;

        /// <summary>
        /// Constructor de clase AcercaDeForm
        /// </summary>
        /// <param name="modo">(Utilities.Modos) modo</param>
        /// <param name="formParent">(Form) formParent</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public AcercaDeForm(Utilities.Modos modo, Form formParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            this.formParent = formParent;
        }

        private void AcercaDeForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "La aplicación TiendaDAM gestiOnara los datos relacionados cón una tienda online. " +
                "La aplicación se deberá desarrollar basándonos en un patrón multicapa con entidades y " +
                "programación orientada a objetos. La base de datos elegida para este proyectó es Mysql, " +
                "proporcionandose los scripts de creació n de dicha base de datos y de una API WEB para su " +
                "utilización desde la capa de datos del proyecto.";
            textBox2.Text = "La aplicación constara de un formulario principal donde tendremos acceso a todas " +
                "las opciónes que nos ofrecera el programa y antes de iniciar el programa se mostrara en " +
                "formularió de login, que nos permitirá el acceso a la aplicación si tenemos las credenciales " +
                "correctas. Una vez concedido el acceso tendremos acceso a la aplicación.";
        }
    }
}