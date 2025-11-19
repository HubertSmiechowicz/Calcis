using Calcis.Modules.Employee.Application.Commands.Models;
using Calcis.Modules.Employee.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.Commands.Handlers
{
    internal class UpdateUserKeycloakHandler : IRequestHandler<UpdateUserKeycloakCommand>
    {
        private IEmployeeReadModelWriter _employeeReadModelWriter { get; }
        private IEmployeeReadRepository _employeeReadRepository { get; }

        public UpdateUserKeycloakHandler(IEmployeeReadModelWriter employeeReadModelWriter, IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadModelWriter = employeeReadModelWriter;
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task Handle(UpdateUserKeycloakCommand request, CancellationToken cancellationToken)
        {
            var representation = request.representation;

            if (representation == null)
                throw new ArgumentNullException(nameof(representation), "Representation cannot be null");

            var id = Guid.Empty;
            var success = Guid.TryParse(representation.Id, out id);

            if (!success)
            {
                throw new ArgumentException($"Invalid Id format for ID {representation.Id}");
            }   
            var user = await _employeeReadRepository.GetByIdAsync(id, cancellationToken);

            await _employeeReadModelWriter.UpdateUserAsync(new DTO.UserProjectionModel(user.Id.Value, user.Roles.Select(p => p.Id).ToList(), (int)user.State, representation), cancellationToken);
        }
    }
}
