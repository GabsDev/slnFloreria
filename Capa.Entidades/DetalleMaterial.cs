using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
    public class DetalleMaterial
    {
        public Producto Producto { get; set; }

        public Material Material { get; set; }

        public string UnidadMedidad { get; set; }

        public int Cantidad { get; set; }

        public double Costo { get; set; }


    }
}
