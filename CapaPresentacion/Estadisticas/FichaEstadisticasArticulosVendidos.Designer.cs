namespace CapaPresentacion.Estadisticas
{
    partial class FichaEstadisticasArticulosVendidos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelTitleEstadisticasArticulosVendidosForm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxAnoFichaEstadisticasArticulosVendidos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMesFichaEstadisticasArticulosVendidos = new System.Windows.Forms.ComboBox();
            this.chartArticulosVendidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonCancelarFichaEstadisticasDiaMes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartArticulosVendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitleEstadisticasArticulosVendidosForm
            // 
            this.labelTitleEstadisticasArticulosVendidosForm.AutoSize = true;
            this.labelTitleEstadisticasArticulosVendidosForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleEstadisticasArticulosVendidosForm.Location = new System.Drawing.Point(9, 9);
            this.labelTitleEstadisticasArticulosVendidosForm.Name = "labelTitleEstadisticasArticulosVendidosForm";
            this.labelTitleEstadisticasArticulosVendidosForm.Size = new System.Drawing.Size(0, 46);
            this.labelTitleEstadisticasArticulosVendidosForm.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "Año";
            // 
            // comboBoxAnoFichaEstadisticasArticulosVendidos
            // 
            this.comboBoxAnoFichaEstadisticasArticulosVendidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnoFichaEstadisticasArticulosVendidos.FormattingEnabled = true;
            this.comboBoxAnoFichaEstadisticasArticulosVendidos.Location = new System.Drawing.Point(228, 92);
            this.comboBoxAnoFichaEstadisticasArticulosVendidos.Name = "comboBoxAnoFichaEstadisticasArticulosVendidos";
            this.comboBoxAnoFichaEstadisticasArticulosVendidos.Size = new System.Drawing.Size(109, 28);
            this.comboBoxAnoFichaEstadisticasArticulosVendidos.TabIndex = 47;
            this.comboBoxAnoFichaEstadisticasArticulosVendidos.SelectionChangeCommitted += new System.EventHandler(this.comboBoxAnoFichaEstadisticasArticulosVendidosForm_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Mes";
            // 
            // comboBoxMesFichaEstadisticasArticulosVendidos
            // 
            this.comboBoxMesFichaEstadisticasArticulosVendidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMesFichaEstadisticasArticulosVendidos.FormattingEnabled = true;
            this.comboBoxMesFichaEstadisticasArticulosVendidos.Location = new System.Drawing.Point(12, 92);
            this.comboBoxMesFichaEstadisticasArticulosVendidos.Name = "comboBoxMesFichaEstadisticasArticulosVendidos";
            this.comboBoxMesFichaEstadisticasArticulosVendidos.Size = new System.Drawing.Size(204, 28);
            this.comboBoxMesFichaEstadisticasArticulosVendidos.TabIndex = 45;
            this.comboBoxMesFichaEstadisticasArticulosVendidos.SelectionChangeCommitted += new System.EventHandler(this.comboBoxMesFichaEstadisticasArticulosVendidosForm_SelectionChangeCommitted);
            // 
            // chartArticulosVendidos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartArticulosVendidos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartArticulosVendidos.Legends.Add(legend1);
            this.chartArticulosVendidos.Location = new System.Drawing.Point(12, 142);
            this.chartArticulosVendidos.Name = "chartArticulosVendidos";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartArticulosVendidos.Series.Add(series1);
            this.chartArticulosVendidos.Size = new System.Drawing.Size(1099, 539);
            this.chartArticulosVendidos.TabIndex = 44;
            this.chartArticulosVendidos.Text = "chart1";
            // 
            // buttonCancelarFichaEstadisticasDiaMes
            // 
            this.buttonCancelarFichaEstadisticasDiaMes.Location = new System.Drawing.Point(921, 80);
            this.buttonCancelarFichaEstadisticasDiaMes.Name = "buttonCancelarFichaEstadisticasDiaMes";
            this.buttonCancelarFichaEstadisticasDiaMes.Size = new System.Drawing.Size(190, 40);
            this.buttonCancelarFichaEstadisticasDiaMes.TabIndex = 57;
            this.buttonCancelarFichaEstadisticasDiaMes.Text = "Cancelar";
            this.buttonCancelarFichaEstadisticasDiaMes.UseVisualStyleBackColor = true;
            this.buttonCancelarFichaEstadisticasDiaMes.Click += new System.EventHandler(this.buttonCancelarFichaEstadisticasDiaMesForm_Click);
            // 
            // FichaEstadisticasArticulosVendidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 693);
            this.Controls.Add(this.buttonCancelarFichaEstadisticasDiaMes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxAnoFichaEstadisticasArticulosVendidos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxMesFichaEstadisticasArticulosVendidos);
            this.Controls.Add(this.chartArticulosVendidos);
            this.Controls.Add(this.labelTitleEstadisticasArticulosVendidosForm);
            this.Name = "FichaEstadisticasArticulosVendidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artículos vendidos por tipo";
            this.Load += new System.EventHandler(this.FichaEstadisticasArticulosVendidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartArticulosVendidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleEstadisticasArticulosVendidosForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxAnoFichaEstadisticasArticulosVendidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMesFichaEstadisticasArticulosVendidos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartArticulosVendidos;
        private System.Windows.Forms.Button buttonCancelarFichaEstadisticasDiaMes;
    }
}