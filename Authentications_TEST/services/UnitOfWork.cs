using Authentications_TEST.Connections;
using Authentications_TEST.services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.services
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DBConnection _con;
        public UnitOfWork(DBConnection con)
        {
            _con = con;
            Employees = new EmployeesRepository(_con);
        
        }
        public IEmployeesRepository Employees { get; private set; }

        // public IEmployeesRepository Employees => throw new NotImplementedException();

        public int Complete()
        {
            return _con.SaveChanges();
           // throw new NotImplementedException();
        }

        public void Dispose()
        {
             _con.Dispose();
           // throw new NotImplementedException();
        }
    }
}
