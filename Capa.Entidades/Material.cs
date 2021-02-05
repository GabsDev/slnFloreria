using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
    public class Material
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string Uni_Medida { get; set; }

        public int Cant_Min { get; set; }

        public int Cant_Max { get; set; }

        public double Precio { get; set; }

        public double Ganancia { get; set; }


    }
}
