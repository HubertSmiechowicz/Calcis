using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Shared.Infrastructure.Database
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CreatedBy { get; set; } = Guid.Empty;

        public Guid ModifiedBy { get; set; }

        public Guid DeletedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
