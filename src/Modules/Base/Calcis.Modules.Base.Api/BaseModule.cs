using Calcis.Modules.Base.Core;
using Calcis.Shared.Abstractions.Modules;
using Calcis.Shared.Infrastructure.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Api
{
    public class BaseModule : IModule
    {
        public BaseModule() { }

        public void Register(IServiceCollection service)
        {
            LayerLoader.RegisterLayers(service, "Base.");
        }
    }
}
