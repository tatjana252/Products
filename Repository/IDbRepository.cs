using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Repository
{
    public interface IDbRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        void Commit();
        void Rollback();
        void Close();
    }
}
