using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentications_TEST.services.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeesRepository Employees { get; }
        int Complete();
    }
}
