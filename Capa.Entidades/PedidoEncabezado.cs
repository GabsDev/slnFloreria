using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
    public class PedidoEncabezado
    {
        public int Id_Pedido { set; get; }
        public Cliente Id_Cliente { set; get; }

        public string Direccion { get; set; }

        public string Autorizado { get; set; }

        public double Costo { get; set; }

        public DateTime Fecha { get; set; }
    }
}
