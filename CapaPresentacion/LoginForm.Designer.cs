namespace CapaPresentacion
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTitleLogin = new System.Windows.Forms.Label();
            this.textBoxLoginLogin = new System.Windows.Forms.TextBox();
            this.textBoxPasswordLogin = new System.Windows.Forms.TextBox();
            this.buttonLoginLogin = new System.Windows.Forms.Button();
            this.buttonResetLogin = new System.Windows.Forms.Button();
            this.IconBarraTareas = new System.Windows.Forms.NotifyIcon(this.components);
            this.BarraTareas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BarraTareasMostrar = new System.Windows.Forms.ToolStripMenuItem();
            this.BarraTareasOcultar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BarraTareas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CapaPresentacion.Properties.Resources.password;
            this.pictureBox3.Location = new System.Drawing.Point(70, 254);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 63);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.login;
            this.pictureBox2.Location = new System.Drawing.Point(70, 152);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 63);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.loginkey;
            this.pictureBox1.Location = new System.Drawing.Point(24, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelTitleLogin
            // 
            this.labelTitleLogin.AutoSize = true;
            this.labelTitleLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleLogin.Location = new System.Drawing.Point(164, 55);
            this.labelTitleLogin.Name = "labelTitleLogin";
            this.labelTitleLogin.Size = new System.Drawing.Size(355, 46);
            this.labelTitleLogin.TabIndex = 3;
            this.labelTitleLogin.Text = "Admin Panel Login";
            // 
            // textBoxLoginLogin
            // 
            this.textBoxLoginLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLoginLogin.Location = new System.Drawing.Point(171, 152);
            this.textBoxLoginLogin.Multiline = true;
            this.textBoxLoginLogin.Name = "textBoxLoginLogin";
            this.textBoxLoginLogin.Size = new System.Drawing.Size(289, 61);
            this.textBoxLoginLogin.TabIndex = 0;
            // 
            // textBoxPasswordLogin
            // 
            this.textBoxPasswordLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswordLogin.Location = new System.Drawing.Point(171, 254);
            this.textBoxPasswordLogin.Multiline = true;
            this.textBoxPasswordLogin.Name = "textBoxPasswordLogin";
            this.textBoxPasswordLogin.PasswordChar = '*';
            this.textBoxPasswordLogin.Size = new System.Drawing.Size(289, 61);
            this.textBoxPasswordLogin.TabIndex = 1;
            this.textBoxPasswordLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPasswordLogin_KeyDown);
            // 
            // buttonLoginLogin
            // 
            this.buttonLoginLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoginLogin.Location = new System.Drawing.Point(84, 357);
            this.buttonLoginLogin.Name = "buttonLoginLogin";
            this.buttonLoginLogin.Size = new System.Drawing.Size(168, 57);
            this.buttonLoginLogin.TabIndex = 2;
            this.buttonLoginLogin.Text = "Login";
            this.buttonLoginLogin.UseVisualStyleBackColor = true;
            this.buttonLoginLogin.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonResetLogin
            // 
            this.buttonResetLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetLogin.Location = new System.Drawing.Point(279, 357);
            this.buttonResetLogin.Name = "buttonResetLogin";
            this.buttonResetLogin.Size = new System.Drawing.Size(168, 57);
            this.buttonResetLogin.TabIndex = 3;
            this.buttonResetLogin.Text = "Reset";
            this.buttonResetLogin.UseVisualStyleBackColor = true;
            this.buttonResetLogin.Click += new System.EventHandler(this.Button2_Click);
            // 
            // IconBarraTareas
            // 
            this.IconBarraTareas.ContextMenuStrip = this.BarraTareas;
            this.IconBarraTareas.Icon = ((System.Drawing.Icon)(resources.GetObject("IconBarraTareas.Icon")));
            this.IconBarraTareas.Text = "App";
            this.IconBarraTareas.Visible = true;
            // 
            // BarraTareas
            // 
            this.BarraTareas.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.BarraTareas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BarraTareasMostrar,
            this.BarraTareasOcultar});
            this.BarraTareas.Name = "BarraTareas";
            this.BarraTareas.Size = new System.Drawing.Size(147, 64);
            // 
            // BarraTareasMostrar
            // 
            this.BarraTareasMostrar.Name = "BarraTareasMostrar";
            this.BarraTareasMostrar.Size = new System.Drawing.Size(146, 30);
            this.BarraTareasMostrar.Text = "Mostrar";
            this.BarraTareasMostrar.Click += new System.EventHandler(this.BarraTareasMostrar_Click);
            // 
            // BarraTareasOcultar
            // 
            this.BarraTareasOcultar.Name = "BarraTareasOcultar";
            this.BarraTareasOcultar.Size = new System.Drawing.Size(146, 30);
            this.BarraTareasOcultar.Text = "Ocultar";
            this.BarraTareasOcultar.Click += new System.EventHandler(this.BarraTareasOcultar_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 442);
            this.Controls.Add(this.buttonResetLogin);
            this.Controls.Add(this.buttonLoginLogin);
            this.Controls.Add(this.textBoxPasswordLogin);
            this.Controls.Add(this.textBoxLoginLogin);
            this.Controls.Add(this.labelTitleLogin);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TiendaDAM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BarraTareas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelTitleLogin;
        private System.Windows.Forms.TextBox textBoxPasswordLogin;
        private System.Windows.Forms.Button buttonLoginLogin;
        private System.Windows.Forms.Button buttonResetLogin;
        private System.Windows.Forms.NotifyIcon IconBarraTareas;
        private System.Windows.Forms.ContextMenuStrip BarraTareas;
        private System.Windows.Forms.ToolStripMenuItem BarraTareasMostrar;
        private System.Windows.Forms.ToolStripMenuItem BarraTareasOcultar;
        public System.Windows.Forms.TextBox textBoxLoginLogin;
    }
}