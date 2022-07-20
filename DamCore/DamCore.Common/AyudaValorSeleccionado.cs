using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common
{
    public class AyudaValorSeleccionado
    {


        private string Codigo;
        private string Descripcion;



        private static AyudaValorSeleccionado instance;

        protected AyudaValorSeleccionado(string sPlCodigo,
                                          string sPlDescripcion)

        {
            this.Codigo = sPlCodigo;
            this.Descripcion = sPlDescripcion;
        }



        //FUNCION QUE REEMPLAZA AL CONSTRUCTOR
        public static AyudaValorSeleccionado getInstance(string sPlCodigo = "",
                                                         string sPlDescripcion = "")
        {
            if (instance == null)
                instance = new AyudaValorSeleccionado(sPlCodigo,
                                             sPlDescripcion);

            else
            {
                instance.Codigo = sPlCodigo;
                instance.Descripcion = sPlDescripcion;
            
            }
            return instance;
        }




        public string getcodigo()
        {
            return this.Codigo;
        }

        public string getDescripcion()
        {
            return this.Descripcion;
        }

    }
}
