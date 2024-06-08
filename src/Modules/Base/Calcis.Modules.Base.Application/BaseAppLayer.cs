using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Calcis.Modules.Base.Api")]
[assembly: InternalsVisibleTo("Calcis.Bootstraper")]
namespace Calcis.Modules.Base.Application
{
    internal class BaseAppLayer : ILayer
    {
        public void Register(IServiceCollection service)
        {
        }
    }
}
