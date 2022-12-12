using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DbConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;
        public void OpenConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["psdb"].ConnectionString);
                connection.Open();
            }
        }
        public SqlCommand CreateCommand(string sql = "")
        {
            transaction = connection.BeginTransaction();
            return new SqlCommand(sql, connection, transaction); ;
        }
        public void Commit()
        {
            transaction.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }
        public bool IsReady()
        {
            return connection != null && connection.State != ConnectionState.Closed;
        }
        public void Close()
        {
            connection.Close();
        }

    }
}
