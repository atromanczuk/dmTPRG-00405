using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common
{
    public class DatosAccesorios
    {

        private string usuario;

        private static DatosAccesorios instance;
        private static string programa;
        private static string version;
        private static string UbicacionPrograma;

        //FUNCION QUE REEMPLAZA AL CONSTRUCTOR
        public static DatosAccesorios getInstance(string Usuario = "")
        {
            if (instance == null)
                instance = new DatosAccesorios(Usuario);
            return instance;
        }


        protected DatosAccesorios(string Usuario)
        {
            this.usuario = Usuario;
        }


        public string getUsuario()
        {
            return this.usuario;
        }

        public void setPrograma(string Programa)
        {
            programa = Programa;
        }


        public string getUbicacion()
        {
            return UbicacionPrograma;
        }

        public void setUbicacion(string UBicacion)
        {
            UbicacionPrograma = UBicacion;
        }


        public string getPrograma()
        {
            return programa;

        }
        public void setVersion(string VersionProg)
        {
            version = VersionProg;
        }

        public string getVersion()
        {
            return version;
        }
    }
}
