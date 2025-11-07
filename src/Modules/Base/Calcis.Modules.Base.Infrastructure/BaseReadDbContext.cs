using Calcis.Modules.Base.Infrastructure.DAO;
using Calcis.Shared.Infrastructure.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Calcis.Modules.Base.Infrastructure
{
    internal class BaseReadDbContext : DbContext
    {
        public BaseReadDbContext(IWriteMongoClient writeClient, IReadMongoClient readClient, IOptions<MongoDbSettings> settings) : base(readClient, writeClient, settings)
        {
        }

        public IMongoCollection<MessageDao> Messages => ReadDB.GetCollection<MessageDao>("Messages");
    }
}
