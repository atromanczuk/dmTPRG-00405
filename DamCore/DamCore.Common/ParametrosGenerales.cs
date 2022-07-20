using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common
{
    public enum TipoObjeto
    {
        ListaPrecio = 1

    };

    public class ParametrosGenerales
    {

        string NombreParametro;
        string ValorParametro;
        string DescripcionParametro;
        string TipoDeDatoParametro;
        string EsEditable;
        bool esContraseña;
        bool requiereValidacion;


        public ParametrosGenerales(string sPlNombreParametro,
                            string sPlValorParametro,
                            string sPlDescripcionParametro,
                            string sPlTipoDeDatoParametro,
                            string bPlEsEditable,
                            bool EsContraseña,
                            bool RequiereValidacion)
        {
            NombreParametro = sPlNombreParametro;
            ValorParametro = sPlValorParametro;
            DescripcionParametro = sPlDescripcionParametro;
            TipoDeDatoParametro = sPlTipoDeDatoParametro;
            EsEditable = bPlEsEditable;
            esContraseña = EsContraseña;
            this.requiereValidacion = RequiereValidacion;
        }


        public bool getEsContraseña()
        {
            return this.esContraseña;
        }


        public string getNombreParametro()
        {
            return NombreParametro;
        }

        public string getValorParametro()
        {
            return ValorParametro;
        }


        public string getDescripcionParametro()
        {
            return DescripcionParametro;
        }

        public string getTipoDeDatoParametro()
        {
            return TipoDeDatoParametro;
        }

        public string getEsUtilizable()
        {
            return EsEditable;
        }

        public bool getRequiereValidacion()
        {
            return this.requiereValidacion;
        }
        
    }

}
