using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DamCore.Common;


namespace DamCore.WinForms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();

            lblTipoConexion.Text = DatosConexion.getInstance().getTipoConexion();
            lblBase.Text = DatosConexion.getInstance().getDaseDatosOleDb();
            lblDSN.Text = DatosConexion.getInstance().getDSN();
            lblUsuarioPF.Text = "";//DatosConexion.getInstance().getUsuarioDb();

            this.lblDescSistema.Text = Application.ProductName;
            lblDescVersion.Text = Application.ProductVersion;
            lblPC.Text = Environment.MachineName;
            lblUsuarioWin.Text = Environment.UserName;
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
