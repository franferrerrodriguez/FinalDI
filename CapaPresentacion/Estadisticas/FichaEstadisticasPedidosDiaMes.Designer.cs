namespace CapaPresentacion.Estadisticas
{
    partial class FichaEstadisticasPedidosDiaMes
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
            this.chartNumeroPedidosMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxMesFichaEstadisticasNumeroPedidosMes = new System.Windows.Forms.ComboBox();
            this.labelTitleFichaEstadisticasDiaMesForm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxAnoFichaEstadisticasNumeroPedidosMes = new System.Windows.Forms.ComboBox();
            this.buttonCancelarFichaEstadisticasNumeroPedidosMes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartNumeroPedidosMes)).BeginInit();
            this.SuspendLayout();
            // 
            // chartNumeroPedidosMes
            // 
            chartArea1.Name = "ChartArea1";
            this.chartNumeroPedidosMes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartNumeroPedidosMes.Legends.Add(legend1);
            this.chartNumeroPedidosMes.Location = new System.Drawing.Point(12, 142);
            this.chartNumeroPedidosMes.Name = "chartNumeroPedidosMes";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.LegendText = "Pedidos";
            series1.Name = "Series1";
            this.chartNumeroPedidosMes.Series.Add(series1);
            this.chartNumeroPedidosMes.Size = new System.Drawing.Size(1099, 539);
            this.chartNumeroPedidosMes.TabIndex = 0;
            this.chartNumeroPedidosMes.Text = "chartNumeroPedidos";
            // 
            // comboBoxMesFichaEstadisticasNumeroPedidosMes
            // 
            this.comboBoxMesFichaEstadisticasNumeroPedidosMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMesFichaEstadisticasNumeroPedidosMes.FormattingEnabled = true;
            this.comboBoxMesFichaEstadisticasNumeroPedidosMes.Location = new System.Drawing.Point(12, 92);
            this.comboBoxMesFichaEstadisticasNumeroPedidosMes.Name = "comboBoxMesFichaEstadisticasNumeroPedidosMes";
            this.comboBoxMesFichaEstadisticasNumeroPedidosMes.Size = new System.Drawing.Size(204, 28);
            this.comboBoxMesFichaEstadisticasNumeroPedidosMes.TabIndex = 1;
            this.comboBoxMesFichaEstadisticasNumeroPedidosMes.SelectionChangeCommitted += new System.EventHandler(this.comboBoxMesFichaEstadisticasDiaMesForm_SelectionChangeCommitted);
            // 
            // labelTitleFichaEstadisticasDiaMesForm
            // 
            this.labelTitleFichaEstadisticasDiaMesForm.AutoSize = true;
            this.labelTitleFichaEstadisticasDiaMesForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleFichaEstadisticasDiaMesForm.Location = new System.Drawing.Point(9, 9);
            this.labelTitleFichaEstadisticasDiaMesForm.Name = "labelTitleFichaEstadisticasDiaMesForm";
            this.labelTitleFichaEstadisticasDiaMesForm.Size = new System.Drawing.Size(0, 46);
            this.labelTitleFichaEstadisticasDiaMesForm.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Año";
            // 
            // comboBoxAnoFichaEstadisticasNumeroPedidosMes
            // 
            this.comboBoxAnoFichaEstadisticasNumeroPedidosMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnoFichaEstadisticasNumeroPedidosMes.FormattingEnabled = true;
            this.comboBoxAnoFichaEstadisticasNumeroPedidosMes.Location = new System.Drawing.Point(228, 92);
            this.comboBoxAnoFichaEstadisticasNumeroPedidosMes.Name = "comboBoxAnoFichaEstadisticasNumeroPedidosMes";
            this.comboBoxAnoFichaEstadisticasNumeroPedidosMes.Size = new System.Drawing.Size(109, 28);
            this.comboBoxAnoFichaEstadisticasNumeroPedidosMes.TabIndex = 42;
            this.comboBoxAnoFichaEstadisticasNumeroPedidosMes.SelectionChangeCommitted += new System.EventHandler(this.comboBoxAnoFichaEstadisticasDiaMesForm_SelectionChangeCommitted);
            // 
            // buttonCancelarFichaEstadisticasNumeroPedidosMes
            // 
            this.buttonCancelarFichaEstadisticasNumeroPedidosMes.Location = new System.Drawing.Point(921, 80);
            this.buttonCancelarFichaEstadisticasNumeroPedidosMes.Name = "buttonCancelarFichaEstadisticasNumeroPedidosMes";
            this.buttonCancelarFichaEstadisticasNumeroPedidosMes.Size = new System.Drawing.Size(190, 40);
            this.buttonCancelarFichaEstadisticasNumeroPedidosMes.TabIndex = 58;
            this.buttonCancelarFichaEstadisticasNumeroPedidosMes.Text = "Cancelar";
            this.buttonCancelarFichaEstadisticasNumeroPedidosMes.UseVisualStyleBackColor = true;
            this.buttonCancelarFichaEstadisticasNumeroPedidosMes.Click += new System.EventHandler(this.buttonCancelarFichaEstadisticasDiaMesForm_Click);
            // 
            // FichaEstadisticasPedidosDiaMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 693);
            this.Controls.Add(this.buttonCancelarFichaEstadisticasNumeroPedidosMes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxAnoFichaEstadisticasNumeroPedidosMes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitleFichaEstadisticasDiaMesForm);
            this.Controls.Add(this.comboBoxMesFichaEstadisticasNumeroPedidosMes);
            this.Controls.Add(this.chartNumeroPedidosMes);
            this.Name = "FichaEstadisticasPedidosDiaMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedidos por día del mes";
            this.Load += new System.EventHandler(this.FichaEstadisticasPedidosMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartNumeroPedidosMes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartNumeroPedidosMes;
        private System.Windows.Forms.ComboBox comboBoxMesFichaEstadisticasNumeroPedidosMes;
        private System.Windows.Forms.Label labelTitleFichaEstadisticasDiaMesForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxAnoFichaEstadisticasNumeroPedidosMes;
        private System.Windows.Forms.Button buttonCancelarFichaEstadisticasNumeroPedidosMes;
    }
}