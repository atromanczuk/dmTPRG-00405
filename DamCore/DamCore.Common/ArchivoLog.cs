using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common
{
    public class ArchivoLog
    {
        private string path;
        private string nombre;
        private string extension;

        private static ArchivoLog instance;

        protected ArchivoLog(string Path,
                             string Nombre,
                             string Extension)
        {
            this.path = Path;
            this.nombre = Nombre;
            this.extension = Extension;
        }

        public static ArchivoLog getInstance(string Path,
                                                string Nombre,
                                                string Extension)
        {
            if (instance == null)
            {
                instance = new ArchivoLog(Path, Nombre, Extension);
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

    }

}
