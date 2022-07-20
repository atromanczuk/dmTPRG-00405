using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.DamExceptions
{
    public class BusinessException:Exception
    {
        //constructor predeterminado
        private BusinessException()
        { 
        
        }
        //contructor personalizado
        public BusinessException(string sPlDescripcion,
                                  Exception Inner)
            : base(sPlDescripcion, Inner)

        { 
        
        }

    }
}
