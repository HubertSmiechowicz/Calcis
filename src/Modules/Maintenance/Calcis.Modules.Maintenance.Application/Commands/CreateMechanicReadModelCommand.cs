using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Maintenance.Application.Commands
{
    internal record CreateMechanicReadModelCommand(Guid id, string firstName, string lastName, string email) : IRequest;
}
