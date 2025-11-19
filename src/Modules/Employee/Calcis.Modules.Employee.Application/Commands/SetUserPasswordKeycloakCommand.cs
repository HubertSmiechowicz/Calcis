using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.Commands
{
    internal record SetUserPasswordKeycloakCommand(Guid id) : IRequest;
}
