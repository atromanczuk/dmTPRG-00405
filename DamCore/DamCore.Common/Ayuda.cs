using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common
{

    //ENUMERACION PARA INDICAR TIPO DE AYUDA REQUERIDO
    public enum TipoAyuda
    {
        Division = 1,
        Sucursal = 2,
        Cliente = 3,
        Proveedor = 4,
        Articulo = 5
    };


    public class Ayuda
    {
        private string Codigo;
        private string Descripcion;

        public Ayuda(string sPlCodigo,
                     string sPlDescripcion)
        {
            Codigo = sPlCodigo;
            Descripcion = sPlDescripcion;
        }


        public string getcodigo()
        {
            return Codigo;
        }

        public string getDescripcion()
        {
            return Descripcion;
        }

    }


}
