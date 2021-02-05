namespace Capa.Entidades
{
    public class PedidoDetalle
    {
        public int Id_Pedido { set; get; }
        public Producto _Producto { set; get; }
        public int Cantidad { set; get; }
        public double Precio { set; get; }
        public int No_Linea { get; set; }



    }
}