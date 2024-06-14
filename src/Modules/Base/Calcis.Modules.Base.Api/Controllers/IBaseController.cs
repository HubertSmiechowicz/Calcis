using Calcis.Modules.Base.Application.Commands;
using Calcis.Modules.Base.Application.DTO;
using Calcis.Modules.Base.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Calcis.Modules.Base.Api.Controllers
{
    public interface IBaseController
    {
        MessageDto GetMessage(GetMessage query);
        List<MessageDto> Hello(Hello query);
        MessageDto SendMessage(AddMessage command);
    }
}