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
    public class ProvedorBLL
    {
        public int Guardar(Provedor provedor)
        {
            ProvedorDAO oProvedor = new ProvedorDAO();

            try
            {
                if (provedor.Id == 0)
                {
                    return oProvedor.Insertar(provedor);

                }

                else
                {
                    return oProvedor.Actualizar(provedor);

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int eliminar(Provedor provedor)
        {
            ProvedorDAO oProvedor = new ProvedorDAO();

            try
            {
                return oProvedor.Eliminar(provedor);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public DataSet listado()
        {
            ProvedorDAO oProvedor = new ProvedorDAO();
            try
            {
                return oProvedor.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
