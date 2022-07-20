using DamCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Business
{
    public static class LogInformacionEjecucion
    {
        //registro informacion en el logger
        public static void graboLineaLog(string stringLog)
        {
            Logger.EscribirLog(stringLog);
        }

        public static void graboLineaLogSinFecha(string stringLog)
        {
            Logger.EscribirLogSinFecha(stringLog);
        }

        public static void GraboExcepcionLog(Exception ExcepcionLog)
        {
            Logger.EscribirExcepcionLog(ExcepcionLog);
        }
        public static void graboColeccionString(List<string> coleccionstring)
        {
            Logger.EscribirLog(coleccionstring);
        }
        public static void graboColeccionStringSinFecha(List<string> coleccionstring)
        {
            Logger.EscribirLogsinFecha(coleccionstring);
        }

        public static void graboColeccionString(Dictionary<string, string> coleccionstring)
        {
            Logger.EscribirLog(coleccionstring);
        }
        public static void graboLineaLogSinFecha(List<string> coleccionstring)
        {
            Logger.EscribirLogsinFecha(coleccionstring);
        }

        public static void graboLineaLogSinFecha(Dictionary<string, string> coleccionstring)
        {
            Logger.EscribirLogsinFecha(coleccionstring);
        }
        public static void GraboSaltoLinea()
        {
            Logger.EscribirSaltoDeLinea();
        }

        public static void grabarLineaLogErroresSinFecha(string linea)
        {
            Logger.marcarArchivoErroresAPPsinFecha(linea);
        }
        public static void grabarLineaLogErrores(string linea)
        {
            Logger.marcarArchivoErroresAPP(linea);
        }
    }

}
