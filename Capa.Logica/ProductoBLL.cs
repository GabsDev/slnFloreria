using Capa.Datos;
using Capa.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Logica
{
    public class ProductoBLL
    {
        

        //public int Guardar(Producto producto)
        //{
        //    ProductoDAO oProducto = new ProductoDAO();

        //    try
        //    {
        //        if (producto.Id == 0)
        //        {
        //            return oProducto.Insertar(producto);

        //        }

        //        else
        //        {
        //            return oProducto.Actualizar(producto);

        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public int eliminar(Producto producto)
        {
            ProductoDAO oProducto = new ProductoDAO();

            try
            {
                return oProducto.Eliminar(producto);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public DataSet listado()
        {
            ProductoDAO oProducto = new ProductoDAO();
            try
            {
                return oProducto.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

   
        public Producto ObtenerProducto(int pId)
        {
            ProductoDAO _ProductoDAO = new ProductoDAO();
            return _ProductoDAO.GetProducto(pId);
        }

        public void SalvarProducto(Producto oProducto)
        {
            ProductoDAO _ProductoDAO = new ProductoDAO();

            if (oProducto.Req_Productos.Count == 0)
            {
                throw new Exception("No ha incluido el detalle de los Productos del Pedido !");
            }
            else
            {
                _ProductoDAO.SaveProducto(oProducto);
               
            }
        }




    }
}
