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
    public class PerfilDAO
    {
        public Perfil ObtenerTodos(int perfil)
        {
            Perfil lista = null;
            SqlConnection conn = null;
            try
            {
                conn = Conexion.establecerConexion();
                string sql = @"select Tpermiso.ID_Permiso,NombreSistema,tpermiso.descripcion,Padre,tperfil_Permiso.estado,tPerfil.descripcion as desperfil
                                from tperfil_permiso,tpermiso,tperfil 
                                where tperfil_permiso.ID_Perfil = tperfil.ID_Perfil and
                                tperfil_permiso.ID_Permiso = tpermiso.ID_Permiso and 
                                tperfil.ID_Perfil = @Perfil order by Padre";

                SqlCommand comando = new SqlCommand();
                comando.CommandText = sql;
                comando.Connection = conn;
                comando.Parameters.AddWithValue("@Perfil", perfil);
                comando.CommandType = CommandType.Text;
                SqlDataReader lectura = comando.ExecuteReader();
                if (lectura.HasRows)
                {
                    Perfil oPerfil = new Perfil();
                    oPerfil.ID_Perfil = Convert.ToInt32(perfil.ToString());

                    while (lectura.Read())
                    {
                        oPerfil.Descripcion = lectura["desperfil"].ToString();
                        oPerfil.Lista_Permisos.Add(new Permiso()
                        {
                            ID_Permiso = int.Parse(lectura["ID_Permiso"].ToString()),
                            NombreSistema = lectura["NombreSistema"].ToString(),
                            Descripcion = lectura["Descripcion"].ToString(),
                            Padre = (lectura["Padre"].ToString().Length != 0 ? int.Parse(lectura["Padre"].ToString()) : -1),
                            Estado = bool.Parse(lectura["estado"].ToString())
                        });
                    }
                    lista = oPerfil;
                }
            }
            catch (Exception) { throw; }
            finally
            {
                conn.Close();
            }
            return lista;
        }



        public List<Perfil> ObtenerPerfiles()
        {
            List<Perfil> lista = new List<Perfil>();
            SqlConnection conn = null;
            try
            {
                conn = Conexion.establecerConexion();
                string sql = @"select Tpermiso.ID_Permiso,NombreSistema,tpermiso.descripcion,Padre,tperfil_Permiso.estado,tPerfil.descripcion as desperfil, tPerfil.ID_Perfil as ID_Perfil
                                from tperfil_permiso,tpermiso,tperfil 
                                where tperfil_permiso.ID_Perfil = tperfil.ID_Perfil and
                                tperfil_permiso.ID_Permiso = tpermiso.ID_Permiso 
                                order by Padre";

                SqlCommand comando = new SqlCommand();
                comando.CommandText = sql;
                comando.Connection = conn;
                comando.CommandType = CommandType.Text;
                SqlDataReader lectura = comando.ExecuteReader();
                if (lectura.HasRows)
                {
                    Perfil oPerfil = new Perfil();


                    while (lectura.Read())

                    {
                        oPerfil.ID_Perfil = Convert.ToInt32( lectura["ID_Perfil"]);
                        oPerfil.Descripcion = lectura["desperfil"].ToString();
                        oPerfil.Lista_Permisos.Add(new Permiso()
                        {
                            ID_Permiso = int.Parse(lectura["ID_Permiso"].ToString()),
                            NombreSistema = lectura["NombreSistema"].ToString(),
                            Descripcion = lectura["Descripcion"].ToString(),
                            Padre = (lectura["Padre"].ToString().Length != 0 ? int.Parse(lectura["Padre"].ToString()) : -1),
                            Estado = bool.Parse(lectura["estado"].ToString())
                        });
                    } //while

                    lista.Add(oPerfil);
                } //if
            }
            catch (Exception) { throw; }
            finally
            {
                conn.Close();
            }
            return lista;
        }
    }
}
