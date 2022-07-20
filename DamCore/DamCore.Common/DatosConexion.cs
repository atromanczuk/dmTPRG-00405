using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common
{
    public class DatosConexion
    {
        private string DSN;
        private string servidorOleDb;
        private string baseDatosOleDb;
        private string usuarioDb;
        private string passwordDb;
        private string tipoConexion;

        private static DatosConexion instance;

        //FUNCION QUE REEMPLAZA AL CONSTRUCTOR
        public static DatosConexion getInstance(string sPlDSN = "",
                                                 string sPlServidorOledb = "",
                                                 string sPlBaseDatosOledb = "",
                                                 string sPlUsuarioDB = "",
                                                 string sPlPassword = "",
                                                 string sPlTipoConexion = "")
        {
            if (instance == null)
                instance = new DatosConexion(sPlDSN,
                                             sPlServidorOledb,
                                             sPlBaseDatosOledb,
                                             sPlUsuarioDB,
                                             sPlPassword,
                                             sPlTipoConexion);


            return instance;
        }

        //CONSTRUCTOR PRIVADO: PARA EVITAR QUE SE CREEN INSTANCIAS NUEVAS, UTILIZANDO EL PATRON DE DISEÑO SINGLETON
        protected DatosConexion(string sPlDSN,
                                 string sPlServidorOledb,
                                 string sPlBaseDatosOledb,
                                 string sPlUsuarioDB,
                                 string sPlPassword,
                                 string sPlTipoConexion)
        {

            this.DSN = sPlDSN;
            this.servidorOleDb = sPlServidorOledb;

            if (sPlTipoConexion == "2")
            {
                this.tipoConexion = "OleDB";
                this.baseDatosOleDb = sPlDSN;
            }
            else
            {
                this.tipoConexion = "ODBC";
                this.baseDatosOleDb = sPlBaseDatosOledb;
            }

            this.usuarioDb = sPlUsuarioDB;
            this.passwordDb = sPlPassword;

        }

        //FUNCIONES PARA ACCEDER AL CONTENIDO DE LA CLASE
        public string getDSN()
        {
            return this.DSN;
        }

        public string getServidorOleDb()
        {
            return this.servidorOleDb;
        }

        public string getDaseDatosOleDb()
        {
            return this.baseDatosOleDb;
        }

        public string getUsuarioDb()
        {
            return this.usuarioDb;
        }

        public string getPasswordDb()
        {
            return this.passwordDb;
        }

        public string getTipoConexion()
        {
            return this.tipoConexion;
        }

    }
}
