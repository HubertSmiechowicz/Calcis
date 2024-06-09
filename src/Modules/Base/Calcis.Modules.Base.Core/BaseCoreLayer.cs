using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Calcis.Modules.Base.Api")]
[assembly: InternalsVisibleTo("Calcis.Modules.Base.Application")]
[assembly: InternalsVisibleTo("Calcis.Modules.Base.Infrastructure")]
namespace Calcis.Modules.Base.Core
{
    internal class BaseCoreLayer : ILayer
    {
        public void Register(IServiceCollection service)
        {
        }
    }
}
