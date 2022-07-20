using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DamCore.WinForms
{
    public static class FuncionesInformacionUsuario
    {

        public static void FglMensajeError(string sPlMensaje)
        {   //PROCEDIMIENTO QUE DESPLIEGA UN MENSAJE DE ERROR EN CASO DE FALLO SEA CRITICO.
            MessageBox.Show(sPlMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool FglErroresGeneralesReintenta(Int64 nPlErrorInformado,
                                                 string sPlProcedimiento,
                                                 string sPlDescripcionError)
        {   //FUNCION QUE DESPLIEGA UN MENSAJE AL USUARIO INFORMANDO UN ERROR. RETORNA VALOR BOOL SEGUN CORRESPONDA
            int nVlRpta;
            string sVlDescripcionError;
            //SE ARMA DESCRIPCION DEL ERROR A PUBLICAR
            sVlDescripcionError = "Error en procedimiento " + sPlProcedimiento + ". Error número: " + Convert.ToString(nPlErrorInformado) + " - " + sPlDescripcionError;
            //SE DESPLIEGA EL CUADRO DE MENSAJE Y SE CAPTURA LA RESPUESTA
            nVlRpta = (int)MessageBox.Show(sVlDescripcionError, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //SE RETORNA RESULTADO SEGUN CORRESPONDA
            if (nVlRpta == (int)System.Windows.Forms.DialogResult.Retry)
                return true;
            else
                return false;
        }


        public static int FglMensajeConfirma(string sPlMensaje)
        {
            int nVlRpta;
            //SE DESPLIEGA EL CUADRO DE MENSAJE Y SE CAPTURA LA RESPUESTA
            nVlRpta = (int)MessageBox.Show(sPlMensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //SE RETORNA LA RESPUESTA
            return nVlRpta;

        }


        public static int FglMensajeAdvertencia(string sPlMensaje)
        {
            int nVlRpta;
            //SE DESPLIEGA EL CUADRO DE MENSAJE Y SE CAPTURA LA RESPUESTA
            nVlRpta = (int)MessageBox.Show(sPlMensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //SE RETORNA LA RESPUESTA
            return nVlRpta;
        }

        public static void FglMensajeInforma(string sPlMensaje)
        {   //PROCEDIMIENTO QUE DESPLIEGA UN MENSAJE DE INFORMACION.
            MessageBox.Show(sPlMensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        public static bool fglEstaCargado(string sPlFormulario)
        {   //FUNCION QUE DETECA SI UN FORMULARIO ESPECIFICO YA ESTA CARGADO EN MEMORIA
            bool bVlFormCargado;

            //SETEO POR DEFAUL FALSE
            bVlFormCargado = false;


            //RECORRO TODOS LOS FORMULARIOS ABIERTOS
            foreach (Form myFrm in Application.OpenForms)
            {
                if (myFrm.Name == sPlFormulario)
                {   //SI ENCUENTRO AL FORMULARIO BUSCADO, ENTRE LOS FORMULARIOS ABIERTOS, MARCO LA VARIABLE CON TRUE
                    bVlFormCargado = true;
                }
            }

            //RETORNO RESULTADO DE VARIABLE 
            return bVlFormCargado;
        }


    }
}
