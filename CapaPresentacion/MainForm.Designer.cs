namespace Capa_presentacion
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaYModificaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.estadísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosDelMesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artículosVendidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelNombreLoginMain = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTiempoLoginMain = new System.Windows.Forms.Label();
            this.labelMensajeErrorMain = new System.Windows.Forms.Label();
            this.labelHoraSistemaMain = new System.Windows.Forms.Label();
            this.timerSegundo = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.pedidosToolStripMenuItem,
            this.estadísticasToolStripMenuItem,
            this.informesToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStripMain.Size = new System.Drawing.Size(1131, 35);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(84, 29);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(129, 30);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // insertarToolStripMenuItem
            // 
            this.insertarToolStripMenuItem.Name = "insertarToolStripMenuItem";
            this.insertarToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.insertarToolStripMenuItem.Text = "Insertar";
            this.insertarToolStripMenuItem.Click += new System.EventHandler(this.insertarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem,
            this.modificarToolStripMenuItem1});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(171, 30);
            this.consultarToolStripMenuItem.Text = "Consultar";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem1
            // 
            this.modificarToolStripMenuItem1.Name = "modificarToolStripMenuItem1";
            this.modificarToolStripMenuItem1.Size = new System.Drawing.Size(171, 30);
            this.modificarToolStripMenuItem1.Text = "Modificar";
            this.modificarToolStripMenuItem1.Click += new System.EventHandler(this.modificarToolStripMenuItem1_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.consultaYModificaciónToolStripMenuItem,
            this.eliminarToolStripMenuItem1});
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(87, 29);
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // consultaYModificaciónToolStripMenuItem
            // 
            this.consultaYModificaciónToolStripMenuItem.Name = "consultaYModificaciónToolStripMenuItem";
            this.consultaYModificaciónToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.consultaYModificaciónToolStripMenuItem.Text = "Consulta y modificación";
            this.consultaYModificaciónToolStripMenuItem.Click += new System.EventHandler(this.consultaYModificaciónToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem1
            // 
            this.eliminarToolStripMenuItem1.Name = "eliminarToolStripMenuItem1";
            this.eliminarToolStripMenuItem1.Size = new System.Drawing.Size(286, 30);
            this.eliminarToolStripMenuItem1.Text = "Eliminar";
            this.eliminarToolStripMenuItem1.Click += new System.EventHandler(this.eliminarToolStripMenuItem1_Click);
            // 
            // estadísticasToolStripMenuItem
            // 
            this.estadísticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pedidosDelMesToolStripMenuItem,
            this.artículosVendidosToolStripMenuItem});
            this.estadísticasToolStripMenuItem.Name = "estadísticasToolStripMenuItem";
            this.estadísticasToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.estadísticasToolStripMenuItem.Text = "Estadísticas";
            // 
            // pedidosDelMesToolStripMenuItem
            // 
            this.pedidosDelMesToolStripMenuItem.Name = "pedidosDelMesToolStripMenuItem";
            this.pedidosDelMesToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.pedidosDelMesToolStripMenuItem.Text = "Pedidos del mes";
            this.pedidosDelMesToolStripMenuItem.Click += new System.EventHandler(this.pedidosDelMesToolStripMenuItem_Click);
            // 
            // artículosVendidosToolStripMenuItem
            // 
            this.artículosVendidosToolStripMenuItem.Name = "artículosVendidosToolStripMenuItem";
            this.artículosVendidosToolStripMenuItem.Size = new System.Drawing.Size(243, 30);
            this.artículosVendidosToolStripMenuItem.Text = "Artículos vendidos";
            this.artículosVendidosToolStripMenuItem.Click += new System.EventHandler(this.artículosVendidosToolStripMenuItem_Click);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturaToolStripMenuItem,
            this.stockToolStripMenuItem});
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(95, 29);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // facturaToolStripMenuItem
            // 
            this.facturaToolStripMenuItem.Name = "facturaToolStripMenuItem";
            this.facturaToolStripMenuItem.Size = new System.Drawing.Size(214, 30);
            this.facturaToolStripMenuItem.Text = "Factura";
            this.facturaToolStripMenuItem.Click += new System.EventHandler(this.facturaToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(214, 30);
            this.stockToolStripMenuItem.Text = "Stock reducido";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem1});
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(113, 29);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            // 
            // acercaDeToolStripMenuItem1
            // 
            this.acercaDeToolStripMenuItem1.Name = "acercaDeToolStripMenuItem1";
            this.acercaDeToolStripMenuItem1.Size = new System.Drawing.Size(185, 30);
            this.acercaDeToolStripMenuItem1.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem1.Click += new System.EventHandler(this.acercaDeToolStripMenuItem1_Click);
            // 
            // labelNombreLoginMain
            // 
            this.labelNombreLoginMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreLoginMain.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelNombreLoginMain.Location = new System.Drawing.Point(724, 0);
            this.labelNombreLoginMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombreLoginMain.Name = "labelNombreLoginMain";
            this.labelNombreLoginMain.Size = new System.Drawing.Size(273, 37);
            this.labelNombreLoginMain.TabIndex = 6;
            this.labelNombreLoginMain.Text = "NombreLogin";
            this.labelNombreLoginMain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTiempoLoginMain);
            this.panel1.Controls.Add(this.labelMensajeErrorMain);
            this.panel1.Controls.Add(this.labelHoraSistemaMain);
            this.panel1.Location = new System.Drawing.Point(0, 774);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 125);
            this.panel1.TabIndex = 8;
            // 
            // labelTiempoLoginMain
            // 
            this.labelTiempoLoginMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTiempoLoginMain.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelTiempoLoginMain.Location = new System.Drawing.Point(630, 69);
            this.labelTiempoLoginMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTiempoLoginMain.Name = "labelTiempoLoginMain";
            this.labelTiempoLoginMain.Size = new System.Drawing.Size(483, 37);
            this.labelTiempoLoginMain.TabIndex = 12;
            this.labelTiempoLoginMain.Text = "TiempoFuncionamiento";
            this.labelTiempoLoginMain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMensajeErrorMain
            // 
            this.labelMensajeErrorMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensajeErrorMain.ForeColor = System.Drawing.Color.Green;
            this.labelMensajeErrorMain.Location = new System.Drawing.Point(13, 24);
            this.labelMensajeErrorMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMensajeErrorMain.Name = "labelMensajeErrorMain";
            this.labelMensajeErrorMain.Size = new System.Drawing.Size(663, 82);
            this.labelMensajeErrorMain.TabIndex = 11;
            this.labelMensajeErrorMain.Text = "Estado: Correcto";
            // 
            // labelHoraSistemaMain
            // 
            this.labelHoraSistemaMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHoraSistemaMain.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelHoraSistemaMain.Location = new System.Drawing.Point(668, 22);
            this.labelHoraSistemaMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHoraSistemaMain.Name = "labelHoraSistemaMain";
            this.labelHoraSistemaMain.Size = new System.Drawing.Size(452, 37);
            this.labelHoraSistemaMain.TabIndex = 9;
            this.labelHoraSistemaMain.Text = "HoraSistema";
            this.labelHoraSistemaMain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerSegundo
            // 
            this.timerSegundo.Tick += new System.EventHandler(this.TimerSegundo_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(1005, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cerrar sesión";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1131, 902);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelNombreLoginMain);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TiendaDAM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaYModificaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem estadísticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelHoraSistemaMain;
        private System.Windows.Forms.Label labelTiempoLoginMain;
        private System.Windows.Forms.Timer timerSegundo;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label labelNombreLoginMain;
        public System.Windows.Forms.Label labelMensajeErrorMain;
        private System.Windows.Forms.ToolStripMenuItem pedidosDelMesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artículosVendidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem1;
    }
}

