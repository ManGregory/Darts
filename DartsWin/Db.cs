using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.OleDb;
using System.Data.SqlClient;
using DartsConsole;
using Telerik.Pivot.Core;

namespace DartsWin
{
    public sealed class Db : IDisposable
    {
        private readonly DbConnection _connection;
        private DartsContext _connectionContext;

        public Db()
        {
            
        }

        public Db(string connectionString)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                _connection = new SqlConnection(connectionString);
            }                        
        }
        
        public DartsContext ConnectionContext
        {
            get
            {
                return _connectionContext ?? (
                    _connectionContext = _connection == null ? new DartsContext() : new DartsContext(_connection));
            }            
        }

        public void Dispose()
        {
            if ((_connection != null) && (_connection.State == ConnectionState.Open))
            {
                _connection.Close();
            }
        }
    }
}
