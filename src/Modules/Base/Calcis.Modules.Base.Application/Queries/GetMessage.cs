using Calcis.Modules.Base.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Application.Queries
{
    public class GetMessage : IRequest<MessageDto>
    {
        public string Id { get; set; }
    }
}
