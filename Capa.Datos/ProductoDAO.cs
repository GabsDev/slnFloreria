using Capa.Datos.Persistencia;
using Capa.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Datos
{
    public class ProductoDAO
    {
        public DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Producto_GetAll", dbParams);

        }

        public void SaveProducto(Producto pProducto)
        {

            List<IDbCommand> ListaCommands = new List<IDbCommand>();
            string sql = @"  INSERT INTO [dbo].[TProducto]
                                       ([ID_Producto]
                                       ,[Descripcion]
                                       ,[ID_Categoria]
                                       ,[Precio]
                                       ,[Imagen]

                                       )
                                 VALUES
                                        (@Id_Producto,
                                        @Descripcion,
                                        @Id_Categoria, 
                                        @Precio,
                                        @Imagen)";


            SqlCommand cmdEncabezado = new SqlCommand();
            // Pasar parámetros
            cmdEncabezado.Parameters.AddWithValue("@Id_Producto", pProducto.Id);
            cmdEncabezado.Parameters.AddWithValue("@Descripcion", pProducto.Descripcion);
            cmdEncabezado.Parameters.AddWithValue("@Id_Categoria", pProducto.Categoria.Id);
            cmdEncabezado.Parameters.AddWithValue("@Precio", pProducto.Precio);
            cmdEncabezado.Parameters.AddWithValue("@Imagen", pProducto.Imagen ?? (object)DBNull.Value);
            cmdEncabezado.CommandText = sql;
            cmdEncabezado.CommandType = CommandType.Text;
            ListaCommands.Add(cmdEncabezado);


            foreach (var item in pProducto.Req_Productos)
            {
                SqlCommand cmdDetalle = new SqlCommand();
                sql = @"   

                            INSERT INTO [dbo].[TProducto_Material]
                                       ([ID_Producto]
                                       ,[ID_Material]
                                       ,[Cantidad]
                                       )
                                 VALUES
                                       (@ID_Producto, 
                                       @ID_Material,
                                       @Cantidad,
                                      ) ";


                cmdDetalle.Parameters.AddWithValue("@ID_Producto", item.Producto.Id);
                cmdDetalle.Parameters.AddWithValue("@ID_Material", item.Material.Id);
                cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
    

                cmdDetalle.CommandText = sql;
                ListaCommands.Add(cmdDetalle);
            }

                    
            using (IDataBase db = FactoryDatabase.CreateDataBase(ConfigurationManager.ConnectionStrings["Capa.UI.Properties.Settings.ConnectionString"].ConnectionString))
            {
                db.ExecuteNonQuery(ListaCommands, IsolationLevel.ReadCommitted);
            }
        }


        //public int Insertar(Producto producto)
        //{
        //    SqlParameter[] dbParams = new SqlParameter[]
        //        {
        //            //, , , , , , , , 
        //            FDBHelper.MakeParam("@CategoriaId", SqlDbType.Int, 0, producto.Categoria.Id),
        //            FDBHelper.MakeParam("@Descripcion", SqlDbType.VarChar, 0, producto.Descripcion),
        //            FDBHelper.MakeParam("@PrecioVenta", SqlDbType.Decimal, 0, producto.Precio),
        //            FDBHelper.MakeParam("@Imagen", SqlDbType.Image, 0, producto.Imagen)
        //        };
        //    return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_Producto_Insertar", dbParams));

        //}




        //public int Actualizar(Producto producto)
        //{
        //    SqlParameter[] dbParams = new SqlParameter[]
        //        {
        //            FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, producto.Id),
        //            FDBHelper.MakeParam("@CategoriaId", SqlDbType.Int, 0, producto.Categoria.Id),
        //            FDBHelper.MakeParam("@Descripcion", SqlDbType.VarChar, 0, producto.Descripcion),
        //            FDBHelper.MakeParam("@PrecioVenta", SqlDbType.Decimal, 0, producto.Precio),
        //            FDBHelper.MakeParam("@Imagen", SqlDbType.Image, 0, producto.Imagen)
        //        };
        //    return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_Producto_Actualizar", dbParams));

        //}

        public int Eliminar(Producto producto)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, producto.Id),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Data_Producto_Eliminar", dbParams));

        }



        public Producto GetProducto(int Id_Producto)
        {

            DataSet ds = null;
            string sql = @" select * from  [dbo].[TProducto] where ID_Producto = @Id_Producto ";



            SqlCommand command = new SqlCommand();
            // Pasar parámetros
            command.Parameters.AddWithValue("@Id_Producto", Id_Producto);


            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            Conexion db = new Conexion();
            {
                ds = db.ExecuteReader(command, "query");
            }

            // Extraer la tabla 
            DataTable dt = ds.Tables[0];

            Producto oProducto = null;
            if (dt.Rows.Count > 0)
            {

                byte[] pdf = new byte[0];
                oProducto = new Producto()
                {

                    Id = int.Parse(dt.Rows[0]["ID_Producto"].ToString()),
                    Descripcion = dt.Rows[0]["Descripcion"].ToString().Trim(),
                    Precio = int.Parse(dt.Rows[0]["Precio"].ToString())


                };

                if (dt.Rows[0]["Imagen"] != DBNull.Value)
                    oProducto.Imagen = (byte[])dt.Rows[0]["Imagen"];
                else
                    oProducto.Imagen = null;


            }

            return oProducto;
        }




    }
}
