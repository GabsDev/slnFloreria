using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Datos.Persistencia
{
    public interface IDataBase : IDisposable
    {
        IDbConnection _Conexion { get; set; }
        double ExecuteNonQuery(IDbCommand pCommand);
        void ExecuteNonQuery(ref IDbCommand pCommand, IsolationLevel pIsolationLevel);
        void ExecuteNonQuery(List<IDbCommand> pCommands, IsolationLevel pIsolationLevel);
        double ExecuteNonQuery(IDbCommand pSQLCommand, IsolationLevel pIsolationLevel);
        IDataReader ExecuteReader(IDbCommand pSqlCommand);
        DataSet ExecuteReader(IDbCommand pSqlCommand, string pTabla);
        double ExecuteScalar(IDbCommand pSQLCommand);

    }
}
