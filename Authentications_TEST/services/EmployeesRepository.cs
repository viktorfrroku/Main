using Authentications_TEST.Connections;
using Authentications_TEST.Models;
using Authentications_TEST.services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.services
{
    public class EmployeesRepository : Repository<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(DBConnection _con) : base(_con)
        { 
        }
        public IEnumerable<Employees> GetEmployees(int count)
        {
            return _con.employees.OrderByDescending(d => d.FirstName).Take(count).ToList();
           // throw new NotImplementedException();
        }
    }
}
