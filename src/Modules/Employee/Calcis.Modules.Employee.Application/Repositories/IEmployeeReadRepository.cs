using Calcis.Modules.Employee.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.Repositories
{
    public interface IEmployeeReadRepository
    {
        internal Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
