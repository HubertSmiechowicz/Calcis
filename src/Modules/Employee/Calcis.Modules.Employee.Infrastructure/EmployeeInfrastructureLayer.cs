using Calcis.Modules.Employee.Application.Repositories;
using Calcis.Modules.Employee.Infrastructure.Database;
using Calcis.Modules.Employee.Infrastructure.RabbitMq;
using Calcis.Modules.Employee.Infrastructure.Repositories;
using Calcis.Shared.Abstractions.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Calcis.Modules.Employee.Api")]
[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
namespace Calcis.Modules.Employee.Infrastructure
{
    public class EmployeeInfrastructureLayer : ILayer
    {
        public void Register(IServiceCollection service)
        {
            var serviceProvider = service.BuildServiceProvider();
            var config = serviceProvider.GetRequiredService<IConfiguration>();

            service.AddDbContext<EmployeeWriteDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("PostgresWrite")));

            service.AddDbContext<EmployeeReadDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("PostgresRead")));

            service.AddHostedService<RabbitMqListener>();

            service.AddTransient<IEmployeeReadRepository, EmployeeReadRepository>();
            service.AddTransient<IEmployeeReadModelWriter, EmployeeReadModelWriter>();
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var employeeRead = scope.ServiceProvider.GetRequiredService<EmployeeReadDbContext>();
            var employeeWrite = scope.ServiceProvider.GetRequiredService<EmployeeWriteDbContext>();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    employeeRead.Database.Migrate();
                    employeeWrite.Database.Migrate();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Migracja nie powiodła się, próbuję ponownie... {ex.Message}");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
