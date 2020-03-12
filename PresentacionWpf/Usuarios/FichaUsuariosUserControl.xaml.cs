using Capa_entidades;
using CapaNegocio;
using System;
using System.Windows;
using System.Windows.Controls;
using Utils;
using static Utils.Utilities;

namespace PresentacionWpf
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class FichaUsuariosUserControl : UserControl
    {
        public Modos modo;
        private MainWindow mainWindow;
        private UserControl userControlParent;
        private TableViewUsuariosUserControl tableViewUsuariosUserControl;
        private Usuario usuario;
        private UsuariosNegocio usuariosNegocio;

        public FichaUsuariosUserControl(Modos modo, Window windowParent = null, UserControl userControlParent = null)
        {
            InitializeComponent();
            this.modo = modo;
            mainWindow = (MainWindow)windowParent;
            this.userControlParent = userControlParent;
            tableViewUsuariosUserControl = (TableViewUsuariosUserControl)userControlParent;
            UtilsControl.SetTitulo(modo, labelTitleFichaUsuario, "usuarios");

            mainWindow.SetStatusException();

            try
            {
                usuariosNegocio = new UsuariosNegocio();
                comboBoxUsuariosProvincia.DataContext = usuariosNegocio.LeerProvincias();
            }
            catch (Exception e)
            {
                mainWindow.SetStatusException(e);
            }

            if (modo.Equals(Modos.Modificar))
                Cargar(tableViewUsuariosUserControl.usuario);
        }

        private void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Provincia provincia = (Provincia)comboBoxUsuariosProvincia.SelectedItem;
            comboBoxtUsuariosLocalidad.DataContext = provincia.ListLocalidades;
        }

        public void Cargar(Usuario usuario)
        {
            this.usuario = usuario;
            GridUsuario.DataContext = new Usuario {
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                Dni = usuario.Dni,
                Telefono = usuario.Telefono,
                Calle = usuario.Calle,
                Calle2 = usuario.Calle2,
                Nacido = usuario.Nacido,
                Codpos = usuario.Codpos
            };
            comboBoxUsuariosProvincia.SelectedValue = usuario.ProvinciaID;
            comboBoxtUsuariosLocalidad.SelectedValue = usuario.PuebloID;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields())
            {
                Provincia provincia = (Provincia)comboBoxUsuariosProvincia.SelectedItem;
                Localidad localidad = (Localidad)comboBoxtUsuariosLocalidad.SelectedItem;

                Usuario usuario = new Usuario(
                    txtUsuariosEmail.Text,
                    CalculateMD5Hash(txtUsuariosContrasena.Password),
                    txtUsuariosNombre.Text.ToUpper(),
                    txtUsuariosApellidos.Text.ToUpper(),
                    txtUsuariosDocumento.Text,
                    txtUsuariosTelefono.Text,
                    txtUsuariosCalle1.Text,
                    txtUsuariosCalle2.Text,
                    txtUsuariosCp.Text,
                    localidad.LocalidadID,
                    provincia.ProvinciaID,
                    datePickerFechaNac.SelectedDate.Value.Date
                );

                try
                {
                    if (modo.Equals(Modos.Insertar))
                    {
                        MessageBox.Show(usuariosNegocio.InsertarUsuario(usuario));
                    }
                    else if (modo.Equals(Modos.Modificar))
                    {
                        usuario.UsuarioID = this.usuario.UsuarioID;
                        MessageBox.Show(usuariosNegocio.ActualizarUsuario(usuario));

                        if (userControlParent != null && typeof(TableViewUsuariosUserControl).Equals(userControlParent.GetType()))
                        {
                            TableViewUsuariosUserControl uc = (TableViewUsuariosUserControl)userControlParent;
                            mainWindow.SetUserControlChildren(uc.modo, userControlParent);
                            uc.RefreshTable();
                        }
                    }
                }
                catch (Exception ex)
                {
                    mainWindow.SetStatusException(ex);
                }
                
            }
        }

        private bool ValidateFields()
        {
            if (!Validator.ValidateEmpty(txtUsuariosNombre.Text))
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_NOMBRE);
                return false;
            }
            if (!Validator.ValidateEmpty(txtUsuariosApellidos.Text))
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_APELLIDOS);
                return false;
            }
            if (!Validator.ValidateEmail(txtUsuariosEmail.Text))
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_EMAIL);
                return false;
            }
            if (!Validator.ValidateDocument(txtUsuariosDocumento.Text))
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_NIFNIE);
                return false;
            }
            if (!Validator.ValidatePhone(txtUsuariosTelefono.Text))
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_TELEFONO);
                return false;
            }
            if (!Validator.ValidatePassword(txtUsuariosContrasena.Password))
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_PASSWORD);
                return false;
            }
            if (!txtUsuariosContrasena.Password.Equals(txtUsuariosContrasena2.Password))
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_PASSWORD_COINCIDENCE);
                return false;
            }
            if (datePickerFechaNac.SelectedDate == null || !Validator.ValidateDateNac(datePickerFechaNac.SelectedDate.Value.Date))
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_NACDATE);
                return false;
            }
            if (comboBoxUsuariosProvincia.SelectedItem == null)
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_PROVINCIA);
                return false;
            }
            if (comboBoxtUsuariosLocalidad.SelectedItem == null)
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_LOCALIDAD);
                return false;
            }
            if (!Validator.ValidatePostalCode(txtUsuariosCp.Text))
            {
                MessageBox.Show(Constants.ERROR_VALIDATE_CP);
                return false;
            }
            return true;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (userControlParent != null && typeof(TableViewUsuariosUserControl).Equals(userControlParent.GetType()))
            {
                TableViewUsuariosUserControl uc = (TableViewUsuariosUserControl)userControlParent;
                mainWindow.SetUserControlChildren(uc.modo, userControlParent);
            }
            else
                mainWindow.SetUserControlChildren(Modos.Cerrar, userControlParent);
        }
    }
}