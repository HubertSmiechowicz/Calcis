using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calcis.Shared.Database;

namespace Calcis.Modules.Fleet.Infrastructure.Database.WriteDAO
{
    [Table("driver", Schema = "fleet")]
    internal class Driver : Entity
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

        internal string DrivingLicenseNumber { get; set; }

        internal DateTime? DrivingLicenseExpiryDate { get; set; }

        internal bool Is95Code { get; set; }

        internal string TachographCardNumber { get; set; }

        internal bool IsMedicalCertificateValid { get; set; }

        internal DateTime? MedicalCertificateExpiryDate { get; set; }

        internal bool IsPsychologicalExamValid { get; set; }

        internal DateTime? PsychologicalExamExpiryDate { get; set; }

        internal string IdentityCardNumber { get; set; }

        internal DateTime? IdentityCardExpiryDate { get; set; }

        internal string PassportNumber { get; set; }

        internal DateTime? PassportExpiryDate { get; set; }

        internal string CertificateNoCriminalRecordNumber { get; set; }

        internal string AdrNumber { get; set; }

        internal DateTime? AdrExpiryDate { get; set; }
    }
}
