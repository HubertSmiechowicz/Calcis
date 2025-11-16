using Calcis.Modules.Fleet.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Fleet.Application.Commands.Handlers
{
    internal class CreateDriverReadModelHandler : IRequestHandler<CreateDriverReadModelCommand>
    {
        private IFleetReadModelWriter _fleetReadModelWriter { get; }

        public CreateDriverReadModelHandler(IFleetReadModelWriter fleetReadModelWriter)
        {
            _fleetReadModelWriter = fleetReadModelWriter;
        }

        public async Task Handle(CreateDriverReadModelCommand request, CancellationToken cancellationToken)
        {
            await _fleetReadModelWriter.CreateDriverAsync(request, cancellationToken);
        }
    }
}
