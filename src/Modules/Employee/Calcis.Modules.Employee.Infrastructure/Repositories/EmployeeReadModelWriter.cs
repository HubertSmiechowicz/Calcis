using Calcis.Modules.Employee.Application.DTO;
using Calcis.Modules.Employee.Application.Repositories;
using Calcis.Modules.Employee.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Infrastructure.Repositories
{
    internal class EmployeeReadModelWriter : IEmployeeReadModelWriter
    {
        private EmployeeReadDbContext _dbContext { get; }

        public EmployeeReadModelWriter(EmployeeReadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(UserProjectionModel model, CancellationToken cancellationToken)
        {
            await Task.Yield();
        }
    }
}
