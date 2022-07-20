using DamCore.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DamCore.DataAccess
{
    public static class LoggerAutomatico
    {
        public static bool VerificoExistenciaPath(string Path)
        {
            return Directory.Exists(Path);
        }


        // si pasamos la ruta de un archivo, su utilizará ese para hacer el log, o se asigna uno por defecto

        public static void EscribirLog(string logText)
        {
            try
            {
                using (StreamWriter w = File.AppendText(LogAutomatico.getInstance("", "", "").getArchivo()))
                {
                    w.WriteLine(DateTime.Now.ToString() + " - " + logText);
                }
            }
            catch { }
        }

        public static void EscribirLogSinFecha(string logText)
        {
            try
            {
                using (StreamWriter w = File.AppendText(LogAutomatico.getInstance("", "", "").getArchivo()))
                {
                    w.WriteLine(" - " + logText);
                }
            }
            catch { }
        }
        public static void EscribirSaltoDeLinea()
        {
            try
            {
                using (StreamWriter w = File.AppendText(LogAutomatico.getInstance("", "", "").getArchivo()))
                {
                    w.WriteLine("");
                }
            }
            catch { }
        }

        public static void EscribirLog(List<string> logText)
        {
            try
            {
                using (StreamWriter w = File.AppendText(LogAutomatico.getInstance("", "", "").getArchivo()))
                {
                    foreach (string aux in logText)
                    {
                        w.WriteLine(DateTime.Now.ToString() + " - " + aux);
                    }

                }
            }
            catch { }
        }

        public static void EscribirLog(Dictionary<string, string> logText)
        {
            try
            {
                using (StreamWriter w = File.AppendText(LogAutomatico.getInstance("", "", "").getArchivo()))
                {
                    foreach (KeyValuePair<string, string> aux in logText)
                    {
                        w.WriteLine(DateTime.Now.ToString() + " - " + aux.Key + " - " + aux.Value);
                    }

                }
            }
            catch { }
        }

        public static void EscribirLogsinFecha(Dictionary<string, string> logText)
        {
            try
            {
                using (StreamWriter w = File.AppendText(LogAutomatico.getInstance("", "", "").getArchivo()))
                {
                    foreach (KeyValuePair<string, string> aux in logText)
                    {
                        w.WriteLine(DateTime.Now.ToString() + " - " + aux.Key + " - " + aux.Value);
                    }

                }
            }
            catch { }
        }

        public static void EscribirLogsinFecha(List<string> logText)
        {
            try
            {
                using (StreamWriter w = File.AppendText(LogAutomatico.getInstance("", "", "").getArchivo()))
                {
                    foreach (string aux in logText)
                    {
                        w.WriteLine(" - " + aux);
                    }

                }
            }
            catch { }
        }


        public static void marcarArchivoErroresAPPsinFecha(string Linea)
        {

            try
            {
                using (StreamWriter w = File.AppendText(ArchivoLogErrores.getInstance("", "", "").getArchivo()))
                {

                    w.WriteLine(" - " + Linea);


                }
            }
            catch { }
        }


        public static void marcarArchivoErroresAPP(string Linea)
        {

            try
            {
                using (StreamWriter w = File.AppendText(ArchivoLogErrores.getInstance("", "", "").getArchivo()))
                {

                    w.WriteLine(DateTime.Now.ToString() + " - " + Linea);


                }
            }
            catch { }
        }
        public static void EscribirExcepcionLog(Exception ex)
        {
            try
            {
                using (StreamWriter w = File.AppendText(LogAutomatico.getInstance("", "", "").getArchivo()))
                {
                    w.WriteLine(DateTime.Now.ToString() + " - Error en el procesamiento de archivo - Detalles ");
                    w.WriteLine("Message: " + ex.Message);
                    w.WriteLine("");
                }

                using (StreamWriter w = File.AppendText(ArchivoLogErrores.getInstance("", "", "").getArchivo()))
                {
                    w.WriteLine(DateTime.Now.ToString() + " - Error en el procesamiento de archivo - Detalles ");
                    w.WriteLine("Message: " + ex.Message);
                    w.WriteLine("Source: " + ex.Source);
                    w.WriteLine("TargetSite: " + ex.TargetSite);
                    w.WriteLine("StackTrace: " + ex.StackTrace);
                    w.WriteLine("InnerException: " + ex.InnerException);
                    w.WriteLine("");
                }
            }
            catch { }
        }



    }

}
