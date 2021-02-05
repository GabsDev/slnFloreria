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
    public class CategoriaBLL
    {
        public int Guardar(Categoria categoria)
        {
            CategoriaDAO oCategoria = new CategoriaDAO();

            try
            {
                if (categoria.Id == 0)
                {
                    return oCategoria.Insertar(categoria);

                }

                else
                {
                    return oCategoria.Actualizar(categoria);

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int eliminar(Categoria categoria)
        {
            CategoriaDAO oCategoria = new CategoriaDAO();

            try
            {
                return oCategoria.Eliminar(categoria);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public DataSet listado()
        {
            CategoriaDAO oCategoria = new CategoriaDAO();
            try
            {
                return oCategoria.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
