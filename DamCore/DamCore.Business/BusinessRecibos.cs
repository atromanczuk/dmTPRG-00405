using DamCore.Common;
using DamCore.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DamCore.Business
{
    public class BusinessRecibos
    {







        public bool procesamientoAutomatico(filtrosOperacion filtros)
        {
            try
            {

                bool EstadoLectura;
                bool erroresIndividuales = false;
                string destinoArchivoLog = ParametrosAdicionalesServicio.pathArchivosLog;
                string destinoArchivoProcesado = new BusinessParametrosGenerales().buscoParametro("PATH_ARCHIVOS_PROCESADOS", DatosAccesorios.getInstance().getPrograma()).getValorParametro();

                //si no se indica ubicacion, se estblece la ubicacion del programa
                string FechaNombreArchivo = DateTime.Now.ToShortDateString().Replace("/", "_");

                //armado de nombres de archivos
                ArchivoLog.getInstance(destinoArchivoLog, "logProceso_" + FechaNombreArchivo, "txt");
                ArchivoErroresProceso.getInstance(destinoArchivoLog, "RegistrosErroneos_" + FechaNombreArchivo, "txt");
                ArchivoLogErrores.getInstance(destinoArchivoLog, "errores_Tec_" + FechaNombreArchivo, "");

                PersistanceRecibos operaciones = new PersistanceRecibos();

                LogInformacionEjecucion.GraboSaltoLinea();
                LogInformacionEjecucion.graboLineaLog("--------------------------------------------");
                LogInformacionEjecucion.graboLineaLog("--------------------------------------------");
                LogInformacionEjecucion.graboLineaLog("# Producto: " + DatosAccesorios.getInstance("").getPrograma());
                LogInformacionEjecucion.graboLineaLog("# Versión del producto: " + DatosAccesorios.getInstance("").getVersion());
                LogInformacionEjecucion.graboLineaLog("# Usuario PF: " + DatosAccesorios.getInstance("").getUsuario());
                LogInformacionEjecucion.graboLineaLog("# PC: " + Environment.MachineName);
                LogInformacionEjecucion.graboLineaLog("# Usuario de Windows: " + Environment.UserName);
                LogInformacionEjecucion.GraboSaltoLinea();
                LogInformacionEjecucion.graboLineaLog("# Archivo: " + filtros.archivoCSV);
                LogInformacionEjecucion.GraboSaltoLinea();


                logErrores.GraboSaltoLinea();
                logErrores.graboLineaLog("--------------------------------------------");
                logErrores.graboLineaLog("--------------------------------------------");
                logErrores.graboLineaLog("# Producto: " + DatosAccesorios.getInstance("").getPrograma());
                logErrores.graboLineaLog("# Versión del producto: " + DatosAccesorios.getInstance("").getVersion());
                logErrores.graboLineaLog("# Usuario PF: " + DatosAccesorios.getInstance("").getUsuario());
                logErrores.graboLineaLog("# PC: " + Environment.MachineName);
                logErrores.graboLineaLog("# Usuario de Windows: " + Environment.UserName);
                logErrores.GraboSaltoLinea();
                logErrores.graboLineaLog("# Archivo: " + filtros.archivoCSV);
                logErrores.GraboSaltoLinea();


                LogInformacionEjecucion.GraboSaltoLinea();
                LogInformacionEjecucion.grabarLineaLogErrores("------------------------------------------");
                LogInformacionEjecucion.grabarLineaLogErrores("------------------------------------------");
                LogInformacionEjecucion.grabarLineaLogErrores("# Producto: " + DatosAccesorios.getInstance("").getPrograma());
                LogInformacionEjecucion.grabarLineaLogErrores("# Versión del producto: " + DatosAccesorios.getInstance("").getVersion());
                LogInformacionEjecucion.grabarLineaLogErrores("# Usuario PF: " + DatosAccesorios.getInstance("").getUsuario());
                LogInformacionEjecucion.grabarLineaLogErrores("# PC: " + Environment.MachineName);
                LogInformacionEjecucion.grabarLineaLogErrores("# Usuario de Windows: " + Environment.UserName);
                LogInformacionEjecucion.grabarLineaLogErrores("");
                LogInformacionEjecucion.grabarLineaLogErrores("# Archivo: " + filtros.archivoCSV);
                LogInformacionEjecucion.grabarLineaLogErrores("");


                //valido los filtros 
                ValidoFiltrosOperacion(filtros);

                List<string> errores = operaciones.validacionesGeneralesAplicacion(filtros);
                //si hay errores en las validaciones generales, se corta la ejecucion del programa
                if (errores.Count > 0)
                {
                    LogInformacionEjecucion.graboLineaLog("Errores detectados en las validaciones generales:");
                    LogInformacionEjecucion.GraboSaltoLinea();
                    LogInformacionEjecucion.graboColeccionStringSinFecha(errores);

                    //logErrores.graboLineaLog("Errores detectados en las validaciones generales:");                    
                    //logErrores.GraboSaltoLinea();
                    //logErrores.graboColeccionStringSinFecha(errores);                    
                    throw new Exception("Se han detectado errores en las validaciones generales de la aplicacion, la operación ha sido cancelada");

                }

                //cargo la lista de valores a procesar
                List<RegistroPagoFacil> registros = new ArchivosTXT().lecturaDatosArchivo(filtros.archivoCSV, out EstadoLectura);



                if (registros.Count == 0)
                {
                    throw new Exception("No se han encontrado registros procesables.");

                }

                //en caso de no producirse errores, se graban los comprobantes uno a uno
                LogInformacionEjecucion.GraboSaltoLinea();
                //LogInformacionEjecucion.graboLineaLog("Inicio procesamiento masivo.");
                LogInformacionEjecucion.graboLineaLog("Validaciones de registros.");
                //proceso uno a uno los comprobantes

                foreach (RegistroPagoFacil reg in registros)
                {

                    try
                    {
                        //valido errores del registro
                        errores = operaciones.validacionesIndividualesRegistro(reg);

                        //si hay errores, los informo y marco que hubo errores
                        if (errores.Count > 0)
                        {
                            erroresIndividuales = true;
                            LogInformacionEjecucion.GraboSaltoLinea();
                            LogInformacionEjecucion.graboLineaLog("Linea: " + reg.linea.ToString() + " - Errores detectados:");
                            LogInformacionEjecucion.grabarLineaLogErrores("Linea: " + reg.linea.ToString() + " - Errores detectados:");
                            LogInformacionEjecucion.graboColeccionStringSinFecha(errores);


                            logErrores.GraboSaltoLinea();
                            logErrores.graboLineaLog("Linea: " + reg.linea.ToString() + " - Errores detectados:");
                            logErrores.graboColeccionStringSinFecha(errores);

                        }

                    }
                    catch (Exception ex2)
                    {
                        //cualquier excepcion no controlada se captura
                        erroresIndividuales = true;
                        LogInformacionEjecucion.GraboSaltoLinea();
                        LogInformacionEjecucion.graboLineaLog("Linea: " + reg.linea.ToString() + " -Error al procesar registros.");
                        LogInformacionEjecucion.graboLineaLog(ex2.Message);
                        LogInformacionEjecucion.grabarLineaLogErrores("Linea: " + reg.linea.ToString() + " -Error al procesar registros.");
                        LogInformacionEjecucion.GraboExcepcionLog(ex2);

                        logErrores.GraboSaltoLinea();
                        logErrores.graboLineaLog("Linea: " + reg.linea.ToString() + " -Error al procesar registros.");
                        logErrores.graboLineaLog(ex2.Message);
                        logErrores.GraboSaltoLinea();

                    }


                }


                //si hay errores, se informa en el archivo log y al usuario, cortando la ejecución.
                if (erroresIndividuales == true)
                {
                    //LogInformacionEjecucion.graboLineaLog("No se ha procesado el archivo por errores detectados en los registros informados. Por favor, chequee el log de ejecución para más detalles.");
                    LogInformacionEjecucion.graboLineaLog("No se ha procesado el archivo por errores detectados en los registros informados.");
                    //new ArchivosTXT().renombrarArchivo(filtros.archivoCSV, destinoArchivoProcesado);                  
                }
                else
                {
                    //si no hay errores, por cada registro se genera un recibo en IMAC

                    foreach (RegistroPagoFacil reg in registros)
                    {

                        //proceso el registro
                        try
                        {
                            operaciones.creacionReciboIMAC(filtros, reg);
                        }
                        catch (Exception ex)
                        {
                            erroresIndividuales = true;

                            LogInformacionEjecucion.GraboSaltoLinea();
                            LogInformacionEjecucion.graboLineaLog("Linea: " + reg.linea.ToString() + " -Error al procesar registro:");
                            LogInformacionEjecucion.graboLineaLog(ex.Message);
                            LogInformacionEjecucion.grabarLineaLogErrores("Linea: " + reg.linea.ToString() + " -Error al procesar registro:");
                            LogInformacionEjecucion.GraboExcepcionLog(ex);

                            logErrores.GraboSaltoLinea();
                            logErrores.graboLineaLog("Linea: " + reg.linea.ToString() + " -Error al procesar registro.");
                            logErrores.graboLineaLog(ex.Message);
                            logErrores.GraboSaltoLinea();
                            break;

                        }


                    }

                }




                if (erroresIndividuales == false)
                {
                    LogInformacionEjecucion.graboLineaLog("Copia de archivo procesado y eliminación de la copia procesada.");
                    new ArchivosTXT().renombrarArchivo(filtros.archivoCSV, destinoArchivoProcesado);
                }

                return erroresIndividuales;



            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                LogInformacionEjecucion.GraboSaltoLinea();
                LogInformacionEjecucion.graboLineaLog("Fin de procesamiento.");
            }
        }




        public void ejecutoProcesoAutomatico(filtrosOperacion parametrosGenerales)
        {
            try
            {
                List<String> archivos = new List<string>();
                archivos = new ArchivosTXT().buscoArchivosDirectorio();
                filtrosOperacion filtros;
                 

                if (archivos.Count == 0)
                {
                    LogEjecucionAutomatica.graboLineaLog("No se han encontrado archivos para procesar.");
                    //LogInformacionEjecucion.grabarLineaLogErrores("No se han encontrado archivos para procesar.");
                    return;
                }

                //por cada archivo leido del directorio
                foreach (String archivo in archivos)
                {
                    LogEjecucionAutomatica.GraboSaltoLinea();
                    LogEjecucionAutomatica.graboLineaLog("Archivo procesado: " + archivo);
                    //LogInformacionEjecucion.GraboSaltoLinea();
                    //LogInformacionEjecucion.grabarLineaLogErrores("Archivo procesado: " + archivo);
                    
                    parametrosGenerales.archivoCSV = archivo;


                    if (procesamientoAutomatico(parametrosGenerales))
                    {
                        //FuncionesInformacionUsuario.FglMensajeInforma("No se ha procesado el archivo por errores detectados en los registros informados. Por favor, chequee el log de ejecución para más detalles.");
                        
                        LogEjecucionAutomatica.graboLineaLog("El archivo no ha podido ser procesado.");
                        //LogInformacionEjecucion.GraboSaltoLinea();
                        //LogInformacionEjecucion.grabarLineaLogErrores("El archivo no ha podido ser procesado");
                    }
                    else
                    {
                        
                        LogEjecucionAutomatica.graboLineaLog("Archivo procesado");
                        //LogInformacionEjecucion.GraboSaltoLinea();
                        //LogInformacionEjecucion.grabarLineaLogErrores("Archivo procesado");
                    
                    }

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }


        private void ValidoFiltrosOperacion(filtrosOperacion filtros)
        {
            try
            {
                if (filtros.archivoCSV.Length == 0)
                {
                    throw new Exception("Por favor, indique un archivo para procesar.");
                }

                if (!File.Exists(filtros.archivoCSV))
                {
                    throw new Exception("El archivo indicado no existe o no es accesible.");
                }

                if (!new ArchivosTXT().VerificarExtension(filtros.archivoCSV))
                {
                    throw new Exception("El archivo indicado no es TXT.");
                }
            
            }
            catch (Exception)
            {

                throw;
            }
        }



        public bool procesamiento(filtrosOperacion filtros)
        {
            try
            {
               
                bool EstadoLectura;
                bool erroresIndividuales = false;
                string destinoArchivoLog = new BusinessParametrosGenerales().buscoParametro("PATH_ARCHIVOS_LOG", DatosAccesorios.getInstance().getPrograma()).getValorParametro();
                string destinoArchivoProcesado =     new BusinessParametrosGenerales().buscoParametro("PATH_ARCHIVOS_PROCESADOS", DatosAccesorios.getInstance().getPrograma()).getValorParametro();
                                
                //si no se indica ubicacion, se estblece la ubicacion del programa
                string FechaNombreArchivo = DateTime.Now.ToShortDateString().Replace("/", "_");
                
                //armado de nombres de archivos
                ArchivoLog.getInstance(destinoArchivoLog, "logProceso_" + FechaNombreArchivo, "txt");
                ArchivoErroresProceso.getInstance(destinoArchivoLog, "RegistrosErroneos_" + FechaNombreArchivo, "txt");
                ArchivoLogErrores.getInstance(destinoArchivoLog, "errores_Tec_" + FechaNombreArchivo, "");

                PersistanceRecibos operaciones = new PersistanceRecibos();

                LogInformacionEjecucion.GraboSaltoLinea();
                LogInformacionEjecucion.graboLineaLog("--------------------------------------------");
                LogInformacionEjecucion.graboLineaLog("--------------------------------------------");
                LogInformacionEjecucion.graboLineaLog("# Producto: " + DatosAccesorios.getInstance("").getPrograma());
                LogInformacionEjecucion.graboLineaLog("# Versión del producto: " + DatosAccesorios.getInstance("").getVersion());
                LogInformacionEjecucion.graboLineaLog("# Usuario PF: " + DatosAccesorios.getInstance("").getUsuario());
                LogInformacionEjecucion.graboLineaLog("# PC: " + Environment.MachineName);
                LogInformacionEjecucion.graboLineaLog("# Usuario de Windows: " + Environment.UserName);
                LogInformacionEjecucion.GraboSaltoLinea();


                logErrores.GraboSaltoLinea();
                logErrores.graboLineaLog("--------------------------------------------");
                logErrores.graboLineaLog("--------------------------------------------");
                logErrores.graboLineaLog("# Producto: " + DatosAccesorios.getInstance("").getPrograma());
                logErrores.graboLineaLog("# Versión del producto: " + DatosAccesorios.getInstance("").getVersion());
                logErrores.graboLineaLog("# Usuario PF: " + DatosAccesorios.getInstance("").getUsuario());
                logErrores.graboLineaLog("# PC: " + Environment.MachineName);
                logErrores.graboLineaLog("# Usuario de Windows: " + Environment.UserName);
                logErrores.GraboSaltoLinea();


                LogInformacionEjecucion.GraboSaltoLinea();
                LogInformacionEjecucion.grabarLineaLogErrores("------------------------------------------");
                LogInformacionEjecucion.grabarLineaLogErrores("------------------------------------------");
                LogInformacionEjecucion.grabarLineaLogErrores("# Producto: " + DatosAccesorios.getInstance("").getPrograma());
                LogInformacionEjecucion.grabarLineaLogErrores("# Versión del producto: " + DatosAccesorios.getInstance("").getVersion());
                LogInformacionEjecucion.grabarLineaLogErrores("# Usuario PF: " + DatosAccesorios.getInstance("").getUsuario());
                LogInformacionEjecucion.grabarLineaLogErrores("# PC: " + Environment.MachineName);
                LogInformacionEjecucion.grabarLineaLogErrores("# Usuario de Windows: " + Environment.UserName);



                //valido los filtros 
                ValidoFiltrosOperacion(filtros);

                List<string> errores = operaciones.validacionesGeneralesAplicacion(filtros);
                //si hay errores en las validaciones generales, se corta la ejecucion del programa
                if (errores.Count > 0)
                {
                    LogInformacionEjecucion.graboLineaLog("Errores detectados en las validaciones generales:");
                    LogInformacionEjecucion.GraboSaltoLinea();
                    LogInformacionEjecucion.graboColeccionStringSinFecha(errores);

                    //logErrores.graboLineaLog("Errores detectados en las validaciones generales:");                    
                    //logErrores.GraboSaltoLinea();
                    //logErrores.graboColeccionStringSinFecha(errores);                    
                    throw new Exception("Se han detectado errores en las validaciones generales de la aplicacion, la operación ha sido cancelada");

                }

                //cargo la lista de valores a procesar
                List<RegistroPagoFacil> registros = new ArchivosTXT().lecturaDatosArchivo(filtros.archivoCSV, out EstadoLectura);



                if (registros.Count == 0)
                {
                    throw new Exception("No se han encontrado registros procesables.");

                }

                //en caso de no producirse errores, se graban los comprobantes uno a uno
                LogInformacionEjecucion.GraboSaltoLinea();
                //LogInformacionEjecucion.graboLineaLog("Inicio procesamiento masivo.");
                LogInformacionEjecucion.graboLineaLog("Validaciones de registros.");
                //proceso uno a uno los comprobantes

                foreach (RegistroPagoFacil reg in registros)
                {

                     try
                    {
                         //valido errores del registro
                         errores = operaciones.validacionesIndividualesRegistro(reg);
                       
                         //si hay errores, los informo y marco que hubo errores
                        if (errores.Count > 0)
                        {
                            erroresIndividuales = true;
                            LogInformacionEjecucion.GraboSaltoLinea();
                            LogInformacionEjecucion.graboLineaLog("Linea: " + reg.linea.ToString() + " - Errores detectados:");
                            LogInformacionEjecucion.grabarLineaLogErrores("Linea: " + reg.linea.ToString() + " - Errores detectados:");
                            LogInformacionEjecucion.graboColeccionStringSinFecha(errores);


                            logErrores.GraboSaltoLinea();
                            logErrores.graboLineaLog("Linea: " + reg.linea.ToString() + " - Errores detectados:");
                            logErrores.graboColeccionStringSinFecha(errores);

                        }

                    }
                    catch (Exception ex2)
                    {
                         //cualquier excepcion no controlada se captura
                         erroresIndividuales = true;
                         LogInformacionEjecucion.GraboSaltoLinea();
                         LogInformacionEjecucion.graboLineaLog("Linea: " + reg.linea.ToString() + " -Error al procesar registros.");
                         LogInformacionEjecucion.graboLineaLog(ex2.Message);
                         LogInformacionEjecucion.grabarLineaLogErrores("Linea: " + reg.linea.ToString() + " -Error al procesar registros.");
                         LogInformacionEjecucion.GraboExcepcionLog(ex2);

                         logErrores.GraboSaltoLinea();
                         logErrores.graboLineaLog("Linea: " + reg.linea.ToString() + " -Error al procesar registros.");
                         logErrores.graboLineaLog(ex2.Message);
                         logErrores.GraboSaltoLinea();

                     }
                   
                
                }


                //si hay errores, se informa en el archivo log y al usuario, cortando la ejecución.
                if (erroresIndividuales == true)
                {
                    //LogInformacionEjecucion.graboLineaLog("No se ha procesado el archivo por errores detectados en los registros informados. Por favor, chequee el log de ejecución para más detalles.");
                    LogInformacionEjecucion.graboLineaLog("No se ha procesado el archivo por errores detectados en los registros informados.");
                    //new ArchivosTXT().renombrarArchivo(filtros.archivoCSV, destinoArchivoProcesado);                  
                }
                else
                {
                    //si no hay errores, por cada registro se genera un recibo en IMAC

                    foreach (RegistroPagoFacil reg in registros)
                    {

                        //proceso el registro
                        try
                        {
                            operaciones.creacionReciboIMAC(filtros, reg);
                        }
                        catch (Exception ex)
                        {
                            erroresIndividuales = true;

                            LogInformacionEjecucion.GraboSaltoLinea();
                            LogInformacionEjecucion.graboLineaLog("Linea: " + reg.linea.ToString() + " -Error al procesar registro:");
                            LogInformacionEjecucion.graboLineaLog(ex.Message);
                            LogInformacionEjecucion.grabarLineaLogErrores("Linea: " + reg.linea.ToString() + " -Error al procesar registro:");
                            LogInformacionEjecucion.GraboExcepcionLog(ex);

                            logErrores.GraboSaltoLinea();
                            logErrores.graboLineaLog("Linea: " + reg.linea.ToString() + " -Error al procesar registro.");
                            logErrores.graboLineaLog(ex.Message);
                            logErrores.GraboSaltoLinea();
                            break;

                        }


                    }

                }




                if (erroresIndividuales == false)
                {
                    LogInformacionEjecucion.graboLineaLog("Copia de archivo procesado y eliminación de la copia procesada.");
                    new ArchivosTXT().renombrarArchivo(filtros.archivoCSV, destinoArchivoProcesado);
                }

                return erroresIndividuales;


         
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                LogInformacionEjecucion.GraboSaltoLinea();
                LogInformacionEjecucion.graboLineaLog("Fin de procesamiento.");
            }
        }


    }
}
