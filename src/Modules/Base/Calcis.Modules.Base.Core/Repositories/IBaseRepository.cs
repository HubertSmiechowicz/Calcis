using Calcis.Modules.Base.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Core.Repositories
{
    internal interface IBaseRepository
    {
        List<Message> GetMessages();

        Message GetMessage(string id);

        void AddMessage(Message message);
    }
}
