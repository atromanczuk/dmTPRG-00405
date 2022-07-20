using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DamCore.DamExceptions;
using DamCore.Business;
using DamCore.Common;

namespace DamCore.WinForms
{
    public partial class frmParametrosGenerales : Form
    {
        private string nombrePrograma;
        private List<ParametrosGenerales> ListaDeParametros;
        private static frmParametrosGenerales instance = null;

        private bool HabilitadaEdicion;

        protected frmParametrosGenerales()
        {
            InitializeComponent();
        }


        public static frmParametrosGenerales GetForm()
        {
            if (instance == null)
                instance = new frmParametrosGenerales();

            return instance;
        
        }

        public static bool hayInstanciaCargada()
        {
            return !(instance == null);
        }

        public void HabilitadoEdicionContraseña(bool Habilitado)
        {
            HabilitadaEdicion = Habilitado;
        }
        private void frmParametrosGenerales_Load(object sender, EventArgs e)
        {
            
            nombrePrograma = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            ListaDeParametros = new BusinessParametrosGenerales().ListarParametros(nombrePrograma);
            CargarParametros();
            bloquearControlesEdicion(false);
        }

        private void CargarParametros()
        { 
        //procedimiento para limpiar y cargar la lista de parametros
            this.lbParametrosGenerales.Items.Clear();
            ListaDeParametros.Clear();

            ListaDeParametros = new BusinessParametrosGenerales().ListarParametros(nombrePrograma);

            foreach (ParametrosGenerales aux in ListaDeParametros)
            {
                lbParametrosGenerales.Items.Add(aux.getNombreParametro());
            }

        }

        private void lbParametrosGenerales_Click(object sender, EventArgs e)
        {//en caso de seleccionar un item del listado, se cargan los valores de los campos

            try
            {
                foreach (ParametrosGenerales aux in ListaDeParametros)
                {
                    if (lbParametrosGenerales.SelectedItem.ToString() == aux.getNombreParametro())
                    {

                        this.lblValorNombre.Text = aux.getNombreParametro();

                        this.lblValorDescripcion.Text = aux.getDescripcionParametro();

                        this.dfValor.Text = aux.getValorParametro();

                        if (aux.getEsUtilizable() == "1")
                        {
                            this.cbEditable.CheckState = CheckState.Checked;
                            this.dfValor.Enabled = true;
                        }
                        else
                        {
                            this.cbEditable.CheckState = CheckState.Unchecked; 
                            this.dfValor.Enabled = false;
                        }

                        if (aux.getEsContraseña())
                        {
                            this.dfValor.PasswordChar = Convert.ToChar("*");   
                        }

                        else
                        {
                            this.dfValor.PasswordChar = '\0'; 
                        }



                        if (aux.getRequiereValidacion())
                        {
                            this.chkRequiereValidacion.CheckState = CheckState.Checked;

                        }
                        else
                        {
                            this.chkRequiereValidacion.CheckState = CheckState.Unchecked;
                        }
                    }
                
                
                }
            }
            catch (Exception ex)
            {
                FuncionesInformacionUsuario.FglMensajeError(ex.Message);
            }
        }

        private void pbLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void lbParametrosGenerales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbParametrosGenerales_DoubleClick(object sender, EventArgs e)
        {
            if (lbParametrosGenerales.SelectedItems.Count != 1)
                FuncionesInformacionUsuario.FglMensajeError("Por favor, seleccione un valor del listado de parámetros.");
            else
            {
                if (this.chkRequiereValidacion.CheckState == CheckState.Checked)
                {   
                    frmValidacionDatosUsuario validacion = new frmValidacionDatosUsuario();
                    validacion.CargoDatosOperacion(nombrePrograma);
                    validacion.ShowDialog();

                    if (this.HabilitadaEdicion)
                    {
                        bloquearControlesEdicion(true);
                    }
                    else
                        FuncionesInformacionUsuario.FglMensajeError("El parámetro seleccionado no puede editarse.");


                }
                else
                {
                    bloquearControlesEdicion(true);
                }
               

            }
        }

        private void pbModificar_Click(object sender, EventArgs e)
        {
            if (lbParametrosGenerales.SelectedItems.Count != 1)
                FuncionesInformacionUsuario.FglMensajeError("Por favor, seleccione un valor del listado de parámetros.");
            else
            {
                if (this.chkRequiereValidacion.CheckState == CheckState.Checked)
                {
                    frmValidacionDatosUsuario validacion = new frmValidacionDatosUsuario();
                    validacion.CargoDatosOperacion(nombrePrograma);
                    validacion.ShowDialog();

                    if (this.HabilitadaEdicion)
                    {
                        bloquearControlesEdicion(true);
                    }
                    else
                        FuncionesInformacionUsuario.FglMensajeError("El parámetro seleccionado no puede editarse.");
                    this.Focus();

                }
                else
                {
                    bloquearControlesEdicion(true);
                }
            }
        }

        private void bloquearControlesEdicion(bool Estado)
        {
            this.lbParametrosGenerales.Enabled = !Estado;

            this.pnlValores.Enabled = Estado;

            this.pbDeshacer.Enabled = Estado;
            this.pbGrabar.Enabled = Estado;

            this.pbModificar.Enabled = !Estado;
            this.pbLimpiar.Enabled = !Estado;


        }
        private void LimpiarCampos()
        {
            CargarParametros();
            this.lblValorDescripcion.Text = "";
            this.lblValorNombre.Text = "";
            this.dfValor.Text = "";
            this.cbEditable.CheckState = CheckState.Unchecked;

        }


        private void pbDeshacer_Click(object sender, EventArgs e)
        {
            if (FuncionesInformacionUsuario.FglMensajeConfirma("Desea deshacer la operación?") == (int)DialogResult.Yes)
            {
                LimpiarCampos();
                bloquearControlesEdicion(false);
            }
        }

        private void pbGrabar_Click(object sender, EventArgs e)
        {
            try 
            {
                //ValidoParámetro
                BusinessParametrosGenerales accionesParametro = new BusinessParametrosGenerales();

                ParametrosGenerales auxPar = new ParametrosGenerales(this.lblValorNombre.Text,
                                                                    this.dfValor.Text,
                                                                    this.lblValorDescripcion.Text,
                                                                    "",
                                                                    "",
                                                                    false,
                                                                    false);

                //valido los parametros
                accionesParametro.ValidoParámetro(auxPar);

                if (this.chkRequiereValidacion.CheckState == CheckState.Checked)
                { 
                
                
                }

                //actualizacion del parametro

                accionesParametro.ActualizoParametro(auxPar,nombrePrograma);

                //de salir todo ok, se actualizan los controles

                LimpiarCampos();
                bloquearControlesEdicion(false);

                //informo el ok de la operacion
                FuncionesInformacionUsuario.FglMensajeInforma("Actualización del parámetro " + auxPar.getNombreParametro() + " finalizada con exito.");

            }

            catch (Exception ex)
            {
                FuncionesInformacionUsuario.FglMensajeError(ex.Message);
            }
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
                instance = null;
                this.Dispose();
            }

        }

        private void frmParametrosGenerales_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;

        }

    }

}
