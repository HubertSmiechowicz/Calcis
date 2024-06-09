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
    internal class BaseRepository : IBaseRepository
    {
        private BaseDbContext Context { get; }

        public BaseRepository(BaseDbContext context) 
        {
            Context = context;
        }

        public void AddMessage(Message message)
        {
            var messageDao = new MessageDao()
            {
                Name = message.Name,
                Value = message.Value,
                CreatedDate = DateTime.Now,
            };

            Context.Messages.InsertOne(messageDao);
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
    }
}
