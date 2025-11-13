using Calcis.Modules.Employee.Infrastructure.Database.ReadDAO;
using Calcis.Shared.Infrastructure.Database;
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

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

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
