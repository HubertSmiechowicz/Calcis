using Amazon.Util.Internal.PlatformServices;
using Calcis.Modules.Employee.Application.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.DTO
{
    internal class UserProjectionModel
    {
        internal Guid Id { get; private set; }
        internal long CreatedTimestamp { get; private set; }
        internal string Username { get; private set; }
        internal bool Enabled { get; private set; }
        internal bool Totp { get; private set; }
        internal bool EmailVerified { get; private set; }
        internal string FirstName { get; private set; }
        internal string LastName { get; private set; }
        internal string Email { get; private set; }
        internal List<int> Roles { get; private set; }
        internal int State { get; private set; }
        internal int NotBefore { get; private set; }

        private UserProjectionModel(Guid id, long createdTimestamp, string username, bool enabled, bool totp, bool emailVerified, string firstName, string lastName, string email, List<int> roles, int state, int notBefore)
        {
            Id = id;
            CreatedTimestamp = createdTimestamp;
            Username = username;
            Enabled = enabled;
            Totp = totp;
            EmailVerified = emailVerified;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Roles = roles;
            State = state;
            NotBefore = notBefore;
        }

        public UserProjectionModel(Guid id, List<int> roles, int state, Representation representation)
            : this(
                  id,
                  representation?.CreatedTimestamp ?? 0,
                  representation?.Username ?? string.Empty,
                  representation?.Enabled ?? false,
                  representation?.Totp ?? false,
                  representation?.EmailVerified ?? false,
                  representation?.FirstName ?? string.Empty,
                  representation?.LastName ?? string.Empty,
                  representation?.Email ?? string.Empty,
                  roles,
                  state,
                  representation?.NotBefore ?? 0)
        {
        }
    }
}
