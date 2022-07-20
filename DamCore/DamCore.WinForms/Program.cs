using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DamCore.Business;
using DamCore.DamExceptions;
using DamCore.Common;

namespace DamCore.WinForms
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            try
            {

                //REESCRIBO LOS VALORES DE PARAMETROS
                //Args = new string[7];
                //Args[0] = "dblier";
                //Args[1] = "INTEC";
                //Args[2] = "sasa";
                //Args[3] = "sa";
                //Args[4] = "SERVER28";
                //Args[5] = "dblier";
                //Args[6] = "2";

                //Args = new string[1];
                //Args[0] = "dblier";

                //Seguridad.ValidoPasswordIngresada("sasa", "", "");
                Int32 cantidadParametros = 0;
                //VALIDO LOS PARAMETROS RECIBIDOS
                cantidadParametros = ValidacionesInicioProyecto.validoParametros(Args);
                if (cantidadParametros == 7)
                {
                    //CARGO LOS PARAMETROS RECIBIDOS EN LA CLASE INTERNA DE CONECTIVIDAD
                    ValidacionesInicioProyecto.SeteoDatosConectividad(Args, Application.ProductName, Application.StartupPath);

                    //VALIDO QUE PUEDA EFECTUARSE UNA CONEXION DE PRUEBAS CON LA BASE DE DATOS
                    ValidacionesInicioProyecto.ValidoConectividad();
                    //Seguridad.ValidarPermisosUsuario("CCO-E500-1255A");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new DamCore.WinForms.frmImportadorPagoFacil());
                }
                else
                {
                    if (Properties.Settings.Default.Ejecucionautomatica == "SI")
                    {

                        //se recibe solo 1 parametro, dicho valor está vinculado a la tarea a ejecutar.
                        //string lalala = Seguridad.DesencriptoContraseña("602535455455");
                        //armo la configuracion para el manejo de interfases

                        //cargo la informacion de conectividad
                        string[] parametrosAutomatico = new string[6];
                        parametrosAutomatico[0] = Properties.Settings.Default.Server;
                        parametrosAutomatico[1] = Properties.Settings.Default.BaseDatos;
                        parametrosAutomatico[2] = Properties.Settings.Default.Usuario;
                        parametrosAutomatico[3] = Properties.Settings.Default.Password;
                        parametrosAutomatico[4] = Properties.Settings.Default.UsuarioPF;
                        parametrosAutomatico[5] = Args[0];

                        ParametrosAdicionalesServicio.pathLecturaArchivos = Properties.Settings.Default.PathArchivos;
                        ParametrosAdicionalesServicio.pathArchivosLog = Properties.Settings.Default.PathArchivosLog;
                        EjecucionAutomatica.ejecutorTareaAutomatica(parametrosAutomatico, Application.ProductName, Application.ProductVersion);
                    }

                }

            }
            catch (BusinessException be)
            {
                FuncionesInformacionUsuario.FglMensajeError(be.Message);
            }
        }
    }
}
