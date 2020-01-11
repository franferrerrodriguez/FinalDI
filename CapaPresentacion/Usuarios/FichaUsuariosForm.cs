using Capa_entidades;
using CapaNegocio;
using CapaPresentacion.Usuarios;
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

namespace Capa_presentacion
{
    /// <summary>
    /// Clase encargada de la ficha de usuarios
    /// </summary>
    /// <author>Francisco José Ferrer Rodríguez</author>
    public partial class FichaUsuariosForm : Form
    {
        private Utilities.Modos modo;
        private Form formParent;
        private Usuario usuario;
        private UsuariosNegocio usuariosNegocio;
        private Boolean valNombre;
        private Boolean valApellidos;
        private Boolean valEmail;
        private Boolean valPassword;
        private Boolean valDocumento;
        private Boolean valTelefono;
        private Boolean valCp;
        private Boolean valDate;

        /// <summary>
        /// Constructor de clase FichaUsuariosForm
        /// </summary>
        /// <param name="modo">(Utilities.Modos) modo</param>
        /// <param name="formParent">(Form) formParent</param>
        /// <param name="usuario">(Usuario) usuario</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public FichaUsuariosForm(Utilities.Modos modo, Form formParent = null, Usuario usuario = null)
        {
            InitializeComponent();
            Utilities.SetTitulo(modo, labelTitleFichaUsuario, "usuarios");
            this.modo = modo;
            this.formParent = formParent;
            this.usuario = usuario;

            try
            {
                usuariosNegocio = new UsuariosNegocio();
                List<Provincia> provincias = usuariosNegocio.LeerProvincias();
                comboBoxProvinciaFichaUsuariosForm.DataSource = provincias;
            }
            catch (Exception e)
            {
                MainForm.MostrarExcepcion(e);
            }

            if (modo.Equals(Utilities.Modos.Modificar))
                Cargar(this.usuario);
        }

        /// <summary>
        /// Método load del formulario
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void InsertarUsuario_Load(object sender, EventArgs e)
        {
            valNombre = false;
            valEmail = false;
            valPassword = false;
            valDocumento = false;
            valTelefono = false;
            valCp = false;
            valDate = false;
        }

        /// <summary>
        /// Método click del botón guardar para insertar el usuario
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void btnGuardarInsertarUsuario_Click(object sender, EventArgs e)
        {
            ComprobarValidacionNombre();
            ComprobarValidacionApellidos();
            ComprobarValidacionEmail();
            ComprobarValidacionDocumento();
            ComprobarValidacionTelefono();
            ComprobarValidacionCp();
            ComprobarValidacionPassword();
            ComprobarValidacionFechaNac();

            if (valNombre && 
                valEmail &&
                valPassword &&
                valDocumento && 
                valTelefono && 
                valCp && 
                valDate && 
                comboBoxProvinciaFichaUsuariosForm.SelectedItem != null && 
                comboBoxLocalidadFichaUsuariosForm.SelectedItem != null)
            {
                Provincia provincia = (Provincia)comboBoxProvinciaFichaUsuariosForm.SelectedItem;
                Localidad localidad = (Localidad)comboBoxLocalidadFichaUsuariosForm.SelectedItem;

                Usuario usuario = new Usuario(
                    textBoxEmailFichaUsuariosForm.Text,
                    Utilities.CalculateMD5Hash(textBoxPasswordFichaUsuariosForm.Text),
                    textBoxNombreFichaUsuariosForm.Text.ToUpper(),
                    textBoxApellidosFichaUsuariosForm.Text.ToUpper(),
                    textBoxDocumentoFichaUsuariosForm.Text,
                    textBoxTelefonoFichaUsuariosForm.Text,
                    textBoxCalle1FichaUsuariosForm.Text,
                    textBoxCalle2FichaUsuariosForm.Text,
                    textBoxCpFichaUsuariosForm.Text,
                    localidad.LocalidadID,
                    provincia.ProvinciaID,
                    dateFechaNacFichaUsuariosForm.Value
                );

                try
                {
                    if (modo.Equals(Utilities.Modos.Insertar))
                    {
                        MessageBox.Show(usuariosNegocio.InsertarUsuario(usuario));
                    }
                    else if (modo.Equals(Utilities.Modos.Modificar))
                    {
                        usuario.UsuarioID = this.usuario.UsuarioID;
                        MessageBox.Show(usuariosNegocio.ActualizarUsuario(usuario));

                        if (formParent.GetType().Equals(typeof(TableViewUsuariosForm)))
                        {
                            TableViewUsuariosForm f = (TableViewUsuariosForm)formParent;
                            f.RefreshTable();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MainForm.MostrarExcepcion(ex);
                }

                Close();
            }
            else
                MessageBox.Show("Existen errores en campos obligatorios, por favor, revise el formulario.");
        }

        /// <summary>
        /// Método que carga el datasource de localidades de la provincia seleccionada
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Provincia provincia = (Provincia)comboBoxProvinciaFichaUsuariosForm.SelectedItem;
            comboBoxLocalidadFichaUsuariosForm.DataSource = provincia.ListLocalidades;
        }

        /// <summary>
        /// Método textChanged que llama a la comprobación de validación del campo nombre
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void inputNombreInsertarUsuario_Leave(object sender, EventArgs e)
        {
            ComprobarValidacionNombre();
        }

        /// <summary>
        /// Método textChanged que llama a la comprobación de validación del campo apellidos
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void textBoxApellidosInsertarUsuario_Leave(object sender, EventArgs e)
        {
            ComprobarValidacionApellidos();
        }

        /// <summary>
        /// Método textChanged que llama a la comprobación de validación del campo email
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void inputEmailInsertarUsuario_Leave(object sender, EventArgs e)
        {
            ComprobarValidacionEmail();
        }

        /// <summary>
        /// Método textChanged que llama a la comprobación de validación del campo documento
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void inputDocumentoInsertarUsuario_Leave(object sender, EventArgs e)
        {
            ComprobarValidacionDocumento();
        }

        /// <summary>
        /// Método textChanged que llama a la comprobación de validación del campo telefono
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void inputTelefonoInsertarUsuario_Leave(object sender, EventArgs e)
        {
            ComprobarValidacionTelefono();
        }

        /// <summary>
        /// Método textChanged que llama a la comprobación de validación del campo cp
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void inputCpInsertarUsuario_Leave(object sender, EventArgs e)
        {
            ComprobarValidacionCp();
        }

        /// <summary>
        /// Método textChanged que llama a la comprobación de validación del campo nacimiento
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void dateFechaNacInsertarUsuario_Leave(object sender, EventArgs e)
        {
            ComprobarValidacionFechaNac();
        }

        /// <summary>
        /// Método textChanged que llama a la comprobación de validación del campo password
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            ComprobarValidacionPassword();
        }

        /// <summary>
        /// Método que comprueba la validación del campo nombre
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void ComprobarValidacionNombre()
        {
            valNombre = Validator.ValidateEmpty(textBoxNombreFichaUsuariosForm.Text);
            if (!valNombre)
                Validator.IndicarError(textBoxNombreFichaUsuariosForm, errorProvider1, true, Constants.ERROR_VALIDATE_NOMBRE);
            else
                Validator.IndicarError(textBoxNombreFichaUsuariosForm, errorProvider1);
        }

        /// <summary>
        /// Método que comprueba la validación del campo apellidos
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void ComprobarValidacionApellidos()
        {
            valApellidos = Validator.ValidateEmpty(textBoxApellidosFichaUsuariosForm.Text);
            if (!valApellidos)
                Validator.IndicarError(textBoxApellidosFichaUsuariosForm, errorProvider1, true, Constants.ERROR_VALIDATE_APELLIDOS);
            else
                Validator.IndicarError(textBoxApellidosFichaUsuariosForm, errorProvider1);
        }

        /// <summary>
        /// Método que comprueba la validación del campo email
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void ComprobarValidacionEmail()
        {
            valEmail = Validator.ValidateEmail(textBoxEmailFichaUsuariosForm.Text);
            if (!valEmail)
                Validator.IndicarError(textBoxEmailFichaUsuariosForm, errorProvider1, true, Constants.ERROR_VALIDATE_NOMBRE);
            else
                Validator.IndicarError(textBoxEmailFichaUsuariosForm, errorProvider1);
        }

        /// <summary>
        /// Método que comprueba la validación del campo documento
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void ComprobarValidacionDocumento()
        {
            valDocumento = Validator.ValidateDocument(textBoxDocumentoFichaUsuariosForm.Text);
            if (!valDocumento)
                Validator.IndicarError(textBoxDocumentoFichaUsuariosForm, errorProvider1, true, Constants.ERROR_VALIDATE_NIFNIE);
            else
                Validator.IndicarError(textBoxDocumentoFichaUsuariosForm, errorProvider1);
        }

        /// <summary>
        /// Método que comprueba la validación del campo telefono
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void ComprobarValidacionTelefono()
        {
            valTelefono = Validator.ValidatePhone(textBoxTelefonoFichaUsuariosForm.Text);
            if (!valTelefono)
                Validator.IndicarError(textBoxTelefonoFichaUsuariosForm, errorProvider1, true, Constants.ERROR_VALIDATE_TELEFONO);
            else
                Validator.IndicarError(textBoxTelefonoFichaUsuariosForm, errorProvider1);
        }

        /// <summary>
        /// Método que comprueba la validación del campo cp
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void ComprobarValidacionCp()
        {
            valCp = Validator.ValidatePostalCode(textBoxCpFichaUsuariosForm.Text);
            if (!valCp)
                Validator.IndicarError(textBoxCpFichaUsuariosForm, errorProvider1, true, Constants.ERROR_VALIDATE_CP);
            else
                Validator.IndicarError(textBoxCpFichaUsuariosForm, errorProvider1);
        }

        /// <summary>
        /// Método que comprueba la validación del campo fecha de nacimiento
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void ComprobarValidacionFechaNac()
        {
            valDate = Validator.ValidateDateNac(dateFechaNacFichaUsuariosForm.Value);
            if (!valDate)
                Validator.IndicarError(dateFechaNacFichaUsuariosForm, errorProvider1, true, Constants.ERROR_VALIDATE_NACDATE);
            else
                Validator.IndicarError(dateFechaNacFichaUsuariosForm, errorProvider1);
        }

        /// <summary>
        /// Método que comprueba la validación del campo password
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void ComprobarValidacionPassword()
        {
            valPassword = Validator.ValidatePassword(textBoxPasswordFichaUsuariosForm.Text);
            if (!valPassword)
                Validator.IndicarError(textBoxPasswordFichaUsuariosForm, errorProvider1, true, Constants.ERROR_VALIDATE_PASSWORD);
            else
                Validator.IndicarError(textBoxPasswordFichaUsuariosForm, errorProvider1);
        }

        /// <summary>
        /// Método que comprueba la validación del campo password
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void ResetForm()
        {
            textBoxNombreFichaUsuariosForm.Text = "";
            textBoxApellidosFichaUsuariosForm.Text = "";
            textBoxEmailFichaUsuariosForm.Text = "";
            textBoxDocumentoFichaUsuariosForm.Text = "";
            textBoxTelefonoFichaUsuariosForm.Text = "";
            textBoxPasswordFichaUsuariosForm.Text = "";
            dateFechaNacFichaUsuariosForm.Value = DateTime.Now;
            textBoxCalle1FichaUsuariosForm.Text = "";
            textBoxCalle2FichaUsuariosForm.Text = "";
            comboBoxProvinciaFichaUsuariosForm.SelectedIndex = 0;
            comboBoxLocalidadFichaUsuariosForm.SelectedIndex = 0;
            textBoxCpFichaUsuariosForm.Text = "";
        }

        /// <summary>
        /// Método que carga un usuario pasado por constructor en el formulario
        /// </summary>
        /// <param name="usuario">(Usuario) usuario</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        public void Cargar(Usuario usuario)
        {
            textBoxNombreFichaUsuariosForm.Text = usuario.Nombre;
            textBoxApellidosFichaUsuariosForm.Text = usuario.Apellidos;
            textBoxEmailFichaUsuariosForm.Text = usuario.Email;
            textBoxDocumentoFichaUsuariosForm.Text = usuario.Dni;
            textBoxTelefonoFichaUsuariosForm.Text = usuario.Telefono;
            dateFechaNacFichaUsuariosForm.Value = usuario.Nacido ?? DateTime.Now;
            textBoxCalle1FichaUsuariosForm.Text = usuario.Calle;
            textBoxCalle2FichaUsuariosForm.Text = usuario.Calle2;
            comboBoxProvinciaFichaUsuariosForm.Text = usuario.ProvinciaID;
            comboBoxLocalidadFichaUsuariosForm.Text = usuario.PuebloID;
            textBoxCpFichaUsuariosForm.Text = usuario.Codpos;
        }

        /// <summary>
        /// Método click del botón cancelar para regresar al formulario anterior
        /// </summary>
        /// <param name="sender">(object) sender</param>
        /// <param name="e">(EventArgs) e</param>
        /// <returns>void</returns>
        /// <author>Francisco José Ferrer Rodríguez</author>
        private void btnSalirInsertarUsuario_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}