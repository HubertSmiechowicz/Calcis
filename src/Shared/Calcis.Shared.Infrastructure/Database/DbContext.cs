using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Shared.Infrastructure.Database
{
    public abstract class DbContext
    {
        protected readonly IMongoDatabase Database;

        public DbContext(IMongoClient mongoClient, IOptions<MongoDbSettings> settings)
        {
            Database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        }
    }
}
