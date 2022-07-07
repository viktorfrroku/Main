using Authentications_TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.services.IRepositories
{
    public interface IEmployeesRepository : IRepository<Employees>
    {
        IEnumerable<Employees> GetEmployees(int count);
    }
}
