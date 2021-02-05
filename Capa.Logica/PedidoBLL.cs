using Capa.Datos;
using Capa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Logica
{
    public class PedidoBLL
    {

        public Pedido _Pedido;

        public PedidoBLL()
        {
            _Pedido = new Pedido();
        
        }


        public void AgregarEncabezado(PedidoEncabezado pPedidoEncabezado)
        {
            PedidoDAO _PedidoDAO = new PedidoDAO();
            pPedidoEncabezado.Id_Pedido = _PedidoDAO.GetNumeroPedido();
            pPedidoEncabezado.Fecha = DateTime.Now;
            _Pedido.AgregarEncabezado(pPedidoEncabezado);
        }

        public bool IsEncabezadoAsignado()
        {
            return _Pedido._PedidoEncabezado.Id_Pedido > 0 ? true : false;
        }

        public PedidoDetalle AgregarDetalle(PedidoDetalle pPedidoDetalle)
        {
            PedidoDetalle oPedidoDetalle = _Pedido.AgregarDetalle(pPedidoDetalle);

            return oPedidoDetalle;

        }

        public void AsignarCliente(Cliente _Cliente)
        {
            _Pedido.AsignarCliente(_Cliente);
        }

        public double ObtenerSubTotal()
        {
            return _Pedido.ObtenerSubTotal();
        }

        public double ObtenerImpuesto()
        {
            return _Pedido.ObtenerImpuesto();
        }

        public double ObtenerTotalColones()
        {
            return ObtenerSubTotal() + ObtenerImpuesto();
        }

        public int SalvarPedido()
        {
            PedidoDAO _PedidoDAO = new PedidoDAO();

            if (_Pedido._PedidoDetalle.Count == 0)
            {
                throw new Exception("No ha incluido el detalle de los Productos de la Pedido !");
            }
            else
            {
                _PedidoDAO.SavePedido(_Pedido);
                _PedidoDAO.SavePedidoFactura(_Pedido);

                return _Pedido._PedidoEncabezado.Id_Pedido;
            }
        }
    }
}
