using Calcis.Modules.Base.Application.DTO;
using Calcis.Modules.Base.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Application.Queries.Handlers
{
    internal class GetMessageHandler : IRequestHandler<GetMessage, MessageDto>
    {
        private IBaseRepository BaseRepository { get; }

        public GetMessageHandler(IBaseRepository baseRepository) 
        {
            BaseRepository = baseRepository;
        }

        public Task<MessageDto> Handle(GetMessage request, CancellationToken cancellationToken)
        {
            var entity = BaseRepository.GetMessage(request.Id);

            return Task.FromResult(new MessageDto()
            {
                Name = entity.Name,
                Value = entity.Value,
            });
        }
    }
}
