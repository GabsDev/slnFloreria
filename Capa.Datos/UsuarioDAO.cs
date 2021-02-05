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
    public class UsuarioDAO
    {
        public Usuario ObtenerUsuario(string login, string password)
        {
            Usuario oUsuario = null;
            SqlConnection conn = null;
            try
            {
                conn = Conexion.establecerConexion();
                string sql = @"select Perfil from tusuario where Login = @login and Contraseña = @password";

                SqlCommand comando = new SqlCommand();
                comando.CommandText = sql;
                comando.Connection = conn;
                comando.Parameters.AddWithValue("@login", login);
                comando.Parameters.AddWithValue("@password", password);
                comando.CommandType = CommandType.Text;
                SqlDataReader lectura = comando.ExecuteReader();
                while (lectura.Read())
                {
                    int _perfil = int.Parse(lectura["Perfil"].ToString());
                    oUsuario = new Usuario()
                    {
                        Login = login,
                        Contraseña = password,
                        Perfil = new PerfilDAO().ObtenerTodos(_perfil)
                    };
                }

            }
            catch (Exception) { throw; }
            finally
            {
                conn.Close();
            }
            return oUsuario;
        }

        public DataSet GetPerfiles()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                 {

                 };
            return FDBHelper.ExecuteDataSet("usp_Usuario_GetPerfiles", dbParams);

        }

        public DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Usuario_GetAll", dbParams);

        }


        public int Insertar(Usuario usuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]    
                {
                    FDBHelper.MakeParam("@Login", SqlDbType.VarChar, 0, usuario.Login),
                    FDBHelper.MakeParam("@Contraseña", SqlDbType.VarChar, 0, usuario.Contraseña),
                    FDBHelper.MakeParam("@PerfilId", SqlDbType.SmallInt, 0, usuario.Perfil.ID_Perfil),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Usuario_Insertar", dbParams));

        }

        public int Actualizar(Usuario usuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, usuario.ID_Cedula),
                    FDBHelper.MakeParam("@Login", SqlDbType.VarChar, 0, usuario.Login),
                    FDBHelper.MakeParam("@Contraseña", SqlDbType.VarChar, 0, usuario.Contraseña),
                    FDBHelper.MakeParam("@PerfilId", SqlDbType.SmallInt, 0, usuario.Perfil.ID_Perfil),
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Usuario_Actualizar", dbParams));

        }

        public int Eliminar(Usuario usuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, usuario.ID_Cedula),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Usuario_Eliminar", dbParams));

        }





    }
}
