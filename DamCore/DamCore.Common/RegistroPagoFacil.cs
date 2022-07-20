using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common
{
    public class RegistroPagoFacil
    {
        public string cliente { get; set; }
        public string fecha { get; set; }
        public string importe { get; set; }
        public string descripcion{ get; set; }
        public Int64 linea { get; set; }


    }
}
