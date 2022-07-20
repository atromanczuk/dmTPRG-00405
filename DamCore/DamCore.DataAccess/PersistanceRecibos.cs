using DamCore.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DamCore.DataAccess
{
    public class PersistanceRecibos
    {
        public List<string> validacionesIndividualesRegistro( RegistroPagoFacil registro)
        {
        try 
	        {
                string sql = "spdm_VALIDACIONESREGISTROSIMAC_CCO_E505_0340A";
                 SqlCommand cmd;
                 SqlDataReader dr;
                 List<string> errores = new List<string>();

                 using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                    {
                        cnn.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = cnn;
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@CLIENTE", SqlDbType.VarChar));
                        cmd.Parameters.Add(new SqlParameter("@FECHA", SqlDbType.VarChar));
                        cmd.Parameters.Add(new SqlParameter("@IMPORTE", SqlDbType.VarChar));

                        cmd.Parameters["@CLIENTE"].Value = registro.cliente;
                        cmd.Parameters["@FECHA"].Value = registro.fecha;
                        cmd.Parameters["@IMPORTE"].Value = registro.importe;

                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            errores.Add(dr[0].ToString());
                        }
                        cmd.Dispose();

                        cnn.Close();
                        cnn.Dispose();
                    }


                 return errores;

	        }
	        catch (Exception)
	        {
		
		        throw;
	        }
        
        }

        public void creacionReciboIMAC(filtrosOperacion filtros, RegistroPagoFacil registro)
        {
            try
            {
                string sql = "spdm_ALTARECIBOSIMAC_CCO_E505_0340A";
                SqlCommand cmd;
           
                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new SqlParameter("@CLIENTE", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@IMPORTE", SqlDbType.Decimal));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@PROGRAMA", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@DIVISION", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@SUCURSAL", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@TIPO", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@CC", SqlDbType.VarChar));

                    cmd.Parameters["@CLIENTE"].Value = registro.cliente;
                    cmd.Parameters["@FECHA"].Value = registro.fecha;
                    cmd.Parameters["@IMPORTE"].Value = registro.importe;
                    cmd.Parameters["@DESCRIPCION"].Value = registro.descripcion;
                    cmd.Parameters["@PROGRAMA"].Value = DatosAccesorios.getInstance().getPrograma();
                    cmd.Parameters["@USUARIO"].Value = DatosAccesorios.getInstance().getUsuario();

                    if (filtros.division.Length == 0)
                        cmd.Parameters["@DIVISION"].Value = DBNull.Value;
                    else
                        cmd.Parameters["@DIVISION"].Value = filtros.division;

                    if (filtros.sucursal.Length == 0)
                        cmd.Parameters["@SUCURSAL"].Value = DBNull.Value;
                    else
                        cmd.Parameters["@SUCURSAL"].Value = filtros.sucursal;

                    if (filtros.tipo.Length == 0)
                        cmd.Parameters["@TIPO"].Value = DBNull.Value;
                    else
                        cmd.Parameters["@TIPO"].Value = filtros.tipo;

                    if (filtros.cuentaContable.Length == 0)
                        cmd.Parameters["@CC"].Value = DBNull.Value;
                    else
                        cmd.Parameters["@CC"].Value = filtros.cuentaContable;
                    cmd.ExecuteNonQuery();

                                    

                    cmd.Dispose();

                    cnn.Close();
                    cnn.Dispose();
                }

              
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<string> validacionesGeneralesAplicacion(filtrosOperacion filtros)
        {

            try
            {
                List<string> errores = new List<string>();

                string sql = "spdm_VALIDACIONESGENERALES_CCO_E505_0340A";
                SqlCommand cmd;
                SqlDataReader dr;

                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    cnn.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add(new SqlParameter("@PROGRAMA", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@USUARIO", SqlDbType.VarChar));

                    cmd.Parameters.Add(new SqlParameter("@DIVISION", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@SUCURSAL", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@TIPO", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@CC", SqlDbType.VarChar));

                    cmd.Parameters["@PROGRAMA"].Value = DatosAccesorios.getInstance().getPrograma();
                    cmd.Parameters["@USUARIO"].Value = DatosAccesorios.getInstance().getUsuario();

                    if(filtros.division.Length == 0)
                        cmd.Parameters["@DIVISION"].Value = DBNull.Value;
                    else
                        cmd.Parameters["@DIVISION"].Value = filtros.division;

                    if (filtros.sucursal.Length == 0)
                        cmd.Parameters["@SUCURSAL"].Value = DBNull.Value;
                    else
                        cmd.Parameters["@SUCURSAL"].Value = filtros.sucursal;

                    if (filtros.tipo.Length == 0)
                        cmd.Parameters["@TIPO"].Value = DBNull.Value;
                    else
                        cmd.Parameters["@TIPO"].Value = filtros.tipo;

                    if (filtros.cuentaContable.Length == 0)
                        cmd.Parameters["@CC"].Value = DBNull.Value;
                    else
                        cmd.Parameters["@CC"].Value = filtros.cuentaContable;
 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        errores.Add(dr[0].ToString());
                    }

                    dr.Close();
                    dr.Dispose();

                    cmd.Dispose();

                    cnn.Close();
                    cnn.Dispose();
                }

                return errores;
            }
            catch (Exception)
            {

                throw;
            }

        }


      
    }
}
