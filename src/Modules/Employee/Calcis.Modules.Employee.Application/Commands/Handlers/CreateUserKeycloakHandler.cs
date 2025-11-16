using Calcis.Modules.Employee.Application.Commands.Models;
using Calcis.Modules.Employee.Application.Repositories;
using Calcis.Modules.Employee.Core;
using Calcis.Modules.Employee.Core.DomainEvents;
using Calcis.Modules.Employee.Core.ValueObjects;
using Calcis.Shared.Abstractions.Core;
using Calcis.Shared.Events.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.Commands.Handlers
{
    internal class CreateUserKeycloakHandler : IRequestHandler<CreateUserKeycloakCommand>
    {
        private IEmployeeReadModelWriter _employeeRepository { get; }
        private IMediator _mediator { get; }

        public CreateUserKeycloakHandler(IEmployeeReadModelWriter employeeRepository, IMediator mediator)
        {
            _employeeRepository = employeeRepository;
            _mediator = mediator;
        }

        public async Task Handle(CreateUserKeycloakCommand request, CancellationToken cancellationToken)
        {
            var representation = request.Representation;

            if (representation == null)
                throw new ArgumentNullException(nameof(representation), "Representation cannot be null");

            var user = User.Create(UserId.FromResourcePath(request.ResourcePath), representation.Groups.Select(p => UserRole.FromString(p)).ToList());

            await _employeeRepository.CreateAsync(new DTO.UserProjectionModel(user.Id.Value, user.Roles.Select(p => p.Id).ToList(), (int)user.State, representation), cancellationToken);

            await SendEvents(user, representation);
        }

        private async Task SendEvents(User user, Representation representation)
        {
            var createUserEvents = user.DomainEvents
                .OfType<CreateDriver>()
                .FirstOrDefault();

            if (createUserEvents != null)
                await _mediator.Send(new CreatedUserDriverCommand(createUserEvents.Id, representation.FirstName, representation.LastName, representation.Email));

            var createMechanicEvents = user.DomainEvents
                .OfType<CreateMechanic>()
                .FirstOrDefault();

            if (createMechanicEvents != null)
                await _mediator.Send(new CreatedUserMechanicCommand(createMechanicEvents.Id, representation.FirstName, representation.LastName, representation.Email));
        }
    }
}
