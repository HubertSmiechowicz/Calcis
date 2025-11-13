using Calcis.Modules.Base.Api.Controllers;
using Calcis.Modules.Base.Core;
using Calcis.Shared.Abstractions.Modules;
using Calcis.Shared.Infrastructure.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
namespace Calcis.Modules.Base.Api
{
    internal class BaseModule : IModule
    {
        public BaseModule() { }

        public void Register(IServiceCollection service, IMvcBuilder mvc)
        {
            mvc.AddApplicationPart(typeof(BaseController).Assembly);
            LayerLoader.RegisterLayers(service, "Base.");
        }

        public void RegisterContexts(IServiceProvider serviceProvider)
        {
            LayerLoader.RegisterContexts(serviceProvider, "Base.");
        }
    }
}
