using Calcis.Modules.Fleet.Application.Repositories;
using Calcis.Modules.Fleet.Infrastructure.Database;
using Calcis.Modules.Fleet.Infrastructure.Repositories;
using Calcis.Shared.Abstractions.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

[assembly: InternalsVisibleTo("Calcis.Modules.Fleet.Api")]
[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
[assembly: InternalsVisibleTo("MediatR")]
namespace Calcis.Modules.Fleet.Infrastructure
{
    public class FleetInfrastructureLayer : ILayer
    {
        public void Register(IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<FleetWriteDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("PostgresWrite")));

            service.AddDbContext<FleetReadDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("PostgresRead")));

            service.AddTransient<IFleetWriteRepository, FleetWriteRepository>();
            service.AddTransient<IFleetReadModelWriter, FleetReadModelWriter>();

            service.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
            Task.Run(async () =>
            {
                using var scope = serviceProvider.CreateScope();

                var employeeRead = scope.ServiceProvider.GetRequiredService<FleetReadDbContext>();
                var employeeWrite = scope.ServiceProvider.GetRequiredService<FleetWriteDbContext>();

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        await employeeRead.Database.MigrateAsync();
                        await employeeWrite.Database.MigrateAsync();
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
