namespace CapaPresentacion
{
    partial class FacturaForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.EFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.EFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EArticuloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // EFacturaBindingSource
            // 
            this.EFacturaBindingSource.DataSource = typeof(CapaPresentacion.Informes.EFactura);
            // 
            // EArticuloBindingSource
            // 
            this.EArticuloBindingSource.DataSource = typeof(CapaPresentacion.Informes.ArticuloFactura);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Encabezado";
            reportDataSource1.Value = this.EFacturaBindingSource;
            reportDataSource2.Name = "Detalle";
            reportDataSource2.Value = this.EArticuloBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.ReportFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(976, 1083);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // FacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 1083);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FacturaForm";
            this.Text = "Facturas";
            ((System.ComponentModel.ISupportInitialize)(this.EFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EArticuloBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EFacturaBindingSource;
        private System.Windows.Forms.BindingSource EArticuloBindingSource;
    }
}