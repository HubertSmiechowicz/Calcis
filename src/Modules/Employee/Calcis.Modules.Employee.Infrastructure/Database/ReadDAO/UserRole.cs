using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Infrastructure.Database.ReadDAO
{
    [Table("user_group_membership", Schema = "employee")]
    internal class UserRole
    {
        [ForeignKey(nameof(User))]
        internal Guid UserId { get; set; }
        internal int GroupId { get; set; }

        internal virtual User User { get; set; }
    }
}
