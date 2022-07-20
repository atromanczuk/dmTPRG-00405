using DamCore.Common;
using DamCore.DamExceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DamCore.DataAccess
{
    public class operacionesPF
    {
        private string programa;



        public void VerificoPermisosUsuario(string Programa)
        {
            try
            {

                string sVlSql;
                SqlCommand cmd;
                SqlDataReader dr;


                sVlSql = @"spdm_VerificacionPermisosUsuario @PROGRAMA,@USUARIO";

                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = sVlSql;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@PROGRAMA", System.Data.SqlDbType.VarChar));
                    cmd.Parameters["@PROGRAMA"].Value = DatosAccesorios.getInstance("").getPrograma();
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar));
                    cmd.Parameters["@USUARIO"].Value = DatosAccesorios.getInstance().getUsuario();


                    cmd.ExecuteNonQuery();
                }

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }



        }




        public string ObtengoContraseñaUsuario(String Usuario)
        {
            try
            {
                string sVlSql;

                sVlSql = @"SELECT ISNULL(USUA_PASS_CPBTESFC,'')
                            FROM SEGU_USUA
                            WHERE USUA_USUARIO = @FILTRO ";  //'" + Valor + @"'";

                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sVlSql, cnn);

                    cmd.Connection = cnn;
                    cmd.CommandText = sVlSql;

                    cmd.Parameters.Add(new SqlParameter("@FILTRO", System.Data.SqlDbType.VarChar));
                    cmd.Parameters["@FILTRO"].Value = Usuario;

                    cmd.CommandTimeout = 0;

                    SqlDataReader drVal = cmd.ExecuteReader();


                    if (drVal.HasRows)
                    {
                        drVal.Read();
                        return drVal[0].ToString();
                    }

                    else
                    {
                        return "";
                    }
                }


            }
            catch (SqlException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }



        public bool validoExistenciaNumeradorStock(Int32 Division, Int32 Sucursal, string Tipo)
        {

            try
            {


                string sVlSql;
                SqlCommand cmd;
                SqlDataReader dr;
                bool ExisteNumerador;
                ExisteNumerador = false;

                sVlSql = @"SELECT * 
                            FROM STOC_NUST
                            WHERE NUST_DIVISION = @DIVISION
                            AND NUST_SUCURSAL_IMP =@SUCURSAL
                            AND NUST_TIPO_COM = @TIPO
                        ";

                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = sVlSql;

                    cmd.Parameters.Add(new SqlParameter("@TIPO", System.Data.SqlDbType.VarChar));
                    cmd.Parameters["@TIPO"].Value = Tipo;

                    cmd.Parameters.Add(new SqlParameter("@DIVISION", System.Data.SqlDbType.Int));
                    cmd.Parameters["@DIVISION"].Value = Division;

                    cmd.Parameters.Add(new SqlParameter("@SUCURSAL", System.Data.SqlDbType.Int));
                    cmd.Parameters["@SUCURSAL"].Value = Sucursal;




                    cmd.CommandType = CommandType.Text;

                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        ExisteNumerador = true;
                    }
                    else
                    {
                        ExisteNumerador = false;
                    }
                }


                return ExisteNumerador;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public bool validoFechaTope(Int32 Division, String Sistema)
        {
            try
            {


                string sVlSql;
                SqlCommand cmd;
                SqlDataReader dr;
                bool FechaHabilitada;
                FechaHabilitada = false;

                sVlSql = @"SELECT *
                            FROM SIST_FTOP
                            WHERE 
                            FTOP_SISTEMA = @SISTEMA
                            AND FTOP_DIVISION = @DIVISION
                            AND CONVERT(VARCHAR,GETDATE(),112) BETWEEN CONVERT(VARCHAR,FTOP_FECHA_DESDE,112) AND CONVERT(VARCHAR,FTOP_FECHA_HASTA,112)
                        ";

                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = sVlSql;
                    cmd.Parameters.Add(new SqlParameter("@SISTEMA", System.Data.SqlDbType.VarChar));
                    cmd.Parameters["@SISTEMA"].Value = Sistema;

                    cmd.Parameters.Add(new SqlParameter("@DIVISION", System.Data.SqlDbType.Int));
                    cmd.Parameters["@DIVISION"].Value = Division;

                    cmd.CommandType = CommandType.Text;

                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        FechaHabilitada = true;
                    }
                    else
                    {
                        FechaHabilitada = false;
                    }
                }


                return FechaHabilitada;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }


        public UsuarioPF getUsuario(UsuarioPF usuario)
        {
            try
            {


                string sVlSql;
                SqlCommand cmd;
                SqlDataReader dr;
                UsuarioPF usuarioAux = null;

                sVlSql = @"SELECT USUA_USUARIO AS USUARIO, ISNULL(USUA_PASS_CPBTESFC,'') AS CONTRASENIA
                            FROM SEGU_USUA
                            WHERE USUA_USUARIO = @FILTRO
                        ";
                usuarioAux = null;

                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sVlSql;
                    cmd.Parameters.Add(new SqlParameter("@FILTRO", System.Data.SqlDbType.VarChar));
                    cmd.Parameters["@FILTRO"].Value = usuario.getUsuario();


                    cmd.CommandType = CommandType.Text;

                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();

                        usuarioAux = new UsuarioPF(dr["USUARIO"].ToString(),
                                                    dr["CONTRASENIA"].ToString());
                    }
                }


                return usuarioAux;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }


        public operacionesPF(string Programa = "")
        {
            this.programa = Programa;
        }


        public string descripcionProveedor(string Valor)
        {
            try
            {
                string sVlSql;

                sVlSql = @"SELECT ISNULL(PROV_NOMBRE,'') 
                            FROM CPAG_PROV
                            WHERE PROV_PROVEEDOR = @FILTRO 
                            AND NOT EXISTS (SELECT 1 FROM dmCOFA_PPLP WHERE PPLP_PROVEEDOR = PROV_PROVEEDOR)";  //'" + Valor + @"'";

                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sVlSql, cnn);

                    cmd.Connection = cnn;
                    cmd.CommandText = sVlSql;

                    cmd.Parameters.Add(new SqlParameter("@FILTRO", System.Data.SqlDbType.VarChar));
                    cmd.Parameters["@FILTRO"].Value = Valor;

                    cmd.CommandTimeout = 0;

                    SqlDataReader drVal = cmd.ExecuteReader();


                    if (drVal.HasRows)
                    {
                        drVal.Read();
                        return drVal[0].ToString();
                    }

                    else
                    {
                        return "";
                    }
                }


            }
            catch (SqlException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }



        }


        public string descripcionUsuario(string Valor)
        {
            try
            {
                string sVlSql;

                sVlSql = @"SELECT ISNULL(USUA_NOMBRE,'') 
                            FROM SEGU_USUA
                            WHERE USUA_USUARIO = @FILTRO ";  //'" + Valor + @"'";

                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sVlSql, cnn);

                    cmd.Connection = cnn;
                    cmd.CommandText = sVlSql;

                    cmd.Parameters.Add(new SqlParameter("@FILTRO", System.Data.SqlDbType.VarChar));
                    cmd.Parameters["@FILTRO"].Value = Valor;

                    cmd.CommandTimeout = 0;

                    SqlDataReader drVal = cmd.ExecuteReader();


                    if (drVal.HasRows)
                    {
                        drVal.Read();
                        return drVal[0].ToString();
                    }

                    else
                    {
                        return "";
                    }
                }


            }
            catch (SqlException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }



        }



        public string descripcionListaPrecio(string Valor)
        {
            try
            {
                string sVlSql;

                sVlSql = @"SELECT ISNULL(LIPV_NOMBRE,'') 
                            FROM VENT_LIPV
                            WHERE CONVERT(VARCHAR,LIPV_LISTA_PRECVTA) = @FILTRO ";  //'" + Valor + @"'";

                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sVlSql, cnn);

                    cmd.Connection = cnn;
                    cmd.CommandText = sVlSql;

                    cmd.Parameters.Add(new SqlParameter("@FILTRO", System.Data.SqlDbType.VarChar));
                    cmd.Parameters["@FILTRO"].Value = Valor;

                    cmd.CommandTimeout = 0;

                    SqlDataReader drVal = cmd.ExecuteReader();


                    if (drVal.HasRows)
                    {
                        drVal.Read();
                        return drVal[0].ToString();
                    }

                    else
                    {
                        return "";
                    }
                }


            }
            catch (SqlException ex)
            {
                throw new BusinessException(ex.Message, ex);
            }



        }
    }

}
