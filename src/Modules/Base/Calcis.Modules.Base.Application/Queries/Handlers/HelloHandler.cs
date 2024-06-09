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
    internal class HelloHandler : IRequestHandler<Hello, List<MessageDto>>
    {
        private IBaseRepository BaseRepository { get; }

        public HelloHandler(IBaseRepository baseRepository)
        {
            BaseRepository = baseRepository;
        }

        Task<List<MessageDto>> IRequestHandler<Hello, List<MessageDto>>.Handle(Hello request, CancellationToken cancellationToken)
        {
            var messages = BaseRepository.GetMessages();
            var result = new List<MessageDto>();

            foreach (var message in messages) 
            {
                result.Add(new MessageDto()
                {
                    Name = message.Name,
                    Value = message.Value
                });
            }

            return Task.FromResult(result);
        }
    }
}
