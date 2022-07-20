using DamCore.Common;
using DamCore.DamExceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DamCore.DataAccess
{




    public class operacionesParametrosGenerales
    {

        public void ActualizaciónParametroGeneral(ParametrosGenerales parametro, string programa)
        {
            try
            {
                string sVlSql;

                sVlSql = @"UPDATE dmSIST_PARM
                            SET PARM_VALOR = '" + parametro.getValorParametro()
                                                +
                         "' WHERE PARM_PROGRAMA ='" + programa
                                                + "'" +
                         " AND PARM_NOMBRE = '" + parametro.getNombreParametro() + "';";

                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sVlSql, cnn);

                    cmd.CommandTimeout = 0;

                    cmd.ExecuteNonQuery();

                }

            }
            catch (SqlException SqlE)
            {
                throw new BusinessException(SqlE.Message, SqlE);
            }


        }




        public List<ParametrosGenerales> ListarParámetrosGenerales(string sPlPrograma)
        {
            try
            {
                string sVlSql;
                List<ParametrosGenerales> ListAux = new List<ParametrosGenerales>();
                //ParametrosGenerales aux;

                sVlSql = @"SELECT PARM_NOMBRE,
	                        PARM_DESCRIPCION,
	                        PARM_VALOR,
	                        PARM_TIPO_DATO,
	                        PARM_EDITABLE ,
                            PARM_ES_PASSWORD,
                            PARM_REQUIERE_VALIDACION
                            FROM dmSIST_PARM
                            WHERE PARM_PROGRAMA = '" + sPlPrograma + "'";
                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sVlSql, cnn);

                    cmd.CommandTimeout = 0;

                    SqlDataReader drPar = cmd.ExecuteReader();


                    if (drPar.HasRows)
                    {
                        while (drPar.Read())
                        {

                            ParametrosGenerales aux = new ParametrosGenerales(drPar["PARM_NOMBRE"].ToString(),
                                                                                drPar["PARM_VALOR"].ToString(),
                                                                                drPar["PARM_DESCRIPCION"].ToString(),
                                                                                drPar["PARM_TIPO_DATO"].ToString(),
                                                                                drPar["PARM_EDITABLE"].ToString(),
                                                                                (drPar["PARM_ES_PASSWORD"].ToString() == "1") ? true : false,
                                                                                (drPar["PARM_REQUIERE_VALIDACION"].ToString() == "1") ? true : false);
                            ListAux.Add(aux);
                        }
                    }

                }

                return ListAux;

            }
            catch (SqlException sqlE)
            {
                throw new BusinessException(sqlE.Message, sqlE);
            }


        }



        public ParametrosGenerales lecturaParametro(string parametro, string programa)
        {

            try
            {
                ParametrosGenerales aux = null;
                string sVlSql;

                sVlSql = @"SELECT PARM_NOMBRE,
	                        PARM_DESCRIPCION,
	                        PARM_VALOR,
	                        PARM_TIPO_DATO,
	                        PARM_EDITABLE,
                            PARM_ES_PASSWORD,
                            PARM_REQUIERE_VALIDACION
                            FROM dmSIST_PARM
                            WHERE PARM_NOMBRE = '" + parametro + "' AND  PARM_PROGRAMA = '" + programa + "'";


                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sVlSql, cnn);

                    cmd.CommandTimeout = 0;

                    SqlDataReader drPar = cmd.ExecuteReader();


                    if (drPar.HasRows)
                    {
                        while (drPar.Read())
                        {

                            aux = new ParametrosGenerales(drPar["PARM_NOMBRE"].ToString(),
                                                                               drPar["PARM_VALOR"].ToString(),
                                                                               drPar["PARM_DESCRIPCION"].ToString(),
                                                                               drPar["PARM_TIPO_DATO"].ToString(),
                                                                               drPar["PARM_EDITABLE"].ToString(),
                                                                               (drPar["PARM_ES_PASSWORD"].ToString() == "1") ? true : false,
                                                                               (drPar["PARM_REQUIERE_VALIDACION"].ToString() == "1") ? true : false);


                        }
                    }
                    else
                    {
                        throw new BusinessException("No se ha definido al parámetro '" + parametro.ToUpper() + "'. Deberá definirlo para utilizar la operación.", new Exception());
                    }


                }

                return aux;


            }
            catch (SqlException sqlE)
            {
                throw new BusinessException(sqlE.Message, sqlE);
            }


        }
    }
}
