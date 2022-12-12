using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey key);
        TEntity Get(TKey key);
        List<TEntity> GetAll();
        List<TEntity> Search(string criteria);
    }
}
