using Calcis.Modules.Employee.Core.DomainEvents;
using Calcis.Modules.Employee.Core.Enums;
using Calcis.Modules.Employee.Core.ValueObjects;
using Calcis.Shared.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Core
{
    internal class User : AggregateRoot
    {
        internal UserId Id { get; private set; }
        internal List<UserRole> Roles { get; private set; }
        internal UserStates State { get; private set; }

        private User() { }

        private User(UserId id, List<UserRole> roles, UserStates state)
        {
            Id = id;
            Roles = roles;
            State = state;
        }

        internal static User Create(UserId id, List<UserRole> roles)
        {
            var states = DetermineInitialState(roles);

            var user = new User(id, roles, states);

            SetCreateEvents(roles, user);

            return user;
        }

        private static UserStates DetermineInitialState(List<UserRole> roles)
        {
            if (HasInvalidRoleCombination(roles))
                return UserStates.RoleError;
            return UserStates.AwaitingPasswordSetup;
        }

        private static void SetCreateEvents(List<UserRole> roles, User user)
        {
            if (HasInvalidRoleCombination(roles))
                return;

            if (roles.Contains(UserRole.Driver))
                user.AddDomainEvent(new CreateDriver() { Id = user.Id.Value });
            else if (roles.Contains(UserRole.Mechanic))
                user.AddDomainEvent(new CreateMechanic() { Id = user.Id.Value });
        }

        private static bool HasInvalidRoleCombination(List<UserRole> roles)
        {
            return roles.Contains(UserRole.Invalid) || (roles.Contains(UserRole.Driver) && roles.Contains(UserRole.Mechanic));
        }
    }
}
