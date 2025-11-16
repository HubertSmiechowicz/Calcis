using Amazon.Util.Internal.PlatformServices;
using Calcis.Modules.Employee.Application.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.Commands.DTO
{
    internal class UserProjectionModel
    {
        internal Guid Id { get; set; }
        internal string Username { get; set; }
        internal bool Enabled { get; set; }
        internal bool Totp { get; set; }
        internal bool EmailVerified { get; set; }
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal string Email { get; set; }
        internal List<int> Roles { get; set; }
        internal int State { get; set; }
        internal int NotBefore { get; set; }

        private UserProjectionModel(Guid id, string username, bool enabled, bool totp, bool emailVerified, string firstName, string lastName, string email, List<int> roles, int state, int notBefore)
        {
            Id = id;
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
