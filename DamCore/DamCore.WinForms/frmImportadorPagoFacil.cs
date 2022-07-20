using DamCore.Business;
using DamCore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DamCore.WinForms
{
    public partial class frmImportadorPagoFacil : Form
    {
        public frmImportadorPagoFacil()
        {
            InitializeComponent();
            ttpInfo.SetToolTip(this.pbLimpiar, "Limpiar controles.");
            ttpInfo.SetToolTip(this.pbEjecutarImportacion, "Ejecutar importación de comprobantes.");
            ttpInfo.SetToolTip(this.pbParametrosGenerales, "Configuración de parámetros generales.");
            ttpInfo.SetToolTip(this.pbAbout, "Acerca de...");
            ttpInfo.SetToolTip(this.pbSalir, "Cerrar operación.");
            ttpInfo.SetToolTip(this.dfPathArchivo, "Path del archivo a procesar.");
            ttpInfo.SetToolTip(this.pbBuscarArchivo, "Buscar archivo manualmente.");
        }

        private void pbLimpiar_Click(object sender, EventArgs e)
        {
            limpioControles();
        }


        private void limpioControles()
        {
            this.dfPathArchivo.Text = "";
            this.dfPathArchivo.Focus();
        }

        private void pbAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            if (FuncionesInformacionUsuario.FglMensajeConfirma("Desea abandonar el presente formulario?") == (int)DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void pbBuscarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt Files|*.txt";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.dfPathArchivo.Text = (openFileDialog1.FileName);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message, ex);
                    }
                }


            }
            catch (Exception ex)
            {
                FuncionesInformacionUsuario.FglMensajeError(ex.Message);
            }


        }

        private void pbEjecutarImportacion_Click(object sender, EventArgs e)
        {

            try
            {
                //defino los filtros

                filtrosOperacion filtros = new filtrosOperacion();
                filtros.archivoCSV = this.dfPathArchivo.Text;
                filtros.division = "";
                filtros.sucursal = "";
                filtros.tipo = "";
                filtros.cuentaContable = "";
                //Proceso el archivo
                BusinessRecibos procesamientoRecibos = new BusinessRecibos();

                if (procesamientoRecibos.procesamiento(filtros))
                {
                    FuncionesInformacionUsuario.FglMensajeInforma("No se ha procesado el archivo por errores detectados en los registros informados. Por favor, chequee el log de ejecución para más detalles.");
                }
                else
                {
                    FuncionesInformacionUsuario.FglMensajeInforma("Procesamiento finalizado exitosamente.");
                }

            }
            catch (Exception ex)
            {
                FuncionesInformacionUsuario.FglMensajeError(ex.Message);
            }

            finally
            {
                limpioControles();
            }
        }

        private void pbParametrosGenerales_Click(object sender, EventArgs e)
        {
            frmParametrosGenerales.GetForm().ShowDialog();

        }

        private void spcPrincipal_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void frmImportadorPagoFacil_Load(object sender, EventArgs e)
        {

        }


    }
}
