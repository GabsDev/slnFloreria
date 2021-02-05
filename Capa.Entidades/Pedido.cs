using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Entidades
{
     public class Pedido
    {
        public PedidoEncabezado _PedidoEncabezado { set; get; }
        public List<PedidoDetalle> _PedidoDetalle { set; get; }
        private Cliente _Cliente { set; get; }
       
        public  Pedido()
        {

            _PedidoEncabezado = new PedidoEncabezado();
            _PedidoDetalle = new List<PedidoDetalle>();

        }

      
        public void AgregarEncabezado(PedidoEncabezado pPedidoEncabezado)
        {

             _PedidoEncabezado = pPedidoEncabezado;
        }


        public PedidoDetalle AgregarDetalle(PedidoDetalle pPedidoDetalle)
        {

            pPedidoDetalle.Id_Pedido = _PedidoEncabezado.Id_Pedido;
            pPedidoDetalle.Precio = pPedidoDetalle._Producto.Precio * pPedidoDetalle.Cantidad;
           
            _PedidoDetalle.Add(pPedidoDetalle);

            return pPedidoDetalle;

        }

        public void AsignarCliente(Cliente pCliente)
        {
            _Cliente = pCliente;
        }


        public PedidoEncabezado ObtenerEncabezadoFactura()
        {
            return _PedidoEncabezado;
        }

        public List<PedidoDetalle> ObtenerDetalleFactura()
        {
            return _PedidoDetalle;
        }



        public double ObtenerSubTotal()
        {
            double monto = 0D;
            foreach (var item in _PedidoDetalle)
            {
                monto += item.Precio * item.Cantidad;
            }

            return monto;
        }

      
        public double ObtenerImpuesto()
        {
            return ObtenerSubTotal() * .13;
        }

       

        public double ObtenerTotalColones()
        {
            return ObtenerSubTotal() * 1.13;
        }

        
    }
}
