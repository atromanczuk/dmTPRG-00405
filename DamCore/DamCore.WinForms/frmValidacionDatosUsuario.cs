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
    public partial class frmValidacionDatosUsuario : Form
    {
        string nombrePrograma;
        bool claveValidada;
        string leyenda;

        public frmValidacionDatosUsuario()
        {
            InitializeComponent();
        }

        public void CargoDatosOperacion(string NombrePrograma,string Leyenda = "")
        {
            nombrePrograma = NombrePrograma;
            claveValidada = false;
            leyenda = Leyenda;
        }

        private void frmValidacionDatosUsuario_Load(object sender, EventArgs e)
        {
            this.lblLeyenda.Text = leyenda;

            //f (leyenda.Length == 0)

            //this.pbAbout.Visible = leyenda.Length == 0;
            //this.pbSalir.Visible = leyenda.Length == 0;
            
            this.dfUsuario.Focus();
            
        }

        private void pbValidarOf_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dfUsuario.Text.Length == 0)
                {
                    throw new BusinessException("Por favor, ingrese un usuario", new Exception());
                }



                if (this.dfContraseña.Text.Length > 0)
                {
                    claveValidada = Seguridad.ValidoPasswordIngresada(this.dfContraseña.Text,  nombrePrograma, DatosAccesorios.getInstance().getUsuario());

                    frmParametrosGenerales.GetForm().HabilitadoEdicionContraseña(claveValidada);
                    if (claveValidada)
                    {

                       
                            FuncionesInformacionUsuario.FglMensajeInforma("Modificación de parámetro habilitada.");
                            frmParametrosGenerales.GetForm().HabilitadoEdicionContraseña(claveValidada);
                        
                        
                        this.Dispose();
                    }
                    else
                    {
                        FuncionesInformacionUsuario.FglMensajeInforma("La clave ingresada no es correcta.");
                    }
                }
                else
                {
                    throw new BusinessException("Por favor, ingrese una contraseña",new Exception());
                }
                



            }
            catch (BusinessException ex)
            {
                FuncionesInformacionUsuario.FglMensajeError(ex.Message);
            }
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            
                frmParametrosGenerales.GetForm().HabilitadoEdicionContraseña(claveValidada);
 
            this.Dispose();
        }

        private void dfUsuario_Leave(object sender, EventArgs e)
        {

        }

        private void dfUsuario_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.dfContraseña.Clear();

                if (this.dfUsuario.Text.Length == 0)
                {
                    e.Cancel = false;
                    return;
                }

                UsuarioPF usuario = new UsuarioPF(this.dfUsuario.Text, "");
                Seguridad.validoExistenciaUsuario(usuario);
                e.Cancel = false;
            }

            catch (BusinessException ex)
            {
                
                e.Cancel = true;
                FuncionesInformacionUsuario.FglMensajeError(ex.Message);
            }           
        }
    }
}
