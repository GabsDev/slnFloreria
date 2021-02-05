using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
    public class Permiso
    {
        public int ID_Permiso { get; set; }
        public string NombreSistema { get; set; }
        public string Descripcion { get; set; }
        public int Padre { get; set; }
        public bool Estado { get; set; }
    }
}
