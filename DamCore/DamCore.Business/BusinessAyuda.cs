using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DamCore.Common;
using DamCore.DamExceptions;
using DamCore.DataAccess;


namespace DamCore.Business
{
    public class BusinessAyuda
    {

               TipoAyuda BusquedaPor;

               public BusinessAyuda(TipoAyuda tipoDeAyuda)
        {

            BusquedaPor = tipoDeAyuda;

        }

        public List<Ayuda> EjecutarAyuda(string sPlValorFiltro)
        {
            try
            {
                List<Ayuda> listaDeAyuda = new List<Ayuda>();

                filtrosAyuda filtrosAyuda = new filtrosAyuda(sPlValorFiltro);

                //cargo la lista con lo informado como filtros
                //PersistanceAyuda LecturaOD = new PersistanceAyuda();

                //switch (BusquedaPor)
                //{
                //    case TipoAyuda.Division:
                //        listaDeAyuda = LecturaOD.ArmoListaDivisiones(filtrosAyuda);
                //        break;
                //    case TipoAyuda.Evento:
                //        listaDeAyuda = LecturaOD.ArmoListaTipos(filtrosAyuda);
                //        break;
                //}


                return listaDeAyuda;

            }
            catch (BusinessException be)
            {
                throw new BusinessException(be.Message, be);
            }

            catch (Exception exc)
            {
                throw new BusinessException(exc.Message, exc);
            }

        }


    }
}
