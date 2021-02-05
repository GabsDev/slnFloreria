using Capa.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Datos
{
    public class PedidoDAO
    {
        public int GetNumeroPedido()
        {

            SqlConnection conn = null;
            try
            {
                conn = Conexion.establecerConexion();
                string sql = @"SELECT NEXT VALUE FOR SecuenciaNoPedido";
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conn;
                comando.CommandText = sql;

                DataSet ds = null;
                Conexion miConexion = null;
                ds = miConexion.ExecuteReader(comando, "query");
                
                // Extraer la tabla 
                DataTable dt = ds.Tables[0];

                int vInsertardo = comando.ExecuteNonQuery();

                return int.Parse(dt.Rows[0][0].ToString());           

            }
            catch (SqlException)
            {
                throw;
            }
            finally { conn.Close(); }

        }


        public void SavePedido(Pedido pPedido)
        {

            List<IDbCommand> ListaCommands = new List<IDbCommand>();
            string sql = @"  INSERT INTO [dbo].[TPedido]
                                       ([Id_Pedido]
                                       ,[Id_Cliente]
                                       ,[Direccion]
                                       ,[Autorizado]
                                       ,[Costo])
                                 VALUES
                                        (@Id_Pedido,
                                        @Id_Cliente,
                                        @Direccion,  
                                        @Autorizado, 
                                        @Costo) ";


            SqlCommand cmdEncabezado = new SqlCommand();
            // Pasar parámetros
            cmdEncabezado.Parameters.AddWithValue("@Id_Pedido", pPedido._PedidoEncabezado.Id_Pedido);
            cmdEncabezado.Parameters.AddWithValue("@Id_Cliente", pPedido._PedidoEncabezado.Id_Cliente);
            cmdEncabezado.Parameters.AddWithValue("@Direccion", pPedido._PedidoEncabezado.Direccion);
            cmdEncabezado.Parameters.AddWithValue("@Autorizado", pPedido._PedidoEncabezado.Autorizado);
            cmdEncabezado.Parameters.AddWithValue("@Costo", pPedido._PedidoEncabezado.Costo);
            cmdEncabezado.CommandText = sql;
            cmdEncabezado.CommandType = CommandType.Text;
            ListaCommands.Add(cmdEncabezado);


            foreach (var item in pPedido._PedidoDetalle)
            {
                SqlCommand cmdDetalle = new SqlCommand();
                sql = @"   

                            INSERT INTO [dbo].[TPedido_Producto]
                                       ([Id_Pedido]
                                       ,[Id_Producto]
                                       ,[Cantidad]
                                       ,[Precio]
                                       ,[No_Linea])
                                 VALUES
                                       (@Id_Pedido, 
                                       @Id_Producto,
                                       @Cantidad,
                                       @Precio,
                                       @No_Linea) ";


                cmdDetalle.Parameters.AddWithValue("@Id_Pedido", pPedido._PedidoEncabezado.Id_Pedido);
                cmdDetalle.Parameters.AddWithValue("@Id_Producto", item._Producto.Id);
                cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                cmdDetalle.Parameters.AddWithValue("@Precio", item.Precio);
                cmdDetalle.Parameters.AddWithValue("@No_Linea", item.No_Linea);


                cmdDetalle.CommandText = sql;
                ListaCommands.Add(cmdDetalle);
            }

            Conexion db = new Conexion();
            db.ExecuteNonQuery(ListaCommands, IsolationLevel.ReadCommitted);
        
            
        }

        public void SavePedidoFactura(Pedido pPedido)
        {

            List<IDbCommand> ListaCommands = new List<IDbCommand>();
            string sql = @"  INSERT INTO [dbo].[TFacturaPedido]
                                       ([Id_Pedido]
                                       ,[Fecha]
                                       ,[Subtotal]
                                       ,[Descuento]
                                       ,[Impuesto]
                                       ,[Total]
                                       ,[Descripcion]
,)
                                 VALUES
                                        (@Id_Pedido,
                                        @Fecha,  
                                        @Subtotal, 
                                        @Descuento,  
                                        @Impuesto, 
                                        @Total,  
                                        @Descripcion) ";


            SqlCommand cmdEncabezado = new SqlCommand();
            // Pasar parámetros
            cmdEncabezado.Parameters.AddWithValue("@Id_Pedido", pPedido._PedidoEncabezado.Id_Pedido);
            cmdEncabezado.Parameters.AddWithValue("@Fecha", pPedido._PedidoEncabezado.Fecha);
            cmdEncabezado.Parameters.AddWithValue("@Subtotal", pPedido.ObtenerSubTotal());
            cmdEncabezado.Parameters.AddWithValue("@Descuento", 0);
            cmdEncabezado.Parameters.AddWithValue("@Impuesto", pPedido.ObtenerImpuesto());
            cmdEncabezado.Parameters.AddWithValue("@Total", pPedido.ObtenerTotalColones());
            cmdEncabezado.Parameters.AddWithValue("@Descripcion", pPedido._PedidoEncabezado.Id_Cliente.Nombre);
            cmdEncabezado.CommandText = sql;
            cmdEncabezado.CommandType = CommandType.Text;
            ListaCommands.Add(cmdEncabezado);
            Conexion db = new Conexion();
            db.ExecuteNonQuery(ListaCommands, IsolationLevel.ReadCommitted);


        }

    }
}
