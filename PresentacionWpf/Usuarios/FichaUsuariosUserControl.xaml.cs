using Capa_entidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utils;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class FichaUsuariosUserControl : UserControl
    {
        private Utilities.Modos modo;
        private Window windowParent;
        private Usuario usuario;
        private UsuariosNegocio usuariosNegocio;

        public FichaUsuariosUserControl(Utilities.Modos modo, Window windowParent = null, Usuario usuario = null)
        {
            InitializeComponent();
            this.modo = modo;
            this.windowParent = windowParent;
            this.usuario = usuario;
            UtilsControl.SetTitulo(modo, labelTitleFichaUsuario, "usuarios");

            try
            {
                usuariosNegocio = new UsuariosNegocio();
                comboBoxUsuariosProvincia.DataContext = usuariosNegocio.LeerProvincias();
            }
            catch (Exception e)
            {
                Console.WriteLine();
                //MainForm.MostrarExcepcion(e);
            }

            if (modo.Equals(Utilities.Modos.Modificar))
                Cargar(this.usuario);
        }

        private void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Provincia provincia = (Provincia)comboBoxUsuariosProvincia.SelectedItem;
            comboBoxtUsuariosLocalidad.DataContext = provincia.ListLocalidades;
        }

        public void Cargar(Usuario usuario)
        {
            /*GridUsuario.DataContext = new Usuario {
                Nombre = usuario.Nombre
            };*/
        }

    }
}