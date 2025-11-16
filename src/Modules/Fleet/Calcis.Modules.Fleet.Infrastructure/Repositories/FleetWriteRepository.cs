using AutoMapper;
using Calcis.Modules.Fleet.Application.Commands;
using Calcis.Modules.Fleet.Application.Repositories;
using Calcis.Modules.Fleet.Infrastructure.Database;
using Calcis.Modules.Fleet.Infrastructure.Database.WriteDAO;
using Calcis.Shared.Events.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Fleet.Infrastructure.Repositories
{
    internal class FleetWriteRepository : IFleetWriteRepository
    {
        private readonly FleetWriteDbContext _dbContext;
        private IMapper _mapper;
        private IMediator _mediator;

        public FleetWriteRepository(FleetWriteDbContext dbContext, IMapper mapper, IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task CreateAsync(CreatedUserDriverCommand model, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(model);
            _dbContext.Drivers.Add(driver);

            await _dbContext.SaveChangesAsync(cancellationToken);

            await _mediator.Send(new CreateDriverReadModelCommand(model.id, model.firstName, model.lastName, model.email));
        }
    }
}
