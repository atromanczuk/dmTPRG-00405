using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DamCore.DataAccess;
using DamCore.Common;
using DamCore.DamExceptions;

namespace DamCore.Business
{
    public class Conectividad
    {

        private static Conectividad instance;

        protected Conectividad()
        { }


        public static Conectividad GetInstance()
        {
            if (instance == null)
                instance = new Conectividad();
            return instance;
        }

        public void Testearconexion()
        {
            try
            {
                TesterConexion.getInstance().TestearConexion();

            }

            catch (BusinessException Be)
            {
                throw new BusinessException(Be.Message, Be);
            }



        }


    }
}
