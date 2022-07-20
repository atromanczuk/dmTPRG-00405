namespace DamCore.WinForms
{
    partial class frmValidacionDatosUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidacionDatosUsuario));
            this.pbValidarOf = new System.Windows.Forms.Button();
            this.pbSalir = new System.Windows.Forms.Button();
            this.pbAbout = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.dfContraseña = new System.Windows.Forms.TextBox();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.dfUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbValidarOf
            // 
            this.pbValidarOf.Image = ((System.Drawing.Image)(resources.GetObject("pbValidarOf.Image")));
            this.pbValidarOf.Location = new System.Drawing.Point(12, 12);
            this.pbValidarOf.Name = "pbValidarOf";
            this.pbValidarOf.Size = new System.Drawing.Size(25, 25);
            this.pbValidarOf.TabIndex = 2;
            this.pbValidarOf.UseVisualStyleBackColor = true;
            this.pbValidarOf.Click += new System.EventHandler(this.pbValidarOf_Click);
            // 
            // pbSalir
            // 
            this.pbSalir.Image = ((System.Drawing.Image)(resources.GetObject("pbSalir.Image")));
            this.pbSalir.Location = new System.Drawing.Point(399, 13);
            this.pbSalir.Name = "pbSalir";
            this.pbSalir.Size = new System.Drawing.Size(26, 24);
            this.pbSalir.TabIndex = 4;
            this.pbSalir.UseVisualStyleBackColor = true;
            this.pbSalir.Click += new System.EventHandler(this.pbSalir_Click);
            // 
            // pbAbout
            // 
            this.pbAbout.Image = ((System.Drawing.Image)(resources.GetObject("pbAbout.Image")));
            this.pbAbout.Location = new System.Drawing.Point(373, 13);
            this.pbAbout.Name = "pbAbout";
            this.pbAbout.Size = new System.Drawing.Size(26, 24);
            this.pbAbout.TabIndex = 3;
            this.pbAbout.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(33, 105);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 13);
            this.lblPassword.TabIndex = 27;
            this.lblPassword.Text = "Contraseña:";
            // 
            // dfContraseña
            // 
            this.dfContraseña.Location = new System.Drawing.Point(103, 102);
            this.dfContraseña.Name = "dfContraseña";
            this.dfContraseña.PasswordChar = '*';
            this.dfContraseña.Size = new System.Drawing.Size(296, 20);
            this.dfContraseña.TabIndex = 1;
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.Location = new System.Drawing.Point(33, 40);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(350, 31);
            this.lblLeyenda.TabIndex = 29;
            this.lblLeyenda.Text = "label1";
            // 
            // dfUsuario
            // 
            this.dfUsuario.Location = new System.Drawing.Point(103, 74);
            this.dfUsuario.Name = "dfUsuario";
            this.dfUsuario.Size = new System.Drawing.Size(296, 20);
            this.dfUsuario.TabIndex = 0;
            this.dfUsuario.Leave += new System.EventHandler(this.dfUsuario_Leave);
            this.dfUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.dfUsuario_Validating);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(33, 77);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 30;
            this.lblUsuario.Text = "Usuario:";
            // 
            // frmValidacionDatosUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 132);
            this.ControlBox = false;
            this.Controls.Add(this.dfUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.dfContraseña);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.pbSalir);
            this.Controls.Add(this.pbAbout);
            this.Controls.Add(this.pbValidarOf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmValidacionDatosUsuario";
            this.Text = "Control de edición-Contraseña";
            this.Load += new System.EventHandler(this.frmValidacionDatosUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pbValidarOf;
        private System.Windows.Forms.Button pbSalir;
        private System.Windows.Forms.Button pbAbout;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox dfContraseña;
        private System.Windows.Forms.Label lblLeyenda;
        private System.Windows.Forms.TextBox dfUsuario;
        private System.Windows.Forms.Label lblUsuario;
    }
}