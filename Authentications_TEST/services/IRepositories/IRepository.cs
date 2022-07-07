using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Authentications_TEST.services
{
   public interface IRepository<T> : IDisposable where T : class
    {
        void Create(T entity);
        void Update(T entiry);
        void Delete(int id);
        IEnumerable<T> getAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T getFist(int id);
    }
}
