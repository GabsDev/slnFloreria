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
    public class Conexion : Persistencia.IDataBase
    {
        public IDbConnection _Conexion { get; set; } 

        public Conexion()
        {
            _Conexion = new SqlConnection();

        }
        public string Cadena
        {
            get
            {
                return @"Data Source=localhost\MSSQLSERVER;Initial Catalog=FloristeriaBD;User ID=sa;Password=Asus2020";
            }
        }

        public static SqlConnection establecerConexion()
        {
            SqlConnection conn;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Capa.UI.Properties.Settings.ConnectionString"].ConnectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "\n");
            }
        }

        public  IDataReader ExecuteReader(IDbCommand pCommand)
        {

            IDataReader lector = null;
            try
            {

                pCommand.Connection = _Conexion;
                lector = pCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return lector;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public DataSet ExecuteReader(IDbCommand pCommand, String pTabla)
        {

            DataSet dsTabla = new DataSet();
            try
            {

                using (SqlDataAdapter adaptador = new SqlDataAdapter(pCommand as SqlCommand))
                {
                    pCommand.Connection = establecerConexion();
                    dsTabla = new DataSet();
                    adaptador.Fill(dsTabla, pTabla);
                }
                return dsTabla;
            }
            catch (Exception)
            {

                // lanzar excepción                     
                throw;
            }
            finally
            {

                if (dsTabla != null)
                    dsTabla.Dispose();


            }



        }

        public double ExecuteNonQuery(IDbCommand pCommand, IsolationLevel pIsolationLevel)
        {
            using (IDbTransaction transaccion = _Conexion.BeginTransaction(pIsolationLevel))
            {
                double registrosafectados = 0;
                try
                {

                    pCommand.Connection = _Conexion;
                    pCommand.Transaction = transaccion;
                    registrosafectados = pCommand.ExecuteNonQuery();

                    // Commit a la transacción
                    transaccion.Commit();

                    return registrosafectados;
                }

                catch (Exception)
                {

                    throw;
                }

            }

        }

        public double ExecuteNonQuery(IDbCommand pCommand)
        {

            double registrosafectados = 0;
            try
            {

                pCommand.Connection = _Conexion;

                registrosafectados = pCommand.ExecuteNonQuery();

                return registrosafectados;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public double ExecuteScalar(IDbCommand pCommand)
        {
            double registrosafectados = 0;
            object respuesta = null;
            try
            {

                pCommand.Connection = _Conexion;

                respuesta = pCommand.ExecuteScalar();

                if (respuesta == null)
                    registrosafectados = 0d;
                else
                    double.TryParse(respuesta.ToString(), out registrosafectados);


                return registrosafectados;

            }
            catch (Exception)
            {

                throw;
            }


        }

        public void ExecuteNonQuery(ref IDbCommand pCommand, IsolationLevel pIsolationLevel)
        {
            using (IDbTransaction transaccion = _Conexion.BeginTransaction(pIsolationLevel))
            {

                try
                {

                    pCommand.Connection = _Conexion;
                    pCommand.Transaction = transaccion;
                    pCommand.ExecuteNonQuery();

                    // Commit a la transacción
                    transaccion.Commit();


                }

                catch (Exception error)
                {

                    throw error;
                }

            }

        }

        public void ExecuteNonQuery(List<IDbCommand> pCommands, IsolationLevel pIsolationLevel)
        {
            try
            {
                using (IDbTransaction transaccion = _Conexion.BeginTransaction(pIsolationLevel))
                {
                    foreach (IDbCommand command in pCommands)
                    {
                        command.Connection = (_Conexion as SqlConnection);
                        command.Transaction = transaccion;
                        //command.CommandTimeout = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ConnectionTimeOut"].ToString());
                        command.ExecuteNonQuery();
                    }
                    // Commit a la transacción
                    transaccion.Commit();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
            }
        }

        public void Dispose()
        {
            if (_Conexion != null)
                _Conexion.Close();
        }
    }
}
