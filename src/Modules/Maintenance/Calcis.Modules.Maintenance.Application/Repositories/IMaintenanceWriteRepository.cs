using Calcis.Shared.Events.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Maintenance.Application.Repositories
{
    internal interface IMaintenanceWriteRepository
    {
        Task CreateAsync(CreatedUserMechanicCommand model, CancellationToken cancellationToken);
    }
}
