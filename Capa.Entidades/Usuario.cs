using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Contraseña { get; set; }
        public Perfil Perfil { get; set; }
        public int ID_Cedula { get; set; }

    }
}
