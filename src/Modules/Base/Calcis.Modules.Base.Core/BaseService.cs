using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Core
{
    public class BaseService : IBaseService
    {
        public Message CreateMessage(string message)
        {
            return Message.CreateMessage("base", message);
        }
    }
}
