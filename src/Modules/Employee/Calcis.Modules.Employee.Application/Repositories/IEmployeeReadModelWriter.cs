using Calcis.Modules.Employee.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.Repositories
{
    internal interface IEmployeeReadModelWriter
    {
        Task CreateAsync(UserProjectionModel model, CancellationToken cancellationToken);
    }
}
