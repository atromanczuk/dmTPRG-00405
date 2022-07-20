using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common
{
    public class LogAutomatico
    {

        private string path;
        private string nombre;
        private string extension;

        private static LogAutomatico instance;

        protected LogAutomatico(string Path,
                             string Nombre,
                             string Extension)
        {
            this.path = Path;
            this.nombre = Nombre;
            this.extension = Extension;
        }

        public static LogAutomatico getInstance(string Path,
                                                string Nombre,
                                                string Extension)
        {
            if (instance == null)
            {
                instance = new LogAutomatico(Path, Nombre, Extension);
            }

            return instance;

        }

        public string getArchivo()
        {
            return this.path + @"\" + this.nombre + "." + this.extension;
        }

        public static void cerrarInstancia()
        {
            instance = null;
        }
        public static bool instanciaAbierta()
        {
            return instance != null;
        }

    }

}
