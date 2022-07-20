using DamCore.Common;
using DamCore.DamExceptions;
using DamCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Business
{
    public class BusinessParametrosGenerales
    {

        public void validarProveedor(string Proveedor)
        {
            try
            {


            }

            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }


        }


        public string BuscoDescripcionObjeto(string nombre, TipoObjeto Tipo, string filtroOptativo = "")
        {
            string descripcion = "";

            try
            {
                //operacionesPF busquedaDesc = new operacionesPF();
                //switch (Tipo)
                //{

                //    case TipoObjeto.ListaPrecio:
                //        descripcion = busquedaDesc.descripcionListaPrecio(nombre);
                //        break;
                //    //case TipoObjeto.Proveedor:
                //    //    descripcion = busquedaDesc.descripcionProveedor(nombre);
                //    //    break;
                //}

                return "";

            }

            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }

        }

        public Dictionary<string, string> ValidacionGeneralParámetros(string sPlPrograma)
        {
            try
            {
                List<ParametrosGenerales> ListadoParametros = new operacionesParametrosGenerales().ListarParámetrosGenerales(sPlPrograma);
                //Articulos atributosArticulos = new Articulos();
                Dictionary<string, string> parametros = new Dictionary<string, string>();
                //valido los ítems de los parámetros

                foreach (ParametrosGenerales aux in ListadoParametros)
                {

                    parametros.Add(aux.getNombreParametro(), aux.getValorParametro());
                }

                return parametros;


            }

            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }


        }

        public List<ParametrosGenerales> ListarParametros(string sPlPrograma)
        {

            try
            {

                return new operacionesParametrosGenerales().ListarParámetrosGenerales(sPlPrograma);
            }

            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }


        public void ValidoParámetro(ParametrosGenerales parametro)
        {

            try
            {

                if (parametro.getValorParametro().Length == 0)
                    throw new BusinessException("Por favor, indique un valor para el parámetro " + parametro.getNombreParametro() + ".", new Exception());


                //valido tipo de dato


            }

            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }

        }


        public void ActualizoParametro(ParametrosGenerales parametro, string programa)
        {
            try
            {
                new operacionesParametrosGenerales().ActualizaciónParametroGeneral(parametro, programa);

            }

            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }

        }


        public ParametrosGenerales buscoParametro(string parametro, string sPlPrograma)
        {

            try
            {
                return new operacionesParametrosGenerales().lecturaParametro(parametro, sPlPrograma);


            }

            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }

    }

}
