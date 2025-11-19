using Calcis.Modules.Maintenance.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Maintenance.Application.Commands.Handlers
{
    internal class CreateMechanicReadModelHandler : IRequestHandler<CreateMechanicReadModelCommand>
    {
        private IMaintenanceReadModelWriter _maintenanceReadModelWriter { get; }

        public CreateMechanicReadModelHandler(IMaintenanceReadModelWriter maintenanceReadModelWriter)
        {
            _maintenanceReadModelWriter = maintenanceReadModelWriter;
        }
        public async Task Handle(CreateMechanicReadModelCommand request, CancellationToken cancellationToken)
        {
            await _maintenanceReadModelWriter.CreateDriverAsync(request, cancellationToken);
        }
    }
}
