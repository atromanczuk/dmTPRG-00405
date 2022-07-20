namespace DamCore.WinForms
{
    partial class frmAyuda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAyuda));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbAbout = new System.Windows.Forms.Button();
            this.pbCerrar = new System.Windows.Forms.Button();
            this.pbEjecutar = new System.Windows.Forms.Button();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.dfFiltro = new System.Windows.Forms.TextBox();
            this.grdAyuda = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAyuda)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbAbout);
            this.splitContainer1.Panel1.Controls.Add(this.pbCerrar);
            this.splitContainer1.Panel1.Controls.Add(this.pbEjecutar);
            this.splitContainer1.Panel1.Controls.Add(this.lblFiltros);
            this.splitContainer1.Panel1.Controls.Add(this.dfFiltro);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdAyuda);
            this.splitContainer1.Size = new System.Drawing.Size(487, 383);
            this.splitContainer1.SplitterDistance = 65;
            this.splitContainer1.TabIndex = 9;
            // 
            // pbAbout
            // 
            this.pbAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAbout.Image = ((System.Drawing.Image)(resources.GetObject("pbAbout.Image")));
            this.pbAbout.Location = new System.Drawing.Point(426, 12);
            this.pbAbout.Name = "pbAbout";
            this.pbAbout.Size = new System.Drawing.Size(25, 25);
            this.pbAbout.TabIndex = 13;
            this.pbAbout.UseVisualStyleBackColor = true;
            this.pbAbout.Click += new System.EventHandler(this.pbAbout_Click);
            // 
            // pbCerrar
            // 
            this.pbCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pbCerrar.Image")));
            this.pbCerrar.Location = new System.Drawing.Point(450, 12);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(25, 25);
            this.pbCerrar.TabIndex = 12;
            this.pbCerrar.UseVisualStyleBackColor = true;
            this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click);
            // 
            // pbEjecutar
            // 
            this.pbEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("pbEjecutar.Image")));
            this.pbEjecutar.Location = new System.Drawing.Point(243, 28);
            this.pbEjecutar.Name = "pbEjecutar";
            this.pbEjecutar.Size = new System.Drawing.Size(25, 25);
            this.pbEjecutar.TabIndex = 11;
            this.pbEjecutar.UseVisualStyleBackColor = true;
            this.pbEjecutar.Click += new System.EventHandler(this.pbEjecutar_Click);
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Location = new System.Drawing.Point(14, 34);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(32, 13);
            this.lblFiltros.TabIndex = 10;
            this.lblFiltros.Text = "Filtro:";
            // 
            // dfFiltro
            // 
            this.dfFiltro.Location = new System.Drawing.Point(52, 31);
            this.dfFiltro.Name = "dfFiltro";
            this.dfFiltro.Size = new System.Drawing.Size(185, 20);
            this.dfFiltro.TabIndex = 9;
            // 
            // grdAyuda
            // 
            this.grdAyuda.AllowUserToAddRows = false;
            this.grdAyuda.AllowUserToDeleteRows = false;
            this.grdAyuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAyuda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colDescripcion});
            this.grdAyuda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAyuda.Location = new System.Drawing.Point(0, 0);
            this.grdAyuda.Name = "grdAyuda";
            this.grdAyuda.ReadOnly = true;
            this.grdAyuda.RowHeadersWidth = 10;
            this.grdAyuda.Size = new System.Drawing.Size(487, 314);
            this.grdAyuda.TabIndex = 1;
            this.grdAyuda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAyuda_CellClick);
            this.grdAyuda.DoubleClick += new System.EventHandler(this.grdAyuda_DoubleClick);
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 150;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 325;
            // 
            // frmAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 383);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAyuda";
            this.Text = "frmAyuda";
            this.Load += new System.EventHandler(this.frmAyuda_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAyuda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grdAyuda;
        private System.Windows.Forms.Button pbAbout;
        private System.Windows.Forms.Button pbCerrar;
        private System.Windows.Forms.Button pbEjecutar;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.TextBox dfFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;


    }
}