namespace Capa_presentacion
{
    partial class FichaUsuariosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxNombreFichaUsuariosForm = new System.Windows.Forms.TextBox();
            this.textBoxApellidosFichaUsuariosForm = new System.Windows.Forms.TextBox();
            this.textBoxEmailFichaUsuariosForm = new System.Windows.Forms.TextBox();
            this.textBoxPasswordFichaUsuariosForm = new System.Windows.Forms.TextBox();
            this.textBoxDocumentoFichaUsuariosForm = new System.Windows.Forms.TextBox();
            this.textBoxCalle2FichaUsuariosForm = new System.Windows.Forms.TextBox();
            this.textBoxCalle1FichaUsuariosForm = new System.Windows.Forms.TextBox();
            this.textBoxTelefonoFichaUsuariosForm = new System.Windows.Forms.TextBox();
            this.textBoxCpFichaUsuariosForm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonGuardarFichaUsuariosForm = new System.Windows.Forms.Button();
            this.labelTitleFichaUsuario = new System.Windows.Forms.Label();
            this.buttonCancelarFichaUsuariosForm = new System.Windows.Forms.Button();
            this.comboBoxLocalidadFichaUsuariosForm = new System.Windows.Forms.ComboBox();
            this.listLocalidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.provinciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxProvinciaFichaUsuariosForm = new System.Windows.Forms.ComboBox();
            this.dateFechaNacFichaUsuariosForm = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listLocalidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNombreFichaUsuariosForm
            // 
            this.textBoxNombreFichaUsuariosForm.Location = new System.Drawing.Point(20, 131);
            this.textBoxNombreFichaUsuariosForm.MaxLength = 50;
            this.textBoxNombreFichaUsuariosForm.Name = "textBoxNombreFichaUsuariosForm";
            this.textBoxNombreFichaUsuariosForm.Size = new System.Drawing.Size(400, 26);
            this.textBoxNombreFichaUsuariosForm.TabIndex = 0;
            this.textBoxNombreFichaUsuariosForm.Leave += new System.EventHandler(this.inputNombreInsertarUsuario_Leave);
            // 
            // textBoxApellidosFichaUsuariosForm
            // 
            this.textBoxApellidosFichaUsuariosForm.Location = new System.Drawing.Point(20, 203);
            this.textBoxApellidosFichaUsuariosForm.MaxLength = 50;
            this.textBoxApellidosFichaUsuariosForm.Name = "textBoxApellidosFichaUsuariosForm";
            this.textBoxApellidosFichaUsuariosForm.Size = new System.Drawing.Size(400, 26);
            this.textBoxApellidosFichaUsuariosForm.TabIndex = 1;
            this.textBoxApellidosFichaUsuariosForm.Leave += new System.EventHandler(this.textBoxApellidosInsertarUsuario_Leave);
            // 
            // textBoxEmailFichaUsuariosForm
            // 
            this.textBoxEmailFichaUsuariosForm.Location = new System.Drawing.Point(20, 275);
            this.textBoxEmailFichaUsuariosForm.MaxLength = 50;
            this.textBoxEmailFichaUsuariosForm.Name = "textBoxEmailFichaUsuariosForm";
            this.textBoxEmailFichaUsuariosForm.Size = new System.Drawing.Size(400, 26);
            this.textBoxEmailFichaUsuariosForm.TabIndex = 2;
            this.textBoxEmailFichaUsuariosForm.Leave += new System.EventHandler(this.inputEmailInsertarUsuario_Leave);
            // 
            // textBoxPasswordFichaUsuariosForm
            // 
            this.textBoxPasswordFichaUsuariosForm.Location = new System.Drawing.Point(20, 491);
            this.textBoxPasswordFichaUsuariosForm.MaxLength = 50;
            this.textBoxPasswordFichaUsuariosForm.Name = "textBoxPasswordFichaUsuariosForm";
            this.textBoxPasswordFichaUsuariosForm.PasswordChar = '*';
            this.textBoxPasswordFichaUsuariosForm.Size = new System.Drawing.Size(400, 26);
            this.textBoxPasswordFichaUsuariosForm.TabIndex = 5;
            this.textBoxPasswordFichaUsuariosForm.TextChanged += new System.EventHandler(this.TextBoxPassword_TextChanged);
            // 
            // textBoxDocumentoFichaUsuariosForm
            // 
            this.textBoxDocumentoFichaUsuariosForm.Location = new System.Drawing.Point(20, 347);
            this.textBoxDocumentoFichaUsuariosForm.MaxLength = 9;
            this.textBoxDocumentoFichaUsuariosForm.Name = "textBoxDocumentoFichaUsuariosForm";
            this.textBoxDocumentoFichaUsuariosForm.Size = new System.Drawing.Size(200, 26);
            this.textBoxDocumentoFichaUsuariosForm.TabIndex = 3;
            this.textBoxDocumentoFichaUsuariosForm.Leave += new System.EventHandler(this.inputDocumentoInsertarUsuario_Leave);
            // 
            // textBoxCalle2FichaUsuariosForm
            // 
            this.textBoxCalle2FichaUsuariosForm.Location = new System.Drawing.Point(691, 203);
            this.textBoxCalle2FichaUsuariosForm.MaxLength = 50;
            this.textBoxCalle2FichaUsuariosForm.Name = "textBoxCalle2FichaUsuariosForm";
            this.textBoxCalle2FichaUsuariosForm.Size = new System.Drawing.Size(400, 26);
            this.textBoxCalle2FichaUsuariosForm.TabIndex = 8;
            // 
            // textBoxCalle1FichaUsuariosForm
            // 
            this.textBoxCalle1FichaUsuariosForm.Location = new System.Drawing.Point(691, 131);
            this.textBoxCalle1FichaUsuariosForm.MaxLength = 50;
            this.textBoxCalle1FichaUsuariosForm.Name = "textBoxCalle1FichaUsuariosForm";
            this.textBoxCalle1FichaUsuariosForm.Size = new System.Drawing.Size(400, 26);
            this.textBoxCalle1FichaUsuariosForm.TabIndex = 7;
            // 
            // textBoxTelefonoFichaUsuariosForm
            // 
            this.textBoxTelefonoFichaUsuariosForm.Location = new System.Drawing.Point(20, 419);
            this.textBoxTelefonoFichaUsuariosForm.MaxLength = 12;
            this.textBoxTelefonoFichaUsuariosForm.Name = "textBoxTelefonoFichaUsuariosForm";
            this.textBoxTelefonoFichaUsuariosForm.Size = new System.Drawing.Size(200, 26);
            this.textBoxTelefonoFichaUsuariosForm.TabIndex = 4;
            this.textBoxTelefonoFichaUsuariosForm.Leave += new System.EventHandler(this.inputTelefonoInsertarUsuario_Leave);
            // 
            // textBoxCpFichaUsuariosForm
            // 
            this.textBoxCpFichaUsuariosForm.Location = new System.Drawing.Point(691, 419);
            this.textBoxCpFichaUsuariosForm.MaxLength = 5;
            this.textBoxCpFichaUsuariosForm.Name = "textBoxCpFichaUsuariosForm";
            this.textBoxCpFichaUsuariosForm.Size = new System.Drawing.Size(200, 26);
            this.textBoxCpFichaUsuariosForm.TabIndex = 11;
            this.textBoxCpFichaUsuariosForm.Leave += new System.EventHandler(this.inputCpInsertarUsuario_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Email (*):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nombre (*):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Apellidos (*):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "NIF/NIE (*):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Teléfono (*):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(687, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Calle 1:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(687, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Calle 2:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(687, 396);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Código Postal (*):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(687, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Pueblo (*):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(687, 252);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Provincia (*):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 540);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(161, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "Fecha Nacimiento (*):";
            // 
            // buttonGuardarFichaUsuariosForm
            // 
            this.buttonGuardarFichaUsuariosForm.Location = new System.Drawing.Point(691, 556);
            this.buttonGuardarFichaUsuariosForm.Name = "buttonGuardarFichaUsuariosForm";
            this.buttonGuardarFichaUsuariosForm.Size = new System.Drawing.Size(190, 40);
            this.buttonGuardarFichaUsuariosForm.TabIndex = 12;
            this.buttonGuardarFichaUsuariosForm.Text = "Guardar";
            this.buttonGuardarFichaUsuariosForm.UseVisualStyleBackColor = true;
            this.buttonGuardarFichaUsuariosForm.Click += new System.EventHandler(this.btnGuardarInsertarUsuario_Click);
            // 
            // labelTitleFichaUsuario
            // 
            this.labelTitleFichaUsuario.AutoSize = true;
            this.labelTitleFichaUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleFichaUsuario.Location = new System.Drawing.Point(12, 9);
            this.labelTitleFichaUsuario.Name = "labelTitleFichaUsuario";
            this.labelTitleFichaUsuario.Size = new System.Drawing.Size(0, 46);
            this.labelTitleFichaUsuario.TabIndex = 28;
            // 
            // buttonCancelarFichaUsuariosForm
            // 
            this.buttonCancelarFichaUsuariosForm.Location = new System.Drawing.Point(901, 556);
            this.buttonCancelarFichaUsuariosForm.Name = "buttonCancelarFichaUsuariosForm";
            this.buttonCancelarFichaUsuariosForm.Size = new System.Drawing.Size(190, 40);
            this.buttonCancelarFichaUsuariosForm.TabIndex = 13;
            this.buttonCancelarFichaUsuariosForm.Text = "Cancelar";
            this.buttonCancelarFichaUsuariosForm.UseVisualStyleBackColor = true;
            this.buttonCancelarFichaUsuariosForm.Click += new System.EventHandler(this.btnSalirInsertarUsuario_Click);
            // 
            // comboBoxLocalidadFichaUsuariosForm
            // 
            this.comboBoxLocalidadFichaUsuariosForm.DataSource = this.listLocalidadesBindingSource;
            this.comboBoxLocalidadFichaUsuariosForm.DisplayMember = "Nombre";
            this.comboBoxLocalidadFichaUsuariosForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocalidadFichaUsuariosForm.FormattingEnabled = true;
            this.comboBoxLocalidadFichaUsuariosForm.Location = new System.Drawing.Point(691, 345);
            this.comboBoxLocalidadFichaUsuariosForm.Name = "comboBoxLocalidadFichaUsuariosForm";
            this.comboBoxLocalidadFichaUsuariosForm.Size = new System.Drawing.Size(400, 28);
            this.comboBoxLocalidadFichaUsuariosForm.TabIndex = 10;
            // 
            // listLocalidadesBindingSource
            // 
            this.listLocalidadesBindingSource.DataMember = "ListLocalidades";
            this.listLocalidadesBindingSource.DataSource = this.provinciaBindingSource;
            // 
            // provinciaBindingSource
            // 
            this.provinciaBindingSource.DataSource = typeof(Capa_entidades.Provincia);
            // 
            // comboBoxProvinciaFichaUsuariosForm
            // 
            this.comboBoxProvinciaFichaUsuariosForm.DataSource = this.provinciaBindingSource;
            this.comboBoxProvinciaFichaUsuariosForm.DisplayMember = "Nombre";
            this.comboBoxProvinciaFichaUsuariosForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProvinciaFichaUsuariosForm.FormattingEnabled = true;
            this.comboBoxProvinciaFichaUsuariosForm.Location = new System.Drawing.Point(691, 273);
            this.comboBoxProvinciaFichaUsuariosForm.Name = "comboBoxProvinciaFichaUsuariosForm";
            this.comboBoxProvinciaFichaUsuariosForm.Size = new System.Drawing.Size(400, 28);
            this.comboBoxProvinciaFichaUsuariosForm.TabIndex = 9;
            this.comboBoxProvinciaFichaUsuariosForm.SelectedIndexChanged += new System.EventHandler(this.comboBoxProvincia_SelectedIndexChanged);
            // 
            // dateFechaNacFichaUsuariosForm
            // 
            this.dateFechaNacFichaUsuariosForm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaNacFichaUsuariosForm.Location = new System.Drawing.Point(20, 561);
            this.dateFechaNacFichaUsuariosForm.Name = "dateFechaNacFichaUsuariosForm";
            this.dateFechaNacFichaUsuariosForm.Size = new System.Drawing.Size(200, 26);
            this.dateFechaNacFichaUsuariosForm.TabIndex = 6;
            this.dateFechaNacFichaUsuariosForm.Leave += new System.EventHandler(this.dateFechaNacInsertarUsuario_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(16, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 2);
            this.label1.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 20);
            this.label14.TabIndex = 49;
            this.label14.Text = "Datos del usuario:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(687, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 20);
            this.label16.TabIndex = 51;
            this.label16.Text = "Datos postales:";
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(691, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(410, 2);
            this.label15.TabIndex = 52;
            // 
            // FichaUsuariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1123, 693);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dateFechaNacFichaUsuariosForm);
            this.Controls.Add(this.comboBoxProvinciaFichaUsuariosForm);
            this.Controls.Add(this.comboBoxLocalidadFichaUsuariosForm);
            this.Controls.Add(this.buttonCancelarFichaUsuariosForm);
            this.Controls.Add(this.labelTitleFichaUsuario);
            this.Controls.Add(this.buttonGuardarFichaUsuariosForm);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCpFichaUsuariosForm);
            this.Controls.Add(this.textBoxTelefonoFichaUsuariosForm);
            this.Controls.Add(this.textBoxCalle1FichaUsuariosForm);
            this.Controls.Add(this.textBoxCalle2FichaUsuariosForm);
            this.Controls.Add(this.textBoxDocumentoFichaUsuariosForm);
            this.Controls.Add(this.textBoxPasswordFichaUsuariosForm);
            this.Controls.Add(this.textBoxEmailFichaUsuariosForm);
            this.Controls.Add(this.textBoxApellidosFichaUsuariosForm);
            this.Controls.Add(this.textBoxNombreFichaUsuariosForm);
            this.Name = "FichaUsuariosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Ficha Usuarios";
            this.Load += new System.EventHandler(this.InsertarUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listLocalidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxNombreFichaUsuariosForm;
        private System.Windows.Forms.TextBox textBoxApellidosFichaUsuariosForm;
        private System.Windows.Forms.TextBox textBoxEmailFichaUsuariosForm;
        private System.Windows.Forms.TextBox textBoxPasswordFichaUsuariosForm;
        private System.Windows.Forms.TextBox textBoxDocumentoFichaUsuariosForm;
        private System.Windows.Forms.TextBox textBoxCalle2FichaUsuariosForm;
        private System.Windows.Forms.TextBox textBoxCalle1FichaUsuariosForm;
        private System.Windows.Forms.TextBox textBoxTelefonoFichaUsuariosForm;
        private System.Windows.Forms.TextBox textBoxCpFichaUsuariosForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonGuardarFichaUsuariosForm;
        private System.Windows.Forms.Label labelTitleFichaUsuario;
        private System.Windows.Forms.Button buttonCancelarFichaUsuariosForm;
        private System.Windows.Forms.ComboBox comboBoxLocalidadFichaUsuariosForm;
        private System.Windows.Forms.ComboBox comboBoxProvinciaFichaUsuariosForm;
        private System.Windows.Forms.DateTimePicker dateFechaNacFichaUsuariosForm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource provinciaBindingSource;
        private System.Windows.Forms.BindingSource listLocalidadesBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
    }
}