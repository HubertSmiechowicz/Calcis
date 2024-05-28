using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calcis.Modules.Base.Core;
using Microsoft.AspNetCore.Mvc;

namespace Calcis.Modules.Base.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        private IBaseService BaseService { get; }
        public BaseController(IBaseService baseService) 
        {
            BaseService = baseService;
        }

        [HttpGet]
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
