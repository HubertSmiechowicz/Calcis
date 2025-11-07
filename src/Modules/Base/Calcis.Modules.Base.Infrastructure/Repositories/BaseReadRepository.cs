using Calcis.Modules.Base.Core.Entities;
using Calcis.Modules.Base.Core.Repositories;
using Calcis.Modules.Base.Infrastructure.DAO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Infrastructure.Repositories
{
    internal class BaseReadRepository : IBaseReadRepository
    {
        private BaseReadDbContext Context { get; }

        public BaseReadRepository(BaseReadDbContext context) 
        {
            Context = context;
        }

        public List<Message> GetMessages()
        {
            var messages = Context.Messages.AsQueryable();
            var result = new List<Message>();

            foreach (var message in messages) 
            {
                var item = Message.CreateMessage(message.Name, message.Value);
                result.Add(item);
            }

            return result;
        }

        public Message GetMessage(string id)
        {
            var message = Context.Messages.Find(p => p.Id == id).SingleOrDefault();

            return Message.CreateMessage(message.Name, message.Value);
        }
    }
}
