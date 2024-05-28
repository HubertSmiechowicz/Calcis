using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Calcis.Modules.Base.Core
{
    public class BaseCoreLayer : ILayer
    {
        public void Register(IServiceCollection service)
        {
            service.AddTransient<IBaseService, BaseService>();
        }
    }
}
