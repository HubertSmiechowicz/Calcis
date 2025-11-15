using AutoMapper;
using Calcis.Modules.Employee.Application.DTO;
using Calcis.Modules.Employee.Application.Repositories;
using Calcis.Modules.Employee.Infrastructure.Database;
using Calcis.Modules.Employee.Infrastructure.Database.ReadDAO;
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
        private IMapper _mapper { get; }

        public EmployeeReadModelWriter(EmployeeReadDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(UserProjectionModel model, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(model);

            _dbContext.Users.Add(user);

            foreach (var role in model.Roles)
            {
                var roleEntity = new UserRole()
                {
                    UserId = user.Id,
                    GroupId = role
                };

                _dbContext.UserRoles.Add(roleEntity);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
