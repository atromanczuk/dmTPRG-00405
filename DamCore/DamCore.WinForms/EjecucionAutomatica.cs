using DamCore.Business;
using DamCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.WinForms
{
    public static class EjecucionAutomatica
    {

        public static void ejecutorTareaAutomatica(string[] parametrosAutomatico, string programa, string version)
        {
            try
            {
                SeteoDatosAccesorios(parametrosAutomatico, programa, version);
                LogAutomatico.getInstance(ParametrosAdicionalesServicio.pathArchivosLog, "ProcesamientoAutomatico-" + DateTime.Now.ToShortDateString().Replace("/", "-"), "txt");
                ArchivoLogErrores.getInstance(ParametrosAdicionalesServicio.pathArchivosLog, "errores", "");
                filtrosOperacion parametrosGenerales = new filtrosOperacion();
                parametrosGenerales.division = Properties.Settings.Default.Division;
                parametrosGenerales.sucursal = Properties.Settings.Default.Sucursal;
                parametrosGenerales.tipo = Properties.Settings.Default.TipoRecibo;
                parametrosGenerales.cuentaContable = Properties.Settings.Default.CuentaContable;


                LogEjecucionAutomatica.graboLineaLog("--------------------------------------------");
                LogEjecucionAutomatica.graboLineaLog("--------------------------------------------");
                LogEjecucionAutomatica.graboLineaLog("# Producto: " + DatosAccesorios.getInstance("").getPrograma());
                LogEjecucionAutomatica.graboLineaLog("# Ejecución automática");
                LogEjecucionAutomatica.graboLineaLog("# Versión del producto: " + DatosAccesorios.getInstance("").getVersion());
                LogEjecucionAutomatica.graboLineaLog("# Usuario PF: " + DatosAccesorios.getInstance("").getUsuario());
                LogEjecucionAutomatica.graboLineaLog("# PC: " + Environment.MachineName);
                LogEjecucionAutomatica.graboLineaLog("# Usuario de Windows: " + Environment.UserName);
                LogEjecucionAutomatica.GraboSaltoLinea();


                LogInformacionEjecucion.grabarLineaLogErrores("------------------------------------------");
                LogInformacionEjecucion.grabarLineaLogErrores("------------------------------------------");
                LogInformacionEjecucion.grabarLineaLogErrores("# Producto: " + DatosAccesorios.getInstance("").getPrograma());
                LogInformacionEjecucion.grabarLineaLogErrores("# Ejecución automática");
                LogInformacionEjecucion.grabarLineaLogErrores("# Versión del producto: " + DatosAccesorios.getInstance("").getVersion());
                LogInformacionEjecucion.grabarLineaLogErrores("# Usuario PF: " + DatosAccesorios.getInstance("").getUsuario());
                LogInformacionEjecucion.grabarLineaLogErrores("# PC: " + Environment.MachineName);
                LogInformacionEjecucion.grabarLineaLogErrores("# Usuario de Windows: " + Environment.UserName);


                //desencripto la contraseña
                parametrosAutomatico[3] = Seguridad.DesencriptoContraseña(parametrosAutomatico[3]);

                //seteo los datos de conectividad
                SeteoDatosConectividad(parametrosAutomatico);

                LogEjecucionAutomatica.graboLineaLog("Incorporación automática de recibos");
                ejecucionAutomaticaPagoFacil(parametrosGenerales);
                LogEjecucionAutomatica.graboLineaLog("Operación finalizada.");
                LogInformacionEjecucion.grabarLineaLogErrores("Operación finalizada.");
            

            }
            catch (Exception EX)
            {

                LogEjecucionAutomatica.GraboExcepcionLog(EX);
                LogEjecucionAutomatica.GraboSaltoLinea();
                LogEjecucionAutomatica.graboLineaLog("Operación finalizada con errores.");
                LogInformacionEjecucion.grabarLineaLogErrores("Operación finalizada con errores.");
                LogEjecucionAutomatica.GraboSaltoLinea();
            }

        }


        private static void ejecucionAutomaticaPagoFacil(filtrosOperacion parametrosGenerales)
        {
            try
            {

                new BusinessRecibos().ejecutoProcesoAutomatico(parametrosGenerales);
           

            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        private static void SeteoDatosConectividad(string[] parametrosAutomatico)
        {

            try
            {
                DatosConexion.getInstance(parametrosAutomatico[1],
                                            parametrosAutomatico[0],
                                            parametrosAutomatico[1],
                                            parametrosAutomatico[2],
                                            parametrosAutomatico[3],
                                            "2");

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }

        }

        private static void SeteoDatosAccesorios(string[] args, string programa, string version)
        {

            try
            {
                DatosAccesorios.getInstance(args[4]);
                DatosAccesorios.getInstance("").setPrograma(programa);
                DatosAccesorios.getInstance("").setVersion(version);

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }

        }
    }
}
