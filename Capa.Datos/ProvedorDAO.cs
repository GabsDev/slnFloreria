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
    public class ProvedorDAO
    {
        public DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Provedor_GetAll", dbParams);

        }


        public int Insertar(Provedor provedor)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Descripcion", SqlDbType.VarChar, 0, provedor.Descripcion),
                    FDBHelper.MakeParam("@Telefono", SqlDbType.VarChar, 0, provedor.Telefono),
                    FDBHelper.MakeParam("@Email", SqlDbType.VarChar, 0, provedor.Email),
                    FDBHelper.MakeParam("@Domicilio", SqlDbType.VarChar, 0, provedor.Domicilio),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Provedor_Insertar", dbParams));

        }

        public int Actualizar(Provedor provedor)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, provedor.Id),
                    FDBHelper.MakeParam("@Descripcion", SqlDbType.VarChar, 0, provedor.Descripcion),
                    FDBHelper.MakeParam("@Telefono", SqlDbType.VarChar, 0, provedor.Telefono),
                    FDBHelper.MakeParam("@Email", SqlDbType.VarChar, 0, provedor.Email),
                    FDBHelper.MakeParam("@Domicilio", SqlDbType.VarChar, 0, provedor.Domicilio),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Provedor_Actualizar", dbParams));

        }

        public int Eliminar(Provedor provedor)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, provedor.Id),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Provedor_Eliminar", dbParams));

        }
    }
}
