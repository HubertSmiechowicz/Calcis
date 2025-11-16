using Calcis.Modules.Fleet.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Fleet.Application.Repositories
{
    internal interface IFleetReadModelWriter
    {
        Task CreateDriverAsync(CreateDriverReadModelCommand model, CancellationToken cancellationToken);
    }
}
