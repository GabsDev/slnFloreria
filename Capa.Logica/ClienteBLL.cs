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
    public class ClienteBLL
    {
        public int Guardar(Cliente cliente)
        {
            ClienteDAO oCliente = new ClienteDAO();
           
            try
            {
                if (cliente.Id == 0)
                {
                     return oCliente.Insertar(cliente);
                    
                }
               
                else
                {
                   return  oCliente.Actualizar(cliente);
                   
                }
                   
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int eliminar(Cliente cliente)
        {
            ClienteDAO oCliente = new ClienteDAO();
            
            try
            {
                return oCliente.Eliminar(cliente);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public DataSet listado()
        {
            ClienteDAO oCliente = new ClienteDAO();
            try
            {
                return oCliente.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente ObtenerCliente(int pId)
        {
            ClienteDAO _ClienteDAO = new ClienteDAO();
            return _ClienteDAO.GetCliente(pId);
        }


        //public IEnumerable<Cliente> ObtenerClientePorNombre(string pNombre)
        //{
        //    ClienteDAO _ClienteDAO = new ClienteDAO();
        //    return _ClienteDAO.GetClienteByName(pNombre);
        //}
    }
}
