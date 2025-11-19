using Calcis.Modules.Maintenance.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Maintenance.Application.Repositories
{
    internal interface IMaintenanceReadModelWriter
    {
        Task CreateDriverAsync(CreateMechanicReadModelCommand model, CancellationToken cancellationToken);
    }
}
