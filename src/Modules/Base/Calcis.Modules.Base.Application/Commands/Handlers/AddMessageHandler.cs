using Calcis.Modules.Base.Application.DTO;
using Calcis.Modules.Base.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Application.Commands.Handlers
{
    internal class AddMessageHandler : IRequestHandler<AddMessage, MessageDto>
    {
        public Task<MessageDto> Handle(AddMessage request, CancellationToken cancellationToken)
        {
            var message = Message.CreateMessage(request.Name, request.Value);

            var messageDto = new MessageDto()
            {
                Name = message.Name,
                Value = message.Value
            };

            return Task.FromResult(messageDto);
        }
    }
}
