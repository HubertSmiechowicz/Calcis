using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Calcis.Modules.Base.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        public BaseController() { }

        [HttpGet]
        public ActionResult<string> Hello()
        {
            return "Hello";
        }
    }
}
