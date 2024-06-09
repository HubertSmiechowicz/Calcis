﻿using Calcis.Modules.Base.Infrastructure.DAO;
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
    internal class BaseDbContext
    {
        private readonly IMongoDatabase Database;

        public BaseDbContext(IMongoClient mongoClient, IOptions<MongoDbSettings> settings)
        {
            Database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoCollection<MessageDao> Messages => Database.GetCollection<MessageDao>("Messages");

    }
}
