using DamCore.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace DamCore.DataAccess
{
    public class ArchivosTXT
    {

        public List<String> buscoArchivosDirectorio()
        {
            try
            {
                List<String> archivos = new List<string>();
                string[] files = Directory.GetFiles(ParametrosAdicionalesServicio.pathLecturaArchivos, "*.txt");
                foreach (string archivo in files)
                {
                    archivos.Add(archivo);
                }

                return archivos;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool VerificoExistenciaArchivo(string PathArchivo)
        {
            return File.Exists(PathArchivo);
        }

        public bool VerificarExtension(string PathArchivo)
        {
            string fileName;
            fileName = "";
            string ext = Path.GetExtension(PathArchivo);
            switch (ext.ToLower())
            {
                case ".txt":
                    return true;
                default:
                    return false;
            }
        }



        public void renombrarArchivo(string PathArchivo, string pathCopia)
        {
            try
            {
                string archivo = PathArchivo.Substring(PathArchivo.LastIndexOf("\\") + 1);
                archivo = archivo.Substring(0, archivo.Length - 4);

                File.Copy(PathArchivo, pathCopia + "\\" + archivo + "_" + DateTime.Now.ToShortDateString().Replace(@"/", ""));
                File.Delete(PathArchivo);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<RegistroPagoFacil> lecturaDatosArchivo(string PathArchivo, out bool EstadoLectura)
        {
            try
            {

                List<RegistroPagoFacil> registrosArchivo = new List<RegistroPagoFacil>();
                List<string> registrosMalGenerados = new List<string>();
                RegistroPagoFacil registroAux ;
                Int64 cantidadRegistrosErroneos;
                Int64 lineaNro;

                cantidadRegistrosErroneos = 0;
                lineaNro = 0;

                EstadoLectura = true;
                using (StreamReader rdr = new StreamReader(PathArchivo))
                {
                    string linea;
                    
                    while (null != (linea = rdr.ReadLine()))
                    {
                        lineaNro = lineaNro + 1;

                        if (linea.Length == 128)
                        {

                            if (linea.Substring(0, 1) == "5")
                            {

                                registroAux = new RegistroPagoFacil();
                                registroAux.cliente = linea.Substring(24, 21).Trim();
                                registroAux.fecha = linea.Substring(8, 8).Trim();
                                registroAux.importe = (Convert.ToDecimal(linea.Substring(48,10))/100).ToString().Replace(",",".");

                                registroAux.descripcion = "Terminal: " + linea.Substring(58, 6).Trim() + " # Fecha y hora: " + DateTime.ParseExact(linea.Substring(64, 8).Trim(), "yyyyMMdd", CultureInfo.InvariantCulture).ToShortDateString() + " " + linea.Substring(72, 2).Trim() + ":" + linea.Substring(74, 2).Trim();
                                registroAux.linea = lineaNro;

                                registrosArchivo.Add(registroAux);
                            }
                        }
                        else
                        {
                            cantidadRegistrosErroneos = cantidadRegistrosErroneos + 1;
                            registrosMalGenerados.Add(linea);
                            EstadoLectura = false;
                        }
                    }

                }

                if (registrosMalGenerados.Count > 0)
                {
                    EstadoLectura = false;
                    Logger.EscribirLog("Se han encontrado " + registrosMalGenerados.Count.ToString() + " registros mal formateados, que fueron omitidos por la aplicación:");
                    Logger.EscribirLogsinFecha(registrosMalGenerados);
                }


                return registrosArchivo;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
