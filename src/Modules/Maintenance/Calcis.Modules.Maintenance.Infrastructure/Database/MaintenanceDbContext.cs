using Calcis.Shared.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Maintenance.Infrastructure.Database
{
    internal class MaintenanceWriteDbContext : WriteDbContext<MaintenanceWriteDbContext>
    {
        public MaintenanceWriteDbContext(DbContextOptions<MaintenanceWriteDbContext> options) : base(options)
        {
        }

        internal DbSet<WriteDAO.Mechanic> Mechanics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabela
            modelBuilder.Entity<WriteDAO.Mechanic>()
                .ToTable("mechanic", "maintenance");

            // Klucz główny
            modelBuilder.Entity<WriteDAO.Mechanic>()
                .HasKey(d => d.Id);

            // Pola
            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.UserId)
                .IsRequired();

            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.FirstName)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.LastName)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.Email)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.State)
                .IsRequired()
                .HasDefaultValue(0);

            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.IsFGaseCertiicate)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.IsSepPermissions)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.IsTdtPermissions)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.IsTachographInstalationPermissions)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.IsUdtPermissions)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<WriteDAO.Mechanic>()
                .Property(d => d.IsWeldingPermissions)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }

    internal class MaintenanceReadDbContext : ReadDbContext<MaintenanceReadDbContext>
    {
        public MaintenanceReadDbContext(DbContextOptions<MaintenanceReadDbContext> options) : base(options)
        {
        }

        internal DbSet<ReadDAO.Mechanic> Mechanics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabela
            modelBuilder.Entity<ReadDAO.Mechanic>()
                .ToTable("mechanic", "maintenance");

            // Klucz główny
            modelBuilder.Entity<ReadDAO.Mechanic>()
                .HasKey(d => d.Id);

            // Pola
            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.UserId)
                .IsRequired();

            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.FirstName)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.LastName)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.Email)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.State)
                .IsRequired()
                .HasDefaultValue(0);

            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.IsFGaseCertiicate)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.IsSepPermissions)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.IsTdtPermissions)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.IsTachographInstalationPermissions)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.IsUdtPermissions)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<ReadDAO.Mechanic>()
                .Property(d => d.IsWeldingPermissions)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
