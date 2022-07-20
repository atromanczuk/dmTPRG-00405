using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common
{
    public class ArchivoLogErrores
    {

        private string path;
        private string nombre;
        private string extension;

        private static ArchivoLogErrores instance;

        protected ArchivoLogErrores(string Path,
                             string Nombre,
                             string Extension)
        {
            this.path = Path;
            this.nombre = Nombre;
            this.extension = Extension;
        }

        public static ArchivoLogErrores getInstance(string Path,
                                                string Nombre,
                                                string Extension)
        {
            if (instance == null)
            {
                instance = new ArchivoLogErrores(Path, Nombre, Extension);
            }

            return instance;

        }

        public string getArchivo()
        {
            return this.path + @"\" + this.nombre;// +"." + this.extension;
        }

        public static void cerrarInstancia()
        {
            instance = null;
        }

    }
}
