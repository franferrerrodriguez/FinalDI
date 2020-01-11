namespace CapaPresentacion.Productos
{
    partial class TableViewProductosForm
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
            this.buttonGuardarTableViewProductosForm = new System.Windows.Forms.Button();
            this.buttonCancelarTableViewProductosForm = new System.Windows.Forms.Button();
            this.comboBoxTableViewProductosForm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFiltrarTableViewProductosForm = new System.Windows.Forms.TextBox();
            this.dataGridListaTableViewProductosForm = new System.Windows.Forms.DataGridView();
            this.labelTitleTableViewTableViewProductosForm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListaTableViewProductosForm)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGuardarTableViewProductosForm
            // 
            this.buttonGuardarTableViewProductosForm.Location = new System.Drawing.Point(725, 97);
            this.buttonGuardarTableViewProductosForm.Name = "buttonGuardarTableViewProductosForm";
            this.buttonGuardarTableViewProductosForm.Size = new System.Drawing.Size(190, 40);
            this.buttonGuardarTableViewProductosForm.TabIndex = 2;
            this.buttonGuardarTableViewProductosForm.Text = "Guardar";
            this.buttonGuardarTableViewProductosForm.UseVisualStyleBackColor = true;
            this.buttonGuardarTableViewProductosForm.Click += new System.EventHandler(this.buttonGuardarTableViewProductosForm_Click);
            // 
            // buttonCancelarTableViewProductosForm
            // 
            this.buttonCancelarTableViewProductosForm.Location = new System.Drawing.Point(921, 97);
            this.buttonCancelarTableViewProductosForm.Name = "buttonCancelarTableViewProductosForm";
            this.buttonCancelarTableViewProductosForm.Size = new System.Drawing.Size(190, 40);
            this.buttonCancelarTableViewProductosForm.TabIndex = 3;
            this.buttonCancelarTableViewProductosForm.Text = "Cancelar";
            this.buttonCancelarTableViewProductosForm.UseVisualStyleBackColor = true;
            this.buttonCancelarTableViewProductosForm.Click += new System.EventHandler(this.buttonCancelarTableViewProductosForm_Click);
            // 
            // comboBoxTableViewProductosForm
            // 
            this.comboBoxTableViewProductosForm.DisplayMember = "Descripcion";
            this.comboBoxTableViewProductosForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTableViewProductosForm.FormattingEnabled = true;
            this.comboBoxTableViewProductosForm.Location = new System.Drawing.Point(407, 103);
            this.comboBoxTableViewProductosForm.Name = "comboBoxTableViewProductosForm";
            this.comboBoxTableViewProductosForm.Size = new System.Drawing.Size(292, 28);
            this.comboBoxTableViewProductosForm.TabIndex = 1;
            this.comboBoxTableViewProductosForm.SelectedIndexChanged += new System.EventHandler(this.comboBoxTableViewProductosForm_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Filtrar por tipo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Filtrar por nombre:";
            // 
            // textBoxFiltrarTableViewProductosForm
            // 
            this.textBoxFiltrarTableViewProductosForm.Location = new System.Drawing.Point(12, 104);
            this.textBoxFiltrarTableViewProductosForm.Name = "textBoxFiltrarTableViewProductosForm";
            this.textBoxFiltrarTableViewProductosForm.Size = new System.Drawing.Size(378, 26);
            this.textBoxFiltrarTableViewProductosForm.TabIndex = 0;
            this.textBoxFiltrarTableViewProductosForm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFiltrarTableViewProductosForm_KeyUp);
            // 
            // dataGridListaTableViewProductosForm
            // 
            this.dataGridListaTableViewProductosForm.AllowUserToAddRows = false;
            this.dataGridListaTableViewProductosForm.AllowUserToDeleteRows = false;
            this.dataGridListaTableViewProductosForm.AllowUserToResizeColumns = false;
            this.dataGridListaTableViewProductosForm.AllowUserToResizeRows = false;
            this.dataGridListaTableViewProductosForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridListaTableViewProductosForm.Location = new System.Drawing.Point(12, 151);
            this.dataGridListaTableViewProductosForm.MultiSelect = false;
            this.dataGridListaTableViewProductosForm.Name = "dataGridListaTableViewProductosForm";
            this.dataGridListaTableViewProductosForm.ReadOnly = true;
            this.dataGridListaTableViewProductosForm.RowTemplate.Height = 28;
            this.dataGridListaTableViewProductosForm.Size = new System.Drawing.Size(1099, 530);
            this.dataGridListaTableViewProductosForm.TabIndex = 41;
            this.dataGridListaTableViewProductosForm.Click += new System.EventHandler(this.dataGridListaTableViewProductosForm_Click);
            // 
            // labelTitleTableViewTableViewProductosForm
            // 
            this.labelTitleTableViewTableViewProductosForm.AutoSize = true;
            this.labelTitleTableViewTableViewProductosForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleTableViewTableViewProductosForm.Location = new System.Drawing.Point(9, 9);
            this.labelTitleTableViewTableViewProductosForm.Name = "labelTitleTableViewTableViewProductosForm";
            this.labelTitleTableViewTableViewProductosForm.Size = new System.Drawing.Size(0, 46);
            this.labelTitleTableViewTableViewProductosForm.TabIndex = 42;
            // 
            // TableViewProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 693);
            this.Controls.Add(this.labelTitleTableViewTableViewProductosForm);
            this.Controls.Add(this.dataGridListaTableViewProductosForm);
            this.Controls.Add(this.buttonGuardarTableViewProductosForm);
            this.Controls.Add(this.buttonCancelarTableViewProductosForm);
            this.Controls.Add(this.comboBoxTableViewProductosForm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFiltrarTableViewProductosForm);
            this.Name = "TableViewProductosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de productos";
            this.Load += new System.EventHandler(this.TableViewProductosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListaTableViewProductosForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGuardarTableViewProductosForm;
        private System.Windows.Forms.Button buttonCancelarTableViewProductosForm;
        private System.Windows.Forms.ComboBox comboBoxTableViewProductosForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridListaTableViewProductosForm;
        private System.Windows.Forms.Label labelTitleTableViewTableViewProductosForm;
        public System.Windows.Forms.TextBox textBoxFiltrarTableViewProductosForm;
    }
}