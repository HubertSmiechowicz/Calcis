using Calcis.Modules.Employee.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.Commands.Handlers
{
    internal class SetUserPasswordKeycloakHandler : IRequestHandler<SetUserPasswordKeycloakCommand>
    {
        private IEmployeeReadRepository _employeeReadRepository;
        private IEmployeeReadModelWriter _employeeReadModelWriter;

        public SetUserPasswordKeycloakHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeReadModelWriter employeeReadModelWriter)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeReadModelWriter = employeeReadModelWriter;
        }

        public async Task Handle(SetUserPasswordKeycloakCommand request, CancellationToken cancellationToken)
        {
            var user = await _employeeReadRepository.GetByIdAsync(request.id, cancellationToken);

            user.SetUserStateAfterSettingPassword();

            await _employeeReadModelWriter.SetUserStateAfterSettingPassword(user, cancellationToken);
        }
    }
}
