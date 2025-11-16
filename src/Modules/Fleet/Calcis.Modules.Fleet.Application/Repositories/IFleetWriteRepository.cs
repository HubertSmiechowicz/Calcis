using Calcis.Shared.Events.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Fleet.Application.Repositories
{
    internal interface IFleetWriteRepository
    {
        Task CreateAsync(CreatedUserDriverCommand model, CancellationToken cancellationToken);
    }
}
