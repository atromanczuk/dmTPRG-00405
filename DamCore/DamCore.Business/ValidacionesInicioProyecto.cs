using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DamCore.DamExceptions;
using DamCore.Common;
using DamCore.DataAccess;



namespace DamCore.Business
{
    public static class ValidacionesInicioProyecto
    {

        public static Int32 validoParametros(string[] args)
        {
            Int32 cantidadParametros = 0;


            cantidadParametros = args.Length;

            if (cantidadParametros == 0)
            {
                throw new BusinessException("La aplicación no admite la ejecución por fuera de Plataforma ERP.", new Exception());
            }



            if (!(cantidadParametros == 7 || cantidadParametros == 1))
            {
                //throw new BusinessException("No se recibieron la cantidad esperada de parametros." + System.Environment.NewLine + "Esperado: DSN/BaseDatos UsuarioPF PasswordDB UsuarioDB Servidor BaseDatos TipoConexion(1 = ODBC, 2 = OLEDB)", new Exception());
                throw new BusinessException("No se recibieron la cantidad esperada de parametros.", new Exception());
            }


            return cantidadParametros;

        }


        public static void SeteoDatosConectividad(string[] args, string programa,string ubicacion)
        {

            try
            {
                DatosConexion.getInstance(args[0], args[4], args[5], args[3], args[2], args[6]);
                DatosAccesorios.getInstance(args[1]);
                DatosAccesorios.getInstance().setPrograma(programa);
                DatosAccesorios.getInstance().setUbicacion(ubicacion);

            }
            catch (Exception Ex)
            {
                throw new BusinessException(Ex.Message, Ex);
            }

        }



        public static void ValidoConectividad()
        {
            try
            {
                Conectividad.GetInstance().Testearconexion();

            }
            catch (BusinessException Ex)
            {
                throw new BusinessException(Ex.Message, Ex);
            }


        }

    }
}
