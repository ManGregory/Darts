using System;
using System.Configuration;
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
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DartsRemote"].ConnectionString);
        }
        
        public DartsContext ConnectionContext
        {
            get
            {
                return _connectionContext ?? (_connectionContext = new DartsContext());
                //return _connectionContext ?? (_connectionContext = new DartsContext(_connection));
            }
            private set
            {
                _connectionContext = value;
            }
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
