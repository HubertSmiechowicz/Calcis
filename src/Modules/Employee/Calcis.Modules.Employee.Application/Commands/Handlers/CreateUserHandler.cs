using Calcis.Modules.Employee.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calcis.Modules.Employee.Core;
using Calcis.Modules.Employee.Core.ValueObjects;

namespace Calcis.Modules.Employee.Application.Commands.Handlers
{
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private IEmployeeReadModelWriter _employeeRepository { get; }
        private IMediator _mediator { get; }

        public CreateUserHandler(IEmployeeReadModelWriter employeeRepository, IMediator mediator)
        {
            _employeeRepository = employeeRepository;
            _mediator = mediator;
        }

        public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // TODO::Add logic to handle user creation based on the request.Representation data.
            if (request.Representation == null)
                throw new ArgumentNullException(nameof(request.Representation), "Representation cannot be null");

            var user = User.Create(UserId.FromResourcePath(request.ResourcePath), request.Representation.Groups.Select(p => UserRole.FromString(p)).ToList());

            _employeeRepository.CreateAsync(new DTO.UserProjectionModel(user.Id.Value, user.Roles.Select(p => p.Id).ToList(), (int)user.State, request.Representation), cancellationToken);

            return Task.CompletedTask;
        }
    }
}
