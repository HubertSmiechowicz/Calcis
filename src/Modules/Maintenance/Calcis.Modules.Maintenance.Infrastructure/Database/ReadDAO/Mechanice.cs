using Calcis.Shared.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Maintenance.Infrastructure.Database.ReadDAO
{
    [Table("mechanic", Schema = "maintenance")]
    internal class Mechanic : Entity
    {
        [Required]
        internal Guid UserId { get; set; }

        [MaxLength(255)]
        internal string FirstName { get; set; }

        [MaxLength(255)]
        internal string LastName { get; set; }

        [MaxLength(255)]
        internal string Email { get; set; }

        internal int State { get; set; }

        internal bool IsFGaseCertiicate { get; set; }

        internal bool IsSepPermissions { get; set; }

        internal bool IsTdtPermissions { get; set; }

        internal bool IsTachographInstalationPermissions { get; set; }

        internal bool IsUdtPermissions { get; set; }

        internal bool IsWeldingPermissions { get; set; }
    }
}
