using Calcis.Shared.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Infrastructure.Database.ReadDAO
{
    [Table("user_entity", Schema = "employee")]
    internal class User
    {
        [Key]
        internal Guid Id { get; set; }
        [MaxLength(255)]
        internal string Username { get; set; }
        internal bool Enabled { get; set; }
        internal bool Totp { get; set; }
        internal bool EmailVerified { get; set; }
        [MaxLength(255)]
        internal string FirstName { get; set; }
        [MaxLength(255)]
        internal string LastName { get; set; }
        [MaxLength(255)]
        internal string Email { get; set; }
        internal int State { get; set; }
        internal int NotBefore { get; set; }
        internal DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        internal bool IsPasswordSet { get; set; } = false;

        internal virtual ICollection<UserRole> Roles { get; set; }
    }
}
