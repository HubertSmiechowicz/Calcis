using Calcis.Modules.Maintenance.Application.Repositories;
using Calcis.Modules.Maintenance.Infrastructure.Database;
using Calcis.Modules.Maintenance.Infrastructure.Repositories;
using Calcis.Shared.Abstractions.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Modules.Maintenance.Api")]
[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
[assembly: InternalsVisibleTo("MediatR")]
namespace Calcis.Modules.Maintenance.Infrastructure
{
    public class MaintenanceInfrastructureLayer : ILayer
    {
        public void Register(Microsoft.Extensions.DependencyInjection.IServiceCollection service, Microsoft.Extensions.Configuration.IConfiguration config)
        {
            service.AddDbContext<MaintenanceWriteDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("PostgresWrite")));

            service.AddDbContext<MaintenanceReadDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("PostgresRead")));

            service.AddTransient<IMaintenanceWriteRepository, MaintenanceWriteRepository>();
            service.AddTransient<IMaintenanceReadModelWriter, MaintenanceReadModelWriter>();

            service.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
            Task.Run(async () =>
            {
                using var scope = serviceProvider.CreateScope();

                var maintenanceRead = scope.ServiceProvider.GetRequiredService<MaintenanceReadDbContext>();
                var maintenanceWrite = scope.ServiceProvider.GetRequiredService<MaintenanceWriteDbContext>();

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        await maintenanceRead.Database.MigrateAsync();
                        await maintenanceWrite.Database.MigrateAsync();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Migracja nie powiodła się, próbuję ponownie... {ex.Message}");
                        Thread.Sleep(2000);
                    }
                }
            }).GetAwaiter().GetResult();
        }
    }
}
