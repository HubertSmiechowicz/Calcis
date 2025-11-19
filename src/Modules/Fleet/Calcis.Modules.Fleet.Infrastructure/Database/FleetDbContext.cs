using Calcis.Modules.Fleet.Infrastructure.Database.ReadDAO;
using Calcis.Modules.Fleet.Infrastructure.Database.WriteDAO;
using Calcis.Shared.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Fleet.Infrastructure.Database
{
    internal class FleetWriteDbContext : WriteDbContext<FleetWriteDbContext>
    {
        public FleetWriteDbContext(DbContextOptions<FleetWriteDbContext> options) : base(options)
        {
        }

        internal DbSet<WriteDAO.Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabela
            modelBuilder.Entity<WriteDAO.Driver>()
                .ToTable("driver", "fleet");

            // Klucz główny
            modelBuilder.Entity<WriteDAO.Driver>()
                .HasKey(d => d.Id);

            // Pola
            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.UserId)
                .IsRequired();

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.FirstName)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.LastName)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.Email)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.DrivingLicenseNumber)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.DrivingLicenseExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.Is95Code)
                .IsRequired();

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.TachographCardNumber)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.IsMedicalCertificateValid)
                .IsRequired();

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.MedicalCertificateExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.IsPsychologicalExamValid)
                .IsRequired();

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.PsychologicalExamExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.IdentityCardNumber)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.IdentityCardExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.PassportNumber)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.PassportExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.CertificateNoCriminalRecordNumber)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.AdrNumber)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.AdrExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Driver>()
                .Property(d => d.State)
                .IsRequired(true)
                .HasDefaultValue(0);
        }
    }

    internal class FleetReadDbContext : ReadDbContext<FleetReadDbContext>
    {
        public FleetReadDbContext(DbContextOptions<FleetReadDbContext> options) : base(options)
        {
        }

        internal DbSet<ReadDAO.Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabela
            modelBuilder.Entity<ReadDAO.Driver>()
                .ToTable("driver", "fleet");

            // Klucz główny
            modelBuilder.Entity<ReadDAO.Driver>()
                .HasKey(d => d.Id);

            // Pola
            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.UserId)
                .IsRequired();

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.FirstName)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.LastName)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.Email)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.DrivingLicenseNumber)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.DrivingLicenseExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.Is95Code)
                .IsRequired();

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.TachographCardNumber)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.IsMedicalCertificateValid)
                .IsRequired();

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.MedicalCertificateExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.IsPsychologicalExamValid)
                .IsRequired();

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.PsychologicalExamExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.IdentityCardNumber)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.IdentityCardExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.PassportNumber)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.PassportExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.CertificateNoCriminalRecordNumber)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.AdrNumber)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.AdrExpiryDate)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Driver>()
                .Property(d => d.State)
                .IsRequired(true)
                .HasDefaultValue(0);
        }
    }
}
