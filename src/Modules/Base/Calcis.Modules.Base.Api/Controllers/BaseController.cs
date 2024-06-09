using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calcis.Modules.Base.Application.Commands;
using Calcis.Modules.Base.Application.DTO;
using Calcis.Modules.Base.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Calcis.Modules.Base.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class BaseController : ControllerBase
    {
        private IMediator Mediator { get; }

        public BaseController(IMediator mediator) 
        {
            Mediator = mediator;
        }

        [HttpGet("hello")]
        public ActionResult<List<MessageDto>> Hello([FromQuery] Hello query)
        {
            var response = Mediator.Send(query);

            return response.Result;
        }

        [HttpPost("message")]
        public ActionResult<MessageDto> SendMessage([FromBody] AddMessage command)
        {
            var response = Mediator.Send(command);

            return response.Result;
        }
    }
}
