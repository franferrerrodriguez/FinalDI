namespace CapaPresentacion.Usuarios
{
    partial class TableViewUsuariosForm
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
            this.dataGridListaTableViewUsuariosForm = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBoxFiltrarNombreTableViewUsuariosForm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTitleTableViewTableViewUsuariosForm = new System.Windows.Forms.Label();
            this.buttonCancelarTableViewUsuariosForm = new System.Windows.Forms.Button();
            this.textBoxFiltrarApellidosTableViewUsuariosForm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFiltrarDocumentoTableViewUsuariosForm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFiltrarEmailTableViewUsuariosForm = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListaTableViewUsuariosForm)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridListaTableViewUsuariosForm
            // 
            this.dataGridListaTableViewUsuariosForm.AllowUserToAddRows = false;
            this.dataGridListaTableViewUsuariosForm.AllowUserToDeleteRows = false;
            this.dataGridListaTableViewUsuariosForm.AllowUserToResizeColumns = false;
            this.dataGridListaTableViewUsuariosForm.AllowUserToResizeRows = false;
            this.dataGridListaTableViewUsuariosForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridListaTableViewUsuariosForm.Location = new System.Drawing.Point(12, 207);
            this.dataGridListaTableViewUsuariosForm.MultiSelect = false;
            this.dataGridListaTableViewUsuariosForm.Name = "dataGridListaTableViewUsuariosForm";
            this.dataGridListaTableViewUsuariosForm.ReadOnly = true;
            this.dataGridListaTableViewUsuariosForm.RowTemplate.Height = 28;
            this.dataGridListaTableViewUsuariosForm.Size = new System.Drawing.Size(1099, 474);
            this.dataGridListaTableViewUsuariosForm.TabIndex = 0;
            this.dataGridListaTableViewUsuariosForm.Click += new System.EventHandler(this.dataGridListaModificarUsuario_Click);
            // 
            // textBoxFiltrarNombreTableViewUsuariosForm
            // 
            this.textBoxFiltrarNombreTableViewUsuariosForm.Location = new System.Drawing.Point(12, 98);
            this.textBoxFiltrarNombreTableViewUsuariosForm.Name = "textBoxFiltrarNombreTableViewUsuariosForm";
            this.textBoxFiltrarNombreTableViewUsuariosForm.Size = new System.Drawing.Size(300, 26);
            this.textBoxFiltrarNombreTableViewUsuariosForm.TabIndex = 0;
            this.textBoxFiltrarNombreTableViewUsuariosForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFiltrarEditarUsuarios_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtro nombre:";
            // 
            // labelTitleTableViewTableViewUsuariosForm
            // 
            this.labelTitleTableViewTableViewUsuariosForm.AutoSize = true;
            this.labelTitleTableViewTableViewUsuariosForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleTableViewTableViewUsuariosForm.Location = new System.Drawing.Point(8, 9);
            this.labelTitleTableViewTableViewUsuariosForm.Name = "labelTitleTableViewTableViewUsuariosForm";
            this.labelTitleTableViewTableViewUsuariosForm.Size = new System.Drawing.Size(0, 46);
            this.labelTitleTableViewTableViewUsuariosForm.TabIndex = 29;
            // 
            // buttonCancelarTableViewUsuariosForm
            // 
            this.buttonCancelarTableViewUsuariosForm.Location = new System.Drawing.Point(921, 98);
            this.buttonCancelarTableViewUsuariosForm.Name = "buttonCancelarTableViewUsuariosForm";
            this.buttonCancelarTableViewUsuariosForm.Size = new System.Drawing.Size(190, 40);
            this.buttonCancelarTableViewUsuariosForm.TabIndex = 4;
            this.buttonCancelarTableViewUsuariosForm.Text = "Cancelar";
            this.buttonCancelarTableViewUsuariosForm.UseVisualStyleBackColor = true;
            this.buttonCancelarTableViewUsuariosForm.Click += new System.EventHandler(this.buttonCancelarModificarUsuario_Click);
            // 
            // textBoxFiltrarApellidosTableViewUsuariosForm
            // 
            this.textBoxFiltrarApellidosTableViewUsuariosForm.Location = new System.Drawing.Point(318, 98);
            this.textBoxFiltrarApellidosTableViewUsuariosForm.Name = "textBoxFiltrarApellidosTableViewUsuariosForm";
            this.textBoxFiltrarApellidosTableViewUsuariosForm.Size = new System.Drawing.Size(300, 26);
            this.textBoxFiltrarApellidosTableViewUsuariosForm.TabIndex = 1;
            this.textBoxFiltrarApellidosTableViewUsuariosForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFiltrarApellidosTableViewUsuariosForm_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Filtro apellidos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Filtro documento:";
            // 
            // textBoxFiltrarDocumentoTableViewUsuariosForm
            // 
            this.textBoxFiltrarDocumentoTableViewUsuariosForm.Location = new System.Drawing.Point(318, 160);
            this.textBoxFiltrarDocumentoTableViewUsuariosForm.Name = "textBoxFiltrarDocumentoTableViewUsuariosForm";
            this.textBoxFiltrarDocumentoTableViewUsuariosForm.Size = new System.Drawing.Size(300, 26);
            this.textBoxFiltrarDocumentoTableViewUsuariosForm.TabIndex = 3;
            this.textBoxFiltrarDocumentoTableViewUsuariosForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFiltrarDocumentoTableViewUsuariosForm_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Filtro email:";
            // 
            // textBoxFiltrarEmailTableViewUsuariosForm
            // 
            this.textBoxFiltrarEmailTableViewUsuariosForm.Location = new System.Drawing.Point(12, 160);
            this.textBoxFiltrarEmailTableViewUsuariosForm.Name = "textBoxFiltrarEmailTableViewUsuariosForm";
            this.textBoxFiltrarEmailTableViewUsuariosForm.Size = new System.Drawing.Size(300, 26);
            this.textBoxFiltrarEmailTableViewUsuariosForm.TabIndex = 2;
            this.textBoxFiltrarEmailTableViewUsuariosForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFiltrarEmailTableViewUsuariosForm_KeyUp);
            // 
            // TableViewUsuariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 693);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFiltrarDocumentoTableViewUsuariosForm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxFiltrarEmailTableViewUsuariosForm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFiltrarApellidosTableViewUsuariosForm);
            this.Controls.Add(this.buttonCancelarTableViewUsuariosForm);
            this.Controls.Add(this.labelTitleTableViewTableViewUsuariosForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFiltrarNombreTableViewUsuariosForm);
            this.Controls.Add(this.dataGridListaTableViewUsuariosForm);
            this.Name = "TableViewUsuariosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de usuarios";
            this.Load += new System.EventHandler(this.ModificarUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListaTableViewUsuariosForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBoxFiltrarNombreTableViewUsuariosForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitleTableViewTableViewUsuariosForm;
        private System.Windows.Forms.Button buttonCancelarTableViewUsuariosForm;
        public System.Windows.Forms.DataGridView dataGridListaTableViewUsuariosForm;
        private System.Windows.Forms.TextBox textBoxFiltrarApellidosTableViewUsuariosForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFiltrarDocumentoTableViewUsuariosForm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFiltrarEmailTableViewUsuariosForm;
    }
}