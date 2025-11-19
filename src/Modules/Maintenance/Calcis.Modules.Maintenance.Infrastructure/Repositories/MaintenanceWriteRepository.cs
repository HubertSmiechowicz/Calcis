using AutoMapper;
using Calcis.Modules.Maintenance.Application.Commands;
using Calcis.Modules.Maintenance.Application.Repositories;
using Calcis.Modules.Maintenance.Infrastructure.Database;
using Calcis.Modules.Maintenance.Infrastructure.Database.WriteDAO;
using Calcis.Shared.Events.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Maintenance.Infrastructure.Repositories
{
    internal class MaintenanceWriteRepository : IMaintenanceWriteRepository
    {
        private MaintenanceWriteDbContext _dbContext;
        private IMapper _mapper;
        private IMediator _mediator;

        public MaintenanceWriteRepository(MaintenanceWriteDbContext dbContext, IMapper mapper, IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task CreateAsync(CreatedUserMechanicCommand model, CancellationToken cancellationToken)
        {
            var mechanic = _mapper.Map<Mechanic>(model);
            _dbContext.Mechanics.Add(mechanic);

            await _dbContext.SaveChangesAsync(cancellationToken);

            await _mediator.Send(new CreateMechanicReadModelCommand(model.id, model.firstName, model.lastName, model.email));
        }
    }
}
