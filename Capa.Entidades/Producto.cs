using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
    public class Producto
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public Categoria Categoria { get; set; }

        public double Precio { get; set; }

        public byte[] Imagen { get; set; }

        public List<DetalleMaterial> Req_Productos { get; set; }
        public Producto()
        {
            Categoria = new Categoria();
            Req_Productos = new List<DetalleMaterial>();
            Imagen = null;


        }

        public DetalleMaterial AgregarMaterial(DetalleMaterial pDetalleMaterial)
        {
         
            pDetalleMaterial.Costo = pDetalleMaterial.Material.Precio * pDetalleMaterial.Cantidad;

            Req_Productos.Add(pDetalleMaterial);

            return pDetalleMaterial;
        }


        public double CalcularPrecioProducto()
        {
            double costo = 0;
            foreach (var item in Req_Productos)
            {
                costo += item.Costo;
            }

            return costo;
        }

    }
}
