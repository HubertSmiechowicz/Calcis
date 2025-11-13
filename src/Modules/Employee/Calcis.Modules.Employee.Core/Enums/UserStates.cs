using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Core.Enums
{
    internal enum UserStates
    {
        AwaitingPasswordSetup,
        Active,
        Inactive,
        RoleError,
    }
}
