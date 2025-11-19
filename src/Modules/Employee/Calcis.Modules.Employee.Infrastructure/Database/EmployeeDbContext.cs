using Calcis.Modules.Employee.Infrastructure.Database.ReadDAO;
using Calcis.Shared.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Infrastructure.Database
{
    public class EmployeeWriteDbContext : WriteDbContext<EmployeeWriteDbContext>
    {
        public EmployeeWriteDbContext(DbContextOptions<EmployeeWriteDbContext> options) : base(options)
        {
        }
    }

    public class EmployeeReadDbContext : ReadDbContext<EmployeeReadDbContext>
    {
        public EmployeeReadDbContext(DbContextOptions<EmployeeReadDbContext> options) : base(options)
        {

        }

        internal DbSet<User> Users { get; set; }
        internal DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabela
            modelBuilder.Entity<User>()
                .ToTable("user_entity", "employee");

            // Klucz główny
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // Pola
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .Property(u => u.Enabled)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Totp)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.EmailVerified)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .Property(u => u.State)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.NotBefore)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.IsPasswordSet)
                .IsRequired()
                .HasDefaultValue(false);

            // Relacja (User → UserRole)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.GroupId });
        }

    }
}
