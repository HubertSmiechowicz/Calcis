using AutoMapper;
using Calcis.Modules.Employee.Application.Commands.DTO;
using Calcis.Modules.Employee.Application.Repositories;
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
    internal class EmployeeReadModelWriter : IEmployeeReadModelWriter
    {
        private EmployeeReadDbContext _dbContext { get; }
        private IMapper _mapper { get; }

        public EmployeeReadModelWriter(EmployeeReadDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateUserAsync(UserProjectionModel model, CancellationToken cancellationToken)
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

        public async Task SetUserStateAfterSettingPassword(Core.User user, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == user.Id.Value, cancellationToken);

            if (entity == null)
            {
                throw new InvalidOperationException($"User with ID {user.Id.Value} not found in read model.");
            }

            entity.State = (int)user.State;
            entity.IsPasswordSet = true;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateUserAsync(UserProjectionModel model, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == model.Id, cancellationToken);

            if (entity == null)
                throw new KeyNotFoundException($"User with id {model.Id} not found.");

            _mapper.Map(model, entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
