using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
    public class Perfil
    {
        public int ID_Perfil { get; set; } 

        public string Descripcion { get; set; }

        public List<Permiso> Lista_Permisos { get; set; }

        public Perfil()
        {
            Lista_Permisos = new List<Permiso>();
        }

        public bool buscarMenu(string opcionMenu)
        {
            foreach (Permiso item in Lista_Permisos)
            {
                if (item.NombreSistema.Equals(opcionMenu))
                {
                    return item.Estado;
                }
            }
            return false;
        }
    }
}
