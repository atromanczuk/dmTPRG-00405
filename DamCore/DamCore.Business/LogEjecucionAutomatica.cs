using DamCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Business
{
    public static class LogEjecucionAutomatica
    {
        //registro informacion en el logger
        public static void graboLineaLog(string stringLog)
        {
            LoggerAutomatico.EscribirLog(stringLog);
        }

        public static void graboLineaLogSinFecha(string stringLog)
        {
            LoggerAutomatico.EscribirLogSinFecha(stringLog);
        }

        public static void GraboExcepcionLog(Exception ExcepcionLog)
        {
            LoggerAutomatico.EscribirExcepcionLog(ExcepcionLog);
        }
        public static void graboColeccionString(List<string> coleccionstring)
        {
            LoggerAutomatico.EscribirLog(coleccionstring);
        }
        public static void graboColeccionString(Dictionary<string, string> coleccionstring)
        {
            LoggerAutomatico.EscribirLog(coleccionstring);
        }
        public static void graboLineaLogSinFecha(List<string> coleccionstring)
        {
            LoggerAutomatico.EscribirLogsinFecha(coleccionstring);
        }

        public static void graboLineaLogSinFecha(Dictionary<string, string> coleccionstring)
        {
            LoggerAutomatico.EscribirLogsinFecha(coleccionstring);
        }
        public static void GraboSaltoLinea()
        {
            LoggerAutomatico.EscribirSaltoDeLinea();
        }

        public static void grabarLineaLogErroresSinFecha(string linea)
        {
            LoggerAutomatico.marcarArchivoErroresAPPsinFecha(linea);
        }
        public static void grabarLineaLogErrores(string linea)
        {
            LoggerAutomatico.marcarArchivoErroresAPP(linea);
        }


    }

}
