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
    public class ClienteDAO
    {
        public DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Cliente_GetAll", dbParams);

        }


        public int Insertar(Cliente cliente)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Nombre", SqlDbType.VarChar, 0, cliente.Nombre),
                    FDBHelper.MakeParam("@Telefono", SqlDbType.VarChar, 0, cliente.Telefono),
                    FDBHelper.MakeParam("@Email", SqlDbType.VarChar, 0, cliente.Email),
                    FDBHelper.MakeParam("@Domicilio", SqlDbType.VarChar, 0, cliente.Domicilio),
                    
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Cliente_Insertar", dbParams));

        }

        public int Actualizar(Cliente cliente)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, cliente.Id),
                    FDBHelper.MakeParam("@Nombre", SqlDbType.VarChar, 0, cliente.Nombre),
                    FDBHelper.MakeParam("@Telefono", SqlDbType.VarChar, 0, cliente.Telefono),
                    FDBHelper.MakeParam("@Email", SqlDbType.VarChar, 0, cliente.Email),
                    FDBHelper.MakeParam("@Domicilio", SqlDbType.VarChar, 0, cliente.Domicilio),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Cliente_Actualizar", dbParams));

        }

        public int Eliminar(Cliente cliente)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, cliente.Id),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Cliente_Eliminar", dbParams));

        }

        public Cliente GetCliente(int pId)
        {
            Cliente oCliente = null;
            DataSet ds = null;
            string sql = @" select * from  [dbo].[Cliente] where Id_Cliente = @Id_Cliente ";

            SqlCommand command = new SqlCommand();
            // Pasar parámetros
            command.Parameters.AddWithValue("@Id_Cliente", pId);


            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            Conexion db = new Conexion();
            ds = db.ExecuteReader(command, "query");
            

            // Extraer la tabla 
            DataTable dt = ds.Tables[0];


            if (dt.Rows.Count > 0)
            {
                oCliente = new Cliente()
                {
                    Id = int.Parse(dt.Rows[0]["ID_Cliente"].ToString()),
                    Nombre = dt.Rows[0]["Nombre"].ToString().Trim(),
                    Telefono = dt.Rows[0]["Telefono"].ToString(),
                    Email = dt.Rows[0]["Email"].ToString()

                };

            }

            return oCliente;

        }


        //public IEnumerable<ICliente> GetClienteByName(string pNombre)
        //{
        //    DataSet ds = null;
        //    List<ICliente> lista = new List<ICliente>();

        //    string sql = @" select * from  [dbo].[Cliente] 
        //                    where Nombre + Apellidos like @Nombre ";



        //    SqlCommand command = new SqlCommand();
        //    // Pasar parámetros
        //    command.Parameters.AddWithValue("@Nombre", pNombre);


        //    command.CommandText = sql;
        //    command.CommandType = CommandType.Text;

        //    using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection(Usuario.GetInstance().Nombre, Usuario.GetInstance().Contrasena)))
        //    {
        //        ds = db.ExecuteReader(command, "query");
        //    }

        //    // Extraer la tabla 
        //    DataTable dt = ds.Tables[0];

        //    ICliente oCliente = null;
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow item in dt.Rows)
        //        {
        //            oCliente = new Cliente()
        //            {
        //                Id_Cliente = int.Parse(item["Id_Cliente"].ToString()),
        //                Nombre = item["Nombre"].ToString().Trim(),
        //                Apellidos = item["Apellidos"].ToString(),
        //                Correo = item["Correo"].ToString()

        //            };

        //            lista.Add(oCliente);
        //        }



        //    }

        //    return lista;

        //}





    }
}
