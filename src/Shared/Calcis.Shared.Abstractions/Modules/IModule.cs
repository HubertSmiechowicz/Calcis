using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Shared.Abstractions.Modules
{
    public interface IModule
    {
        void Register(IServiceCollection services, IMvcBuilder mvc);
    }
}
