using DamCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Business
{
    public static class logErrores
    {

        //registro informacion en el logger
        public static void graboColeccionStringSinFecha(List<string> coleccionstring)
        {
            loggerErrores.EscribirLogsinFecha(coleccionstring);
        }

        public static void graboLineaLog(string stringLog)
        {
            loggerErrores.EscribirLog(stringLog);
        }

        public static void graboLineaLogSinFecha(string stringLog)
        {
            loggerErrores.EscribirLogSinFecha(stringLog);
        }

        public static void GraboExcepcionLog(Exception ExcepcionLog)
        {
            loggerErrores.EscribirExcepcionLog(ExcepcionLog);
        }
        public static void graboColeccionString(List<string> coleccionstring)
        {
            loggerErrores.EscribirLog(coleccionstring);
        }
        public static void graboColeccionString(Dictionary<string, string> coleccionstring)
        {
            loggerErrores.EscribirLog(coleccionstring);
        }
        public static void graboLineaLogSinFecha(List<string> coleccionstring)
        {
            loggerErrores.EscribirLogsinFecha(coleccionstring);
        }

        public static void graboLineaLogSinFecha(Dictionary<string, string> coleccionstring)
        {
            loggerErrores.EscribirLogsinFecha(coleccionstring);
        }
        public static void GraboSaltoLinea()
        {
            loggerErrores.EscribirSaltoDeLinea();
        }

        public static void grabarLineaLogErroresSinFecha(string linea)
        {
            loggerErrores.marcarArchivoErroresAPPsinFecha(linea);
        }
        public static void grabarLineaLogErrores(string linea)
        {
            loggerErrores.marcarArchivoErroresAPP(linea);
        }

    }

}
