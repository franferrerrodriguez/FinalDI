///<author>Francisco José Ferrer Rodríguez<author>
using CapaNegocio;
using CapaPresentacion;
using CapaPresentacion.Acercade;
using CapaPresentacion.Estadisticas;
using CapaPresentacion.Informes;
using CapaPresentacion.Pedidos;
using CapaPresentacion.Productos;
using CapaPresentacion.Usuarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Utils;

namespace Capa_presentacion
{
    /// <summary>
    /// Clase encargada del formulario Main
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class MainForm : Form
    {
        LoginForm loginForm;
        DateTime tiempoInicioSesion = new DateTime();

        /// <summary>
        /// Constructor de clase MainForm
        /// </summary>
        /// <param name="loginForm">(LoginForm) loginForm</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public MainForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        /// <summary>
        /// Método load del formulario
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void MainForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            timerSegundo.Interval = 500;
            timerSegundo.Enabled = true;
            tiempoInicioSesion = DateTime.Now;
        }

        /// <summary>
        /// Método click del la pestaña 'Archivo/Salir' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoginNegocio.ExitApp())
                Application.Exit();
        }

        /// <summary>
        /// Método click del la pestaña 'Usuarios/Insertar' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new FichaUsuariosForm(Utilities.Modos.Insertar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Usuarios/Modificar' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new TableViewUsuariosForm(Utilities.Modos.Modificar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Usuarios/Eliminar' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new TableViewUsuariosForm(Utilities.Modos.Eliminar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Productos/Consultar' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new FichaProductosForm(Utilities.Modos.Consultar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Productos/Modificar' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new FichaProductosForm(Utilities.Modos.Modificar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Pedidos/Nuevo' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new FichaPedidosForm(Utilities.Modos.Insertar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Pedidos/Consulta modificación' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void consultaYModificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new TableViewPedidosForm(Utilities.Modos.Modificar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Pedidos/Eliminar' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new TableViewPedidosForm(Utilities.Modos.Eliminar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Estadisticas/Pedidos del mes' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void pedidosDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new FichaEstadisticasPedidosDiaMes(Utilities.Modos.Consultar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Estadisticas/Artículos vendidos' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void artículosVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new FichaEstadisticasArticulosVendidos(Utilities.Modos.Consultar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Informes/Factura' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new TableViewPedidosForm(Utilities.Modos.Consultar, new FacturaForm()));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Informes/Stock reducido' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new FichaStockReducidoForm(Utilities.Modos.Consultar));
            form.Show();
        }

        /// <summary>
        /// Método click del la pestaña 'Acerca de.../Acerca de...' del menú
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = childrenMdi(new AcercaDeForm(Utilities.Modos.Consultar));
            form.Show();
        }

        /// <summary>
        /// Método que carga un formulario en el contenedor MDI
        /// </summary>
        /// <param name="form">(Form) form</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public Form childrenMdi(Form form)
        {
            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            return form;
        }

        /// <summary>
        /// Método click para verificación de cierre del formulario principal
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(FormClosingEventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !LoginNegocio.ExitApp();
            if (!e.Cancel)
                Application.Exit();
        }

        /// <summary>
        /// Método para actualizar la fecha actual y el tiempo de sesión
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void TimerSegundo_Tick(object sender, EventArgs e)
        {
            labelHoraSistemaMain.Text = String.Format("Fecha: {0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            TimeSpan restante = DateTime.Now - tiempoInicioSesion;
            labelTiempoLoginMain.Text = String.Format("Tiempo de sesión:{0:\\ hh\\:mm\\:ss}", restante);
        }

        /// <summary>
        /// Método click para salir de la aplicación
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Utilities.ConfirmDialog("Cerrar sesión", "¿Está seguro que desea cerrar sesión?"))
            {
                Hide();
                LoginForm.isLogado = false;
                loginForm.Reset();
                loginForm.Show();
            }
        }

        /// <summary>
        /// Método estático para mostrar error durante la ejecución del programa
        /// </summary>
        /// <param name="e">(Exception) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public static void MostrarExcepcion(Exception e)
        {
            MainForm f1 = (MainForm)Application.OpenForms["MainForm"];
            Label label = f1.labelMensajeErrorMain;
            label.ForeColor = Color.Red;
            label.Text = "Estado: Error: " + e.Message;

        }
        
    }
}