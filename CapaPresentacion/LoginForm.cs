using Capa_entidades;
using Capa_presentacion;
using CapaNegocio;
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

namespace CapaPresentacion
{
    /// <summary>
    /// Clase encargada del formulario LoginForm
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class LoginForm : Form
    {
        LoginNegocio loginNegocio;
        public static bool isLogado;
        private MainForm mainform;
        private int numIntentos;
        private static int maxIntentos = 3;
        private static Usuario usuarioLogado;

        /// <summary>
        /// Constructor de clase LoginForm
        /// </summary>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public LoginForm()
        {
            InitializeComponent();
            loginNegocio = new LoginNegocio();
            numIntentos = 0;
        }

        /// <summary>
        /// Método load del formulario
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            isLogado = false;
            MaximizeBox = false;
            mainform = new MainForm(this);
        }

        /// <summary>
        /// Método click del botón acceder para loguearse en la aplicación
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void Button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        /// <summary>
        /// Método keyDown que detecta cuando se pulsa enter desde el textBox password
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxPasswordLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }

        /// <summary>
        /// Método que comprueba si un usuario puede entrar o no a la aplicación
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void Login()
        {
            Usuario usuario = loginNegocio.ComprobarLogin(textBoxLoginLogin.Text, textBoxPasswordLogin.Text);
            if (usuario != null)
            {
                numIntentos = 0;
                isLogado = true;
                Hide();
                mainform.labelNombreLoginMain.Text = textBoxLoginLogin.Text;
                usuarioLogado = usuario;
                mainform.Show();
            }
            else
            {
                numIntentos++;
                if (numIntentos.Equals(maxIntentos))
                {
                    Application.Exit();
                }
                MessageBox.Show("Error en la combinación de login / password. Por favor, inténtelo de nuevo.");
                Reset();
            }
        }

        /// <summary>
        /// Método que devuelve el usuario logado
        /// </summary>
        /// <returns>Usuario</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public static Usuario GetUsuarioLogado()
        {
            return usuarioLogado;
        }

        /// <summary>
        /// Método click llama al método Reset()
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void Button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        /// <summary>
        /// Método que resetea los campos del formulario de login
        /// </summary>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void Reset()
        {
            textBoxLoginLogin.Text = "";
            textBoxPasswordLogin.Text = "";
        }

        /// <summary>
        /// Método que comprueba el cierre total de la aplicación
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(FormClosingEventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (numIntentos.Equals(maxIntentos))
                e.Cancel = false;
            else
                e.Cancel = !LoginNegocio.ExitApp();
            
            if(!e.Cancel)
                Application.Exit();
        }

        /// <summary>
        /// Método que muestra la aplicación desde el icono de barra de tareas
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void BarraTareasMostrar_Click(object sender, EventArgs e)
        {
            if (isLogado)
                mainform.Show();
            else
                Show();
        }

        /// <summary>
        /// Método que oculta la aplicación desde el icono de barra de tareas
        /// </summary>
        ///  <param name="sender">(object) sender</param>
        ///  <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void BarraTareasOcultar_Click(object sender, EventArgs e)
        {
            Form[] forms = { this, mainform };
            foreach (Form f in forms)
                f.Hide();
        }

    }
}