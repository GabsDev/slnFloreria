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
    public class MaterialBLL
    {
        public int Guardar(Material material)
        {
            MaterialDAO oMaterial = new MaterialDAO();

            try
            {
                if (material.Id == 0)
                {
                    return oMaterial.Insertar(material);

                }

                else
                {
                    return oMaterial.Actualizar(material);

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int eliminar(Material material)
        {
            MaterialDAO oMaterial = new MaterialDAO();

            try
            {
                return oMaterial.Eliminar(material);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public DataSet listado()
        {
            MaterialDAO oMaterial = new MaterialDAO();
            try
            {
                return oMaterial.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Material ObtenerMaterial(int pId)
        {
            MaterialDAO _MaterialDAO = new MaterialDAO();
            return _MaterialDAO.ObtenerMaterialPorCodigo(pId);
        }


    }
}
