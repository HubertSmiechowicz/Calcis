using Calcis.Modules.Employee.Infrastructure.RabbitMq;
using Calcis.Shared.Abstractions.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Calcis.Modules.Employee.Api")]
namespace Calcis.Modules.Employee.Infrastructure
{
    public class EmployeeInfrastructureLayer : ILayer
    {
        public void Register(IServiceCollection service)
        {
            service.AddHostedService<RabbitMqListener>();
        }
    }
}
