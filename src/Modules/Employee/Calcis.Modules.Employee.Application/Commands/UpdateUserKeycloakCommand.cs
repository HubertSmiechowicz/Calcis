using Calcis.Modules.Employee.Application.Commands.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.Commands
{
    internal record UpdateUserKeycloakCommand(Representation representation) : IRequest;
}
