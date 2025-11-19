using AutoMapper;
using Calcis.Modules.Employee.Application.Repositories;
using Calcis.Modules.Employee.Core;
using Calcis.Modules.Employee.Infrastructure.Database;
using Calcis.Modules.Employee.Infrastructure.Database.ReadDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Infrastructure.Repositories
{
    internal class EmployeeReadRepository : IEmployeeReadRepository
    {
        private EmployeeReadDbContext _dbContext;
        private IMapper _mapper;

        public EmployeeReadRepository(EmployeeReadDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        async Task<Core.User> IEmployeeReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .Include(u => u.Roles)
                .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);

            if (entity == null)
                throw new InvalidOperationException($"User with ID {id} not found in read model.");

            return _mapper.Map<Core.User>(entity);
        }
    }
}
