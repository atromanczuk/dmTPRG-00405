using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DamCore.Common;
using DamCore.Business;
using DamCore.DamExceptions;



namespace DamCore.WinForms
{

    public partial class frmAyuda : Form
    {

        //Int32 BusquedaPor;
        TipoAyuda BusquedaPor;
        private Int32 filaSeleccionada;
        private Int32 ColumnaSeleccionada;

        public frmAyuda(TipoAyuda busqueda)
        {
            InitializeComponent();

            BusquedaPor = busqueda;// Convert.ToInt32(busqueda);

            this.Text = "Ayuda de " + busqueda.ToString();

        }

        private void frmAyuda_Load(object sender, EventArgs e)
        {

            CargoListaAyuda();
          

        }

        private void pbEjecutar_Click(object sender, EventArgs e)
        {
            CargoListaAyuda();
        }




        private void CargoListaAyuda()
        { 
         try
            {
                this.grdAyuda.Rows.Clear();

                List<Ayuda> registrosEncontrados = new List<Ayuda>();
                //segun el valor de enumeracion leido, se detecta el tipo de ayuda a ofrecer

                BusinessAyuda ayudaModulo = new BusinessAyuda(BusquedaPor);

                registrosEncontrados = ayudaModulo.EjecutarAyuda(dfFiltro.Text);

                foreach (Ayuda aux in registrosEncontrados)
                {
                    grdAyuda.Rows.Add(aux.getcodigo(),
                                      aux.getDescripcion());
                }

            }
            catch (BusinessException be)
            {
                FuncionesInformacionUsuario.FglMensajeError("Error en CargoListaAyuda: " + be.Message);
            } 
        
        
        }

        private void grdAyuda_DoubleClick(object sender, EventArgs e)
        {

            string sVlCodigo;

            string sVlDescripcion;

            if (filaSeleccionada >= 0)
            {
                sVlCodigo = this.grdAyuda.Rows[filaSeleccionada].Cells[0].Value.ToString();
                sVlDescripcion = this.grdAyuda.Rows[filaSeleccionada].Cells[1].Value.ToString();
                AyudaValorSeleccionado aux = AyudaValorSeleccionado.getInstance(sVlCodigo, sVlDescripcion);
                this.Dispose();
            }
       
        }

        private void grdAyuda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            filaSeleccionada = e.RowIndex;
            ColumnaSeleccionada = e.ColumnIndex;
        }



        private void pbAbout_Click(object sender, EventArgs e)
        {
            frmAbout acercaDe = new frmAbout();
            acercaDe.ShowDialog();
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            AyudaValorSeleccionado aux = AyudaValorSeleccionado.getInstance("", "");
            this.Dispose();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}
