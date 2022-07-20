namespace DamCore.WinForms
{
    partial class frmImportadorPagoFacil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportadorPagoFacil));
            this.spcPrincipal = new System.Windows.Forms.SplitContainer();
            this.pbParametrosGenerales = new System.Windows.Forms.Button();
            this.pbSalir = new System.Windows.Forms.Button();
            this.pbAbout = new System.Windows.Forms.Button();
            this.pbEjecutarImportacion = new System.Windows.Forms.Button();
            this.pbLimpiar = new System.Windows.Forms.Button();
            this.pbBuscarArchivo = new System.Windows.Forms.Button();
            this.dfPathArchivo = new System.Windows.Forms.TextBox();
            this.lblPathArchivo = new System.Windows.Forms.Label();
            this.ttpInfo = new System.Windows.Forms.ToolTip(this.components);
            this.spcPrincipal.Panel1.SuspendLayout();
            this.spcPrincipal.Panel2.SuspendLayout();
            this.spcPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcPrincipal
            // 
            this.spcPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPrincipal.Location = new System.Drawing.Point(0, 0);
            this.spcPrincipal.Name = "spcPrincipal";
            this.spcPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcPrincipal.Panel1
            // 
            this.spcPrincipal.Panel1.Controls.Add(this.pbParametrosGenerales);
            this.spcPrincipal.Panel1.Controls.Add(this.pbSalir);
            this.spcPrincipal.Panel1.Controls.Add(this.pbAbout);
            this.spcPrincipal.Panel1.Controls.Add(this.pbEjecutarImportacion);
            this.spcPrincipal.Panel1.Controls.Add(this.pbLimpiar);
            // 
            // spcPrincipal.Panel2
            // 
            this.spcPrincipal.Panel2.Controls.Add(this.pbBuscarArchivo);
            this.spcPrincipal.Panel2.Controls.Add(this.dfPathArchivo);
            this.spcPrincipal.Panel2.Controls.Add(this.lblPathArchivo);
            this.spcPrincipal.Size = new System.Drawing.Size(504, 109);
            this.spcPrincipal.SplitterDistance = 40;
            this.spcPrincipal.TabIndex = 0;
            this.spcPrincipal.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.spcPrincipal_SplitterMoved);
            // 
            // pbParametrosGenerales
            // 
            this.pbParametrosGenerales.Image = ((System.Drawing.Image)(resources.GetObject("pbParametrosGenerales.Image")));
            this.pbParametrosGenerales.Location = new System.Drawing.Point(125, 3);
            this.pbParametrosGenerales.Name = "pbParametrosGenerales";
            this.pbParametrosGenerales.Size = new System.Drawing.Size(25, 26);
            this.pbParametrosGenerales.TabIndex = 4;
            this.pbParametrosGenerales.UseVisualStyleBackColor = true;
            this.pbParametrosGenerales.Click += new System.EventHandler(this.pbParametrosGenerales_Click);
            // 
            // pbSalir
            // 
            this.pbSalir.Image = ((System.Drawing.Image)(resources.GetObject("pbSalir.Image")));
            this.pbSalir.Location = new System.Drawing.Point(466, 3);
            this.pbSalir.Name = "pbSalir";
            this.pbSalir.Size = new System.Drawing.Size(25, 25);
            this.pbSalir.TabIndex = 6;
            this.pbSalir.UseVisualStyleBackColor = true;
            this.pbSalir.Click += new System.EventHandler(this.pbSalir_Click);
            // 
            // pbAbout
            // 
            this.pbAbout.Image = ((System.Drawing.Image)(resources.GetObject("pbAbout.Image")));
            this.pbAbout.Location = new System.Drawing.Point(441, 3);
            this.pbAbout.Name = "pbAbout";
            this.pbAbout.Size = new System.Drawing.Size(25, 25);
            this.pbAbout.TabIndex = 5;
            this.pbAbout.UseVisualStyleBackColor = true;
            this.pbAbout.Click += new System.EventHandler(this.pbAbout_Click);
            // 
            // pbEjecutarImportacion
            // 
            this.pbEjecutarImportacion.Image = ((System.Drawing.Image)(resources.GetObject("pbEjecutarImportacion.Image")));
            this.pbEjecutarImportacion.Location = new System.Drawing.Point(28, 3);
            this.pbEjecutarImportacion.Name = "pbEjecutarImportacion";
            this.pbEjecutarImportacion.Size = new System.Drawing.Size(25, 25);
            this.pbEjecutarImportacion.TabIndex = 3;
            this.pbEjecutarImportacion.UseVisualStyleBackColor = true;
            this.pbEjecutarImportacion.Click += new System.EventHandler(this.pbEjecutarImportacion_Click);
            // 
            // pbLimpiar
            // 
            this.pbLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("pbLimpiar.Image")));
            this.pbLimpiar.Location = new System.Drawing.Point(3, 3);
            this.pbLimpiar.Name = "pbLimpiar";
            this.pbLimpiar.Size = new System.Drawing.Size(25, 25);
            this.pbLimpiar.TabIndex = 2;
            this.pbLimpiar.UseVisualStyleBackColor = true;
            this.pbLimpiar.Click += new System.EventHandler(this.pbLimpiar_Click);
            // 
            // pbBuscarArchivo
            // 
            this.pbBuscarArchivo.Location = new System.Drawing.Point(441, 23);
            this.pbBuscarArchivo.Name = "pbBuscarArchivo";
            this.pbBuscarArchivo.Size = new System.Drawing.Size(25, 25);
            this.pbBuscarArchivo.TabIndex = 1;
            this.pbBuscarArchivo.Text = "...";
            this.pbBuscarArchivo.UseVisualStyleBackColor = true;
            this.pbBuscarArchivo.Click += new System.EventHandler(this.pbBuscarArchivo_Click);
            // 
            // dfPathArchivo
            // 
            this.dfPathArchivo.Location = new System.Drawing.Point(43, 26);
            this.dfPathArchivo.Name = "dfPathArchivo";
            this.dfPathArchivo.Size = new System.Drawing.Size(383, 20);
            this.dfPathArchivo.TabIndex = 0;
            // 
            // lblPathArchivo
            // 
            this.lblPathArchivo.AutoSize = true;
            this.lblPathArchivo.Location = new System.Drawing.Point(18, 7);
            this.lblPathArchivo.Name = "lblPathArchivo";
            this.lblPathArchivo.Size = new System.Drawing.Size(113, 13);
            this.lblPathArchivo.TabIndex = 23;
            this.lblPathArchivo.Text = "Ubicación del archivo:";
            // 
            // frmImportadorPagoFacil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 109);
            this.Controls.Add(this.spcPrincipal);
            this.Name = "frmImportadorPagoFacil";
            this.Text = "Importador de recibos PagoFacil";
            this.Load += new System.EventHandler(this.frmImportadorPagoFacil_Load);
            this.spcPrincipal.Panel1.ResumeLayout(false);
            this.spcPrincipal.Panel2.ResumeLayout(false);
            this.spcPrincipal.Panel2.PerformLayout();
            this.spcPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcPrincipal;
        private System.Windows.Forms.Button pbSalir;
        private System.Windows.Forms.Button pbAbout;
        private System.Windows.Forms.Button pbEjecutarImportacion;
        private System.Windows.Forms.Button pbLimpiar;
        private System.Windows.Forms.Button pbBuscarArchivo;
        private System.Windows.Forms.TextBox dfPathArchivo;
        private System.Windows.Forms.Label lblPathArchivo;
        private System.Windows.Forms.Button pbParametrosGenerales;
        private System.Windows.Forms.ToolTip ttpInfo;

    }
}