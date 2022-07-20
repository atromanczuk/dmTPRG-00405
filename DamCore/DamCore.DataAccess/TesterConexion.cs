using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using DamCore.DamExceptions;


namespace DamCore.DataAccess
{
    public class TesterConexion
    {
        private static TesterConexion instance;

        protected TesterConexion()
        { }

        public static TesterConexion getInstance()
        {
            if (instance == null)
                instance = new TesterConexion();
            return instance;
        }


        public void TestearConexion()
        {
            try
            {
                ////CREO UNA CONEXION NUEVA UTILIZANDO AL PROVEEDOR DE CONEXION
                using (SqlConnection cnn = new SqlConnection(ProveedorConexion.getInstance().ObtenerStringConexion()))
                {
                    //ABRO LA CONEXION
                    cnn.Open();
                    //CIERRO LA CONEXION
                    cnn.Close();
                }
            }

            catch (SqlException SqlE)
            {
                throw new BusinessException(SqlE.Message, SqlE);
            }

        }
    }
}
