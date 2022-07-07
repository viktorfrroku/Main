using Authentications_TEST.Connections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Authentications_TEST.services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly  DBConnection _con;
        public Repository(DBConnection con)
        {
            _con = con;  
        }
        public void Create(T entity)
        {
            _con.Set<T>().Add(entity);
            _con.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
          T d = _con.Set<T>().Find(id);
            _con.Remove(d);
            _con.SaveChanges();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> d = _con.Set<T>().Where(expression);
            return d;
        }

        public IEnumerable<T> getAll()
        {
            IEnumerable<T> d = _con.Set<T>().ToList();
            return d;
           // throw new NotImplementedException();
        }

       
        public void Update(T entity)
        {
            _con.Entry(entity).State = EntityState.Modified;
            _con.SaveChanges();
            //throw new NotImplementedException();
        }
        public T getFist(int id)
        {
            T d = _con.Set<T>().Find(id);
            return d;
        }
    }
}
