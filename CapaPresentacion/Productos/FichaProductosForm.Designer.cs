namespace CapaPresentacion.Productos
{
    partial class FichaProductosForm
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
            this.dataGridFichaProductosForm = new System.Windows.Forms.DataGridView();
            this.labelTitleFichaProductosForm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFiltrarFichaProductosForm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxFichaProductosForm = new System.Windows.Forms.ComboBox();
            this.tipoArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoArticuloADOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCancelarFichaProductosForm = new System.Windows.Forms.Button();
            this.textBoxIdFichaProductosForm = new System.Windows.Forms.TextBox();
            this.textBoxNombreFichaProductosForm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMarcaFichaProductosForm = new System.Windows.Forms.TextBox();
            this.textBoxEspecificacionesFichaProductosForm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPvpFichaProductosForm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelDetallesSubtipoSeparadorFichaProductosForm = new System.Windows.Forms.Label();
            this.labelDetallesSubtipoFichaProductosForm = new System.Windows.Forms.Label();
            this.buttonGuardarFichaProductosForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFichaProductosForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoArticuloBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoArticuloADOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridFichaProductosForm
            // 
            this.dataGridFichaProductosForm.AllowUserToAddRows = false;
            this.dataGridFichaProductosForm.AllowUserToDeleteRows = false;
            this.dataGridFichaProductosForm.AllowUserToResizeColumns = false;
            this.dataGridFichaProductosForm.AllowUserToResizeRows = false;
            this.dataGridFichaProductosForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFichaProductosForm.Location = new System.Drawing.Point(12, 142);
            this.dataGridFichaProductosForm.Name = "dataGridFichaProductosForm";
            this.dataGridFichaProductosForm.ReadOnly = true;
            this.dataGridFichaProductosForm.RowTemplate.Height = 28;
            this.dataGridFichaProductosForm.Size = new System.Drawing.Size(549, 539);
            this.dataGridFichaProductosForm.TabIndex = 0;
            this.dataGridFichaProductosForm.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFichaProductosForm_CellEnter);
            // 
            // labelTitleFichaProductosForm
            // 
            this.labelTitleFichaProductosForm.AutoSize = true;
            this.labelTitleFichaProductosForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleFichaProductosForm.Location = new System.Drawing.Point(9, 9);
            this.labelTitleFichaProductosForm.Name = "labelTitleFichaProductosForm";
            this.labelTitleFichaProductosForm.Size = new System.Drawing.Size(0, 46);
            this.labelTitleFichaProductosForm.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Filtrar producto por nombre:";
            // 
            // textBoxFiltrarFichaProductosForm
            // 
            this.textBoxFiltrarFichaProductosForm.Location = new System.Drawing.Point(12, 104);
            this.textBoxFiltrarFichaProductosForm.Name = "textBoxFiltrarFichaProductosForm";
            this.textBoxFiltrarFichaProductosForm.Size = new System.Drawing.Size(378, 26);
            this.textBoxFiltrarFichaProductosForm.TabIndex = 0;
            this.textBoxFiltrarFichaProductosForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFiltrarConsultarProductos_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Filtrar por tipo:";
            // 
            // comboBoxFichaProductosForm
            // 
            this.comboBoxFichaProductosForm.DataSource = this.tipoArticuloBindingSource;
            this.comboBoxFichaProductosForm.DisplayMember = "Descripcion";
            this.comboBoxFichaProductosForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFichaProductosForm.FormattingEnabled = true;
            this.comboBoxFichaProductosForm.Location = new System.Drawing.Point(407, 103);
            this.comboBoxFichaProductosForm.Name = "comboBoxFichaProductosForm";
            this.comboBoxFichaProductosForm.Size = new System.Drawing.Size(292, 28);
            this.comboBoxFichaProductosForm.TabIndex = 1;
            this.comboBoxFichaProductosForm.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoArticuloConsultarProductos_SelectedIndexChanged);
            // 
            // tipoArticuloBindingSource
            // 
            this.tipoArticuloBindingSource.DataSource = typeof(Capa_entidades.TipoArticulo);
            // 
            // buttonCancelarFichaProductosForm
            // 
            this.buttonCancelarFichaProductosForm.Location = new System.Drawing.Point(921, 97);
            this.buttonCancelarFichaProductosForm.Name = "buttonCancelarFichaProductosForm";
            this.buttonCancelarFichaProductosForm.Size = new System.Drawing.Size(190, 40);
            this.buttonCancelarFichaProductosForm.TabIndex = 3;
            this.buttonCancelarFichaProductosForm.Text = "Cancelar";
            this.buttonCancelarFichaProductosForm.UseVisualStyleBackColor = true;
            this.buttonCancelarFichaProductosForm.Click += new System.EventHandler(this.buttonCancelarConsultarProductos_Click);
            // 
            // textBoxIdFichaProductosForm
            // 
            this.textBoxIdFichaProductosForm.Location = new System.Drawing.Point(577, 206);
            this.textBoxIdFichaProductosForm.Name = "textBoxIdFichaProductosForm";
            this.textBoxIdFichaProductosForm.Size = new System.Drawing.Size(122, 26);
            this.textBoxIdFichaProductosForm.TabIndex = 50;
            // 
            // textBoxNombreFichaProductosForm
            // 
            this.textBoxNombreFichaProductosForm.Location = new System.Drawing.Point(577, 268);
            this.textBoxNombreFichaProductosForm.Name = "textBoxNombreFichaProductosForm";
            this.textBoxNombreFichaProductosForm.Size = new System.Drawing.Size(262, 26);
            this.textBoxNombreFichaProductosForm.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(573, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(573, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "Nombre:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(845, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "Marca:";
            // 
            // textBoxMarcaFichaProductosForm
            // 
            this.textBoxMarcaFichaProductosForm.Location = new System.Drawing.Point(849, 268);
            this.textBoxMarcaFichaProductosForm.Name = "textBoxMarcaFichaProductosForm";
            this.textBoxMarcaFichaProductosForm.Size = new System.Drawing.Size(262, 26);
            this.textBoxMarcaFichaProductosForm.TabIndex = 50;
            // 
            // textBoxEspecificacionesFichaProductosForm
            // 
            this.textBoxEspecificacionesFichaProductosForm.Location = new System.Drawing.Point(577, 330);
            this.textBoxEspecificacionesFichaProductosForm.Name = "textBoxEspecificacionesFichaProductosForm";
            this.textBoxEspecificacionesFichaProductosForm.Size = new System.Drawing.Size(262, 26);
            this.textBoxEspecificacionesFichaProductosForm.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(573, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.label7.TabIndex = 43;
            this.label7.Text = "Especificaciones:";
            // 
            // textBoxPvpFichaProductosForm
            // 
            this.textBoxPvpFichaProductosForm.Location = new System.Drawing.Point(849, 330);
            this.textBoxPvpFichaProductosForm.Name = "textBoxPvpFichaProductosForm";
            this.textBoxPvpFichaProductosForm.Size = new System.Drawing.Size(262, 26);
            this.textBoxPvpFichaProductosForm.TabIndex = 50;
            this.textBoxPvpFichaProductosForm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPvpFichaProductosForm_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(845, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 20);
            this.label8.TabIndex = 45;
            this.label8.Text = "PvP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(573, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 47;
            this.label2.Text = "Datos del artículo:";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(573, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(538, 2);
            this.label9.TabIndex = 48;
            // 
            // labelDetallesSubtipoSeparadorFichaProductosForm
            // 
            this.labelDetallesSubtipoSeparadorFichaProductosForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDetallesSubtipoSeparadorFichaProductosForm.Location = new System.Drawing.Point(573, 416);
            this.labelDetallesSubtipoSeparadorFichaProductosForm.Name = "labelDetallesSubtipoSeparadorFichaProductosForm";
            this.labelDetallesSubtipoSeparadorFichaProductosForm.Size = new System.Drawing.Size(538, 2);
            this.labelDetallesSubtipoSeparadorFichaProductosForm.TabIndex = 50;
            // 
            // labelDetallesSubtipoFichaProductosForm
            // 
            this.labelDetallesSubtipoFichaProductosForm.AutoSize = true;
            this.labelDetallesSubtipoFichaProductosForm.Location = new System.Drawing.Point(573, 387);
            this.labelDetallesSubtipoFichaProductosForm.Name = "labelDetallesSubtipoFichaProductosForm";
            this.labelDetallesSubtipoFichaProductosForm.Size = new System.Drawing.Size(152, 20);
            this.labelDetallesSubtipoFichaProductosForm.TabIndex = 49;
            this.labelDetallesSubtipoFichaProductosForm.Text = "Detalles del subtipo:";
            // 
            // buttonGuardarFichaProductosForm
            // 
            this.buttonGuardarFichaProductosForm.Location = new System.Drawing.Point(725, 97);
            this.buttonGuardarFichaProductosForm.Name = "buttonGuardarFichaProductosForm";
            this.buttonGuardarFichaProductosForm.Size = new System.Drawing.Size(190, 40);
            this.buttonGuardarFichaProductosForm.TabIndex = 2;
            this.buttonGuardarFichaProductosForm.Text = "Guardar";
            this.buttonGuardarFichaProductosForm.UseVisualStyleBackColor = true;
            this.buttonGuardarFichaProductosForm.Click += new System.EventHandler(this.buttonGuardarFichaProductosForm_Click);
            // 
            // FichaProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 693);
            this.Controls.Add(this.buttonGuardarFichaProductosForm);
            this.Controls.Add(this.labelDetallesSubtipoSeparadorFichaProductosForm);
            this.Controls.Add(this.labelDetallesSubtipoFichaProductosForm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPvpFichaProductosForm);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxEspecificacionesFichaProductosForm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxMarcaFichaProductosForm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNombreFichaProductosForm);
            this.Controls.Add(this.textBoxIdFichaProductosForm);
            this.Controls.Add(this.buttonCancelarFichaProductosForm);
            this.Controls.Add(this.comboBoxFichaProductosForm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFiltrarFichaProductosForm);
            this.Controls.Add(this.labelTitleFichaProductosForm);
            this.Controls.Add(this.dataGridFichaProductosForm);
            this.Name = "FichaProductosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha de productos";
            this.Load += new System.EventHandler(this.ConsultarProductosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFichaProductosForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoArticuloBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoArticuloADOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFichaProductosForm;
        private System.Windows.Forms.Label labelTitleFichaProductosForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFiltrarFichaProductosForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxFichaProductosForm;
        private System.Windows.Forms.BindingSource tipoArticuloBindingSource;
        private System.Windows.Forms.BindingSource tipoArticuloADOBindingSource;
        private System.Windows.Forms.Button buttonCancelarFichaProductosForm;
        private System.Windows.Forms.TextBox textBoxIdFichaProductosForm;
        private System.Windows.Forms.TextBox textBoxNombreFichaProductosForm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMarcaFichaProductosForm;
        private System.Windows.Forms.TextBox textBoxEspecificacionesFichaProductosForm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPvpFichaProductosForm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelDetallesSubtipoSeparadorFichaProductosForm;
        private System.Windows.Forms.Label labelDetallesSubtipoFichaProductosForm;
        private System.Windows.Forms.Button buttonGuardarFichaProductosForm;
    }
}