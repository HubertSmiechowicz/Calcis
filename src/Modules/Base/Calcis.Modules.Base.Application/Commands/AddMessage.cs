using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calcis.Modules.Base.Core;
using Calcis.Modules.Base.Application.DTO;

namespace Calcis.Modules.Base.Application.Commands
{
    public class AddMessage : IRequest<MessageDto>
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
}
