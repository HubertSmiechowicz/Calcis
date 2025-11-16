using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Fleet.Application.Commands
{
    internal record CreateDriverReadModelCommand(Guid id, string firstName, string lastName, string email) : IRequest;
}
