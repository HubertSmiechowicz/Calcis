using Calcis.Modules.Base.Core.Repositories;
using Calcis.Modules.Base.Infrastructure.Repositories;
using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Calcis.Modules.Base.Api")]
[assembly: InternalsVisibleTo("Calcis.Modules.Base.Application")]
namespace Calcis.Modules.Base.Infrastructure
{
    public class BaseInfrastructureLayer : ILayer
    {
        public void Register(IServiceCollection service)
        {
            service
                .AddSingleton<BaseDbContext>()
                .AddTransient<IBaseRepository, BaseRepository>();
        }
    }
}
