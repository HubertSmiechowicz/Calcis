using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calcis.Modules.Base.Core;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Calcis.Modules.Base.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class BaseController : ControllerBase
    {
        private IBaseService BaseService { get; }
        public BaseController(IBaseService baseService) 
        {
            BaseService = baseService;
        }

        [HttpGet]
        [SwaggerOperation("Hello")]
        public ActionResult<string> Hello()
        {
            return "Hello";
        }

        [HttpPost]
        public ActionResult<Message> SendMessage([FromQuery] string message)
        {
            return Ok(BaseService.CreateMessage(message));
        }
    }
}
