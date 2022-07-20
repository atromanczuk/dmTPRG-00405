using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common

{
    public class filtrosAyuda
    {
        string valorFiltro;

        public filtrosAyuda(string sPlValorFiltro)
        {
            valorFiltro = sPlValorFiltro;
        }

        public string getValorFiltroAyuda()
        {
            return valorFiltro;
        }

    }
}
