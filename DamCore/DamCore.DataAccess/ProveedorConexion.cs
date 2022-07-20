using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data.Odbc;
using DamCore.DamExceptions;
using DamCore.Common;

namespace DamCore.DataAccess
{
    public class ProveedorConexion
    {
        private static ProveedorConexion instance;
        private static String stringConexion;

        protected ProveedorConexion()
        {
            stringConexion = "";
        }

        public static ProveedorConexion getInstance()
        {
            if (instance == null)
                instance = new ProveedorConexion();
            return instance;
        }


        public string ObtenerStringConexion()
        {

            try
            {
                stringConexion = "";

                    //"ODBC;DSN=21interfases;DATABASE=;UID=sa;PWD=sasa;"
                    if (DatosConexion.getInstance().getTipoConexion().ToString() != "ODBC")
                    {
                        stringConexion = "Server=" + DatosConexion.getInstance().getServidorOleDb() +
                                          ";Database=" + DatosConexion.getInstance().getDaseDatosOleDb() +
                                          ";User Id=" + DatosConexion.getInstance().getUsuarioDb() +
                                          ";Password=" + DatosConexion.getInstance().getPasswordDb() + ";";


                    }

                    else
                    {

                        stringConexion = "DSN=" + DatosConexion.getInstance().getDSN() +
                                         ";Uid=" + DatosConexion.getInstance().getUsuarioDb() +
                                         ";Pwd=" + DatosConexion.getInstance().getPasswordDb() + ";";

                        OdbcConnection connAux = new OdbcConnection(stringConexion);
                        connAux.Open();

                        stringConexion = "Server=" + connAux.DataSource +
                                      ";Database=" + connAux.Database +
                                      ";User Id=" + DatosConexion.getInstance().getUsuarioDb() +
                                      ";Password=" + DatosConexion.getInstance().getPasswordDb() + ";";


                        connAux.Close();
                        connAux.Dispose();
                    }

              
                return stringConexion;
            }

            catch (Exception SqlE)
            {
                throw new BusinessException("Error en ProveedorConexion.ObtenerConexion: " + SqlE.Message, SqlE);
            }
        }



    }
}
