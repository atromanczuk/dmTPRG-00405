namespace DamCore.WinForms
{
    partial class frmImpresionCredenciales
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
            this.dfValor = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dfValor
            // 
            this.dfValor.Location = new System.Drawing.Point(49, 120);
            this.dfValor.Name = "dfValor";
            this.dfValor.Size = new System.Drawing.Size(78, 20);
            this.dfValor.TabIndex = 0;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Enabled = false;
            this.lblDescripcion.Location = new System.Drawing.Point(145, 120);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(201, 20);
            this.lblDescripcion.TabIndex = 1;
            // 
            // frmImpresionCredenciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 418);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.dfValor);
            this.Name = "frmImpresionCredenciales";
            this.Text = "frmImpresionCredenciales";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dfValor;
        private System.Windows.Forms.TextBox lblDescripcion;
    }
}