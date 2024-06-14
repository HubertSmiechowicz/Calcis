using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calcis.Modules.Base.Application.Commands;
using Calcis.Modules.Base.Application.DTO;
using Calcis.Modules.Base.Application.Queries;
using Calcis.Shared.Infrastructure.Logging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Swashbuckle.AspNetCore.Annotations;

namespace Calcis.Modules.Base.Api.Controllers
{
    internal class BaseController : IBaseController
    {
        private IMediator Mediator { get; }
        private Logger<BaseController> Logger { get; }

        public BaseController(IMediator mediator, Logger<BaseController> logger)
        {
            Mediator = mediator;
            Logger = logger;
        }

        public List<MessageDto> Hello(Hello query)
        {
            var response = Mediator.Send(query);

            return response.Result;
        }

        public MessageDto GetMessage(GetMessage query)
        {
            var response = Mediator.Send(query);

            return response.Result;
        }

        public MessageDto SendMessage(AddMessage command)
        {
            if ((command.Name == null || command.Name == "") || (command.Value == null || command.Value == ""))
            {
                var ex = new ArgumentNullException();
                Logger.LogError(ex, $"Name or Value cannot be empty\n {ex.StackTrace}");
            }

            var response = Mediator.Send(command);

            return response.Result;
        }
    }
}
