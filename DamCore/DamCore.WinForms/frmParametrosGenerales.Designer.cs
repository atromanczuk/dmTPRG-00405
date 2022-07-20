namespace DamCore.WinForms
{
    partial class frmParametrosGenerales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametrosGenerales));
            this.pnlParámetros = new System.Windows.Forms.Panel();
            this.pnlValores = new System.Windows.Forms.Panel();
            this.chkRequiereValidacion = new System.Windows.Forms.CheckBox();
            this.lblRequiereValidacion = new System.Windows.Forms.Label();
            this.cbEditable = new System.Windows.Forms.CheckBox();
            this.dfValor = new System.Windows.Forms.TextBox();
            this.lblValorDescripcion = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblEditable = new System.Windows.Forms.Label();
            this.lblValorNombre = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lbParametrosGenerales = new System.Windows.Forms.ListBox();
            this.pbLimpiar = new System.Windows.Forms.Button();
            this.pbModificar = new System.Windows.Forms.Button();
            this.pbDeshacer = new System.Windows.Forms.Button();
            this.pbGrabar = new System.Windows.Forms.Button();
            this.pbSalir = new System.Windows.Forms.Button();
            this.pbAbout = new System.Windows.Forms.Button();
            this.pnlParámetros.SuspendLayout();
            this.pnlValores.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlParámetros
            // 
            this.pnlParámetros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlParámetros.Controls.Add(this.pnlValores);
            this.pnlParámetros.Controls.Add(this.lbParametrosGenerales);
            this.pnlParámetros.Location = new System.Drawing.Point(12, 47);
            this.pnlParámetros.Name = "pnlParámetros";
            this.pnlParámetros.Size = new System.Drawing.Size(831, 281);
            this.pnlParámetros.TabIndex = 0;
            // 
            // pnlValores
            // 
            this.pnlValores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlValores.Controls.Add(this.chkRequiereValidacion);
            this.pnlValores.Controls.Add(this.lblRequiereValidacion);
            this.pnlValores.Controls.Add(this.cbEditable);
            this.pnlValores.Controls.Add(this.dfValor);
            this.pnlValores.Controls.Add(this.lblValorDescripcion);
            this.pnlValores.Controls.Add(this.lblDescripcion);
            this.pnlValores.Controls.Add(this.lblEditable);
            this.pnlValores.Controls.Add(this.lblValorNombre);
            this.pnlValores.Controls.Add(this.lblValor);
            this.pnlValores.Controls.Add(this.lblNombre);
            this.pnlValores.Location = new System.Drawing.Point(364, 19);
            this.pnlValores.Name = "pnlValores";
            this.pnlValores.Size = new System.Drawing.Size(449, 240);
            this.pnlValores.TabIndex = 1;
            // 
            // chkRequiereValidacion
            // 
            this.chkRequiereValidacion.AutoSize = true;
            this.chkRequiereValidacion.Enabled = false;
            this.chkRequiereValidacion.Location = new System.Drawing.Point(196, 211);
            this.chkRequiereValidacion.Name = "chkRequiereValidacion";
            this.chkRequiereValidacion.Size = new System.Drawing.Size(15, 14);
            this.chkRequiereValidacion.TabIndex = 22;
            this.chkRequiereValidacion.UseVisualStyleBackColor = true;
            this.chkRequiereValidacion.Visible = false;
            // 
            // lblRequiereValidacion
            // 
            this.lblRequiereValidacion.AutoSize = true;
            this.lblRequiereValidacion.Location = new System.Drawing.Point(139, 210);
            this.lblRequiereValidacion.Name = "lblRequiereValidacion";
            this.lblRequiereValidacion.Size = new System.Drawing.Size(59, 13);
            this.lblRequiereValidacion.TabIndex = 21;
            this.lblRequiereValidacion.Text = "Validacion:";
            this.lblRequiereValidacion.Visible = false;
            // 
            // cbEditable
            // 
            this.cbEditable.AutoSize = true;
            this.cbEditable.Enabled = false;
            this.cbEditable.Location = new System.Drawing.Point(80, 209);
            this.cbEditable.Name = "cbEditable";
            this.cbEditable.Size = new System.Drawing.Size(15, 14);
            this.cbEditable.TabIndex = 20;
            this.cbEditable.UseVisualStyleBackColor = true;
            this.cbEditable.Visible = false;
            // 
            // dfValor
            // 
            this.dfValor.Location = new System.Drawing.Point(76, 160);
            this.dfValor.Name = "dfValor";
            this.dfValor.Size = new System.Drawing.Size(326, 20);
            this.dfValor.TabIndex = 7;
            // 
            // lblValorDescripcion
            // 
            this.lblValorDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDescripcion.Location = new System.Drawing.Point(95, 64);
            this.lblValorDescripcion.Name = "lblValorDescripcion";
            this.lblValorDescripcion.Size = new System.Drawing.Size(309, 79);
            this.lblValorDescripcion.TabIndex = 18;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(23, 65);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 17;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblEditable
            // 
            this.lblEditable.AutoSize = true;
            this.lblEditable.Location = new System.Drawing.Point(23, 208);
            this.lblEditable.Name = "lblEditable";
            this.lblEditable.Size = new System.Drawing.Size(51, 13);
            this.lblEditable.TabIndex = 10;
            this.lblEditable.Text = "Editable?";
            this.lblEditable.Visible = false;
            // 
            // lblValorNombre
            // 
            this.lblValorNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorNombre.Location = new System.Drawing.Point(76, 32);
            this.lblValorNombre.Name = "lblValorNombre";
            this.lblValorNombre.Size = new System.Drawing.Size(328, 24);
            this.lblValorNombre.TabIndex = 9;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(23, 163);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 1;
            this.lblValor.Text = "Valor:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(23, 33);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lbParametrosGenerales
            // 
            this.lbParametrosGenerales.FormattingEnabled = true;
            this.lbParametrosGenerales.Location = new System.Drawing.Point(21, 19);
            this.lbParametrosGenerales.Name = "lbParametrosGenerales";
            this.lbParametrosGenerales.Size = new System.Drawing.Size(315, 238);
            this.lbParametrosGenerales.TabIndex = 6;
            this.lbParametrosGenerales.Click += new System.EventHandler(this.lbParametrosGenerales_Click);
            this.lbParametrosGenerales.SelectedIndexChanged += new System.EventHandler(this.lbParametrosGenerales_SelectedIndexChanged);
            this.lbParametrosGenerales.DoubleClick += new System.EventHandler(this.lbParametrosGenerales_DoubleClick);
            // 
            // pbLimpiar
            // 
            this.pbLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("pbLimpiar.Image")));
            this.pbLimpiar.Location = new System.Drawing.Point(12, 11);
            this.pbLimpiar.Name = "pbLimpiar";
            this.pbLimpiar.Size = new System.Drawing.Size(26, 24);
            this.pbLimpiar.TabIndex = 0;
            this.pbLimpiar.UseVisualStyleBackColor = true;
            this.pbLimpiar.Click += new System.EventHandler(this.pbLimpiar_Click);
            // 
            // pbModificar
            // 
            this.pbModificar.Image = ((System.Drawing.Image)(resources.GetObject("pbModificar.Image")));
            this.pbModificar.Location = new System.Drawing.Point(37, 11);
            this.pbModificar.Name = "pbModificar";
            this.pbModificar.Size = new System.Drawing.Size(26, 24);
            this.pbModificar.TabIndex = 1;
            this.pbModificar.UseVisualStyleBackColor = true;
            this.pbModificar.Click += new System.EventHandler(this.pbModificar_Click);
            // 
            // pbDeshacer
            // 
            this.pbDeshacer.Image = ((System.Drawing.Image)(resources.GetObject("pbDeshacer.Image")));
            this.pbDeshacer.Location = new System.Drawing.Point(62, 11);
            this.pbDeshacer.Name = "pbDeshacer";
            this.pbDeshacer.Size = new System.Drawing.Size(26, 24);
            this.pbDeshacer.TabIndex = 2;
            this.pbDeshacer.UseVisualStyleBackColor = true;
            this.pbDeshacer.Click += new System.EventHandler(this.pbDeshacer_Click);
            // 
            // pbGrabar
            // 
            this.pbGrabar.Image = ((System.Drawing.Image)(resources.GetObject("pbGrabar.Image")));
            this.pbGrabar.Location = new System.Drawing.Point(87, 11);
            this.pbGrabar.Name = "pbGrabar";
            this.pbGrabar.Size = new System.Drawing.Size(26, 24);
            this.pbGrabar.TabIndex = 3;
            this.pbGrabar.UseVisualStyleBackColor = true;
            this.pbGrabar.Click += new System.EventHandler(this.pbGrabar_Click);
            // 
            // pbSalir
            // 
            this.pbSalir.Image = ((System.Drawing.Image)(resources.GetObject("pbSalir.Image")));
            this.pbSalir.Location = new System.Drawing.Point(817, 11);
            this.pbSalir.Name = "pbSalir";
            this.pbSalir.Size = new System.Drawing.Size(26, 24);
            this.pbSalir.TabIndex = 5;
            this.pbSalir.UseVisualStyleBackColor = true;
            this.pbSalir.Click += new System.EventHandler(this.pbSalir_Click);
            // 
            // pbAbout
            // 
            this.pbAbout.Image = ((System.Drawing.Image)(resources.GetObject("pbAbout.Image")));
            this.pbAbout.Location = new System.Drawing.Point(792, 11);
            this.pbAbout.Name = "pbAbout";
            this.pbAbout.Size = new System.Drawing.Size(26, 24);
            this.pbAbout.TabIndex = 4;
            this.pbAbout.UseVisualStyleBackColor = true;
            this.pbAbout.Click += new System.EventHandler(this.pbAbout_Click);
            // 
            // frmParametrosGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 342);
            this.ControlBox = false;
            this.Controls.Add(this.pbSalir);
            this.Controls.Add(this.pbAbout);
            this.Controls.Add(this.pbGrabar);
            this.Controls.Add(this.pbDeshacer);
            this.Controls.Add(this.pbModificar);
            this.Controls.Add(this.pbLimpiar);
            this.Controls.Add(this.pnlParámetros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmParametrosGenerales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parámetros generales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmParametrosGenerales_FormClosing);
            this.Load += new System.EventHandler(this.frmParametrosGenerales_Load);
            this.pnlParámetros.ResumeLayout(false);
            this.pnlValores.ResumeLayout(false);
            this.pnlValores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlParámetros;
        private System.Windows.Forms.Button pbLimpiar;
        private System.Windows.Forms.Button pbModificar;
        private System.Windows.Forms.Button pbDeshacer;
        private System.Windows.Forms.Button pbGrabar;
        private System.Windows.Forms.Button pbSalir;
        private System.Windows.Forms.Button pbAbout;
        private System.Windows.Forms.Panel pnlValores;
        private System.Windows.Forms.ListBox lbParametrosGenerales;
        private System.Windows.Forms.CheckBox cbEditable;
        private System.Windows.Forms.TextBox dfValor;
        private System.Windows.Forms.Label lblValorDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblEditable;
        private System.Windows.Forms.Label lblValorNombre;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.CheckBox chkRequiereValidacion;
        private System.Windows.Forms.Label lblRequiereValidacion;
    }
}