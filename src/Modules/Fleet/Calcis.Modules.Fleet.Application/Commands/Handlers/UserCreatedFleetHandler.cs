using Calcis.Modules.Fleet.Application.Repositories;
using Calcis.Shared.Events.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Fleet.Application.Commands.Handlers
{
    internal class UserCreatedFleetHandler : IRequestHandler<CreatedUserDriverCommand>
    {
        private IFleetWriteRepository _fleetWriteRepository { get; }

        public UserCreatedFleetHandler(IFleetWriteRepository fleetWriteRepository)
        {
            _fleetWriteRepository = fleetWriteRepository;
        }

        public async Task Handle(CreatedUserDriverCommand request, CancellationToken cancellationToken)
        {
            await _fleetWriteRepository.CreateAsync(request, cancellationToken);
        }
    }
}
