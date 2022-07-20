using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Common
{
    public class UsuarioPF
    {
        private string usuario;
        private string ContraseñaComprobantes;

        public UsuarioPF(string Usuario,
                            string ContraseñaComprobantes)
        {
            this.usuario = Usuario;
            this.ContraseñaComprobantes = ContraseñaComprobantes;
        }

        public string getUsuario()
        {
            return this.usuario;
        }
        public string getContraseñaComprobantes()
        {
            return this.ContraseñaComprobantes;
        }

    }
}
