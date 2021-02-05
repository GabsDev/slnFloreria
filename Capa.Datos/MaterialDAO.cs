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
    public class MaterialDAO
    {
        public DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Material_GetAll", dbParams);

        }


        public int Insertar(Material material)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Descripcion", SqlDbType.VarChar, 0, material.Descripcion),
                    FDBHelper.MakeParam("@Uni_Medida", SqlDbType.VarChar, 0, material.Uni_Medida),
                    FDBHelper.MakeParam("@Can_Min", SqlDbType.VarChar, 0, material.Cant_Min),
                    FDBHelper.MakeParam("@Can_Max", SqlDbType.VarChar, 0, material.Cant_Max),
                    FDBHelper.MakeParam("@Precio", SqlDbType.VarChar, 0, material.Precio),
                    FDBHelper.MakeParam("@Ganancia", SqlDbType.VarChar, 0, material.Ganancia),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Material_Insertar", dbParams));

        }

        public int Actualizar(Material material)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, material.Id),
                    FDBHelper.MakeParam("@Descripcion", SqlDbType.VarChar, 0, material.Descripcion),
                    FDBHelper.MakeParam("@Uni_Medida", SqlDbType.VarChar, 0, material.Uni_Medida),
                    FDBHelper.MakeParam("@Can_Min", SqlDbType.VarChar, 0, material.Cant_Min),
                    FDBHelper.MakeParam("@Can_Min", SqlDbType.VarChar, 0, material.Cant_Max),
                    FDBHelper.MakeParam("@Precio", SqlDbType.VarChar, 0, material.Precio),
                    FDBHelper.MakeParam("@Ganancia", SqlDbType.VarChar, 0, material.Ganancia),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Material_Actualizar", dbParams));

        }

        public int Eliminar(Material material)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, material.Id),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Material_Eliminar", dbParams));

        }

        public  Material ObtenerMaterialPorCodigo(int codigoMaterial)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Capa.UI.Properties.Settings.ConnectionString"].ToString()))
            {
                SqlCommand commando = new SqlCommand("usp_Material_SelectPorCodigo", conn);
                commando.CommandType = CommandType.StoredProcedure;

                commando.Parameters.AddWithValue("@Codigo", codigoMaterial);

                conn.Open();

                SqlDataReader reader = commando.ExecuteReader();

                while (reader.Read())
                {
                    return ConstruirMaterial(reader);
                }
            }
            return null;
        }

        public  Material ConstruirMaterial(IDataReader reader)
        {
            Material material = new Material();

            material.Id = Convert.ToInt32(reader["ID_Material"].ToString());
            material.Descripcion = reader["Descripcion"].ToString();
            material.Uni_Medida = reader["Uni_Medida"].ToString();
            material.Cant_Min = Convert.ToInt32(reader["Can_Min"].ToString());
            material.Cant_Max = Convert.ToInt32(reader["Can_Max"].ToString());
            material.Precio = Convert.ToDouble(reader["Precio"].ToString());
           // material.Ganancia = Convert.ToInt32(reader["Ganacia"].ToString());

            return material;
        }

    }
}
