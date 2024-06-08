using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Application.Queries.Handlers
{
    internal class HelloHandler : IRequestHandler<Hello, string>
    {
        Task<string> IRequestHandler<Hello, string>.Handle(Hello request, CancellationToken cancellationToken)
        {
            return Task.FromResult($"Hello {request.Name}");
        }
    }
}
