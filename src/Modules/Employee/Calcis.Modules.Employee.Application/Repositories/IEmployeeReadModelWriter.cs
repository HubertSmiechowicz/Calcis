using Calcis.Modules.Employee.Application.Commands.DTO;
using Calcis.Modules.Employee.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.Repositories
{
    internal interface IEmployeeReadModelWriter
    {
        Task CreateUserAsync(UserProjectionModel model, CancellationToken cancellationToken);

        Task SetUserStateAfterSettingPassword(User user, CancellationToken cancellationToken);

        Task UpdateUserAsync(UserProjectionModel model, CancellationToken cancellationToken);
    }
}
