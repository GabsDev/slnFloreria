using Capa.Entidades;
using Capa.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Logica
{
   public class PerfilBLL
    {
        public  List<Perfil> obtenerPerfiles()
        {
            PerfilDAO oPerfil = new PerfilDAO();
            return oPerfil.ObtenerPerfiles();

        }
    }
}
