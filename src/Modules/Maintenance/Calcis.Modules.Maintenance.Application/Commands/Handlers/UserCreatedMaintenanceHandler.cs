using Calcis.Modules.Maintenance.Application.Repositories;
using Calcis.Shared.Events.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Maintenance.Application.Commands.Handlers
{
    internal class UserCreatedMaintenanceHandler : IRequestHandler<CreatedUserMechanicCommand>
    {
        private IMaintenanceWriteRepository _maintenanceWriteRepository { get; }

        public UserCreatedMaintenanceHandler(IMaintenanceWriteRepository maintenanceWriteRepository)
        {
            _maintenanceWriteRepository = maintenanceWriteRepository;
        }
        public async Task Handle(CreatedUserMechanicCommand request, CancellationToken cancellationToken)
        {
            await _maintenanceWriteRepository.CreateAsync(request, cancellationToken);
        }
    }
}
