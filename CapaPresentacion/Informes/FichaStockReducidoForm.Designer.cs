namespace CapaPresentacion.Informes
{
    partial class FichaStockReducidoForm
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
            this.labelTitleFichaStockReducidoForm = new System.Windows.Forms.Label();
            this.buttonCancelarFichaStockReducidoForm = new System.Windows.Forms.Button();
            this.buttonGuardarFichaStockReducidoForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFichaStockReducidoForm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelTitleFichaStockReducidoForm
            // 
            this.labelTitleFichaStockReducidoForm.AutoSize = true;
            this.labelTitleFichaStockReducidoForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleFichaStockReducidoForm.Location = new System.Drawing.Point(9, 9);
            this.labelTitleFichaStockReducidoForm.Name = "labelTitleFichaStockReducidoForm";
            this.labelTitleFichaStockReducidoForm.Size = new System.Drawing.Size(0, 46);
            this.labelTitleFichaStockReducidoForm.TabIndex = 31;
            // 
            // buttonCancelarFichaStockReducidoForm
            // 
            this.buttonCancelarFichaStockReducidoForm.Location = new System.Drawing.Point(921, 97);
            this.buttonCancelarFichaStockReducidoForm.Name = "buttonCancelarFichaStockReducidoForm";
            this.buttonCancelarFichaStockReducidoForm.Size = new System.Drawing.Size(190, 40);
            this.buttonCancelarFichaStockReducidoForm.TabIndex = 2;
            this.buttonCancelarFichaStockReducidoForm.Text = "Cancelar";
            this.buttonCancelarFichaStockReducidoForm.UseVisualStyleBackColor = true;
            this.buttonCancelarFichaStockReducidoForm.Click += new System.EventHandler(this.buttonCancelarFichaStockReducidoForm_Click);
            // 
            // buttonGuardarFichaStockReducidoForm
            // 
            this.buttonGuardarFichaStockReducidoForm.Location = new System.Drawing.Point(725, 97);
            this.buttonGuardarFichaStockReducidoForm.Name = "buttonGuardarFichaStockReducidoForm";
            this.buttonGuardarFichaStockReducidoForm.Size = new System.Drawing.Size(190, 40);
            this.buttonGuardarFichaStockReducidoForm.TabIndex = 1;
            this.buttonGuardarFichaStockReducidoForm.Text = "Generar informe";
            this.buttonGuardarFichaStockReducidoForm.UseVisualStyleBackColor = true;
            this.buttonGuardarFichaStockReducidoForm.Click += new System.EventHandler(this.buttonGuardarFichaStockReducidoForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Límite de stock:";
            // 
            // textBoxFichaStockReducidoForm
            // 
            this.textBoxFichaStockReducidoForm.Location = new System.Drawing.Point(12, 103);
            this.textBoxFichaStockReducidoForm.Name = "textBoxFichaStockReducidoForm";
            this.textBoxFichaStockReducidoForm.Size = new System.Drawing.Size(378, 26);
            this.textBoxFichaStockReducidoForm.TabIndex = 0;
            this.textBoxFichaStockReducidoForm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFiltrarFichaProductosForm_KeyPress);
            // 
            // FichaStockReducidoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 693);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFichaStockReducidoForm);
            this.Controls.Add(this.buttonGuardarFichaStockReducidoForm);
            this.Controls.Add(this.buttonCancelarFichaStockReducidoForm);
            this.Controls.Add(this.labelTitleFichaStockReducidoForm);
            this.Name = "FichaStockReducidoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock reducido";
            this.Load += new System.EventHandler(this.FichaStockReducidoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleFichaStockReducidoForm;
        private System.Windows.Forms.Button buttonCancelarFichaStockReducidoForm;
        private System.Windows.Forms.Button buttonGuardarFichaStockReducidoForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFichaStockReducidoForm;
    }
}