using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Shared.Infrastructure.Database
{
    public abstract class MongoDbContext
    {
        protected readonly IMongoDatabase WriteDB;
        protected readonly IMongoDatabase ReadDB;

        protected MongoDbContext(
            IReadMongoClient readClient,
            IWriteMongoClient writeClient,
            IOptions<MongoDbSettings> settings)
        {
            ReadDB = readClient.GetDatabase(settings.Value.ReadDatabase);
            WriteDB = writeClient.GetDatabase(settings.Value.WriteDatabase);
        }
    }

    public interface IWriteMongoClient
    {
        IMongoDatabase GetDatabase(string databaseName);
    }

    public interface IReadMongoClient
    {
        IMongoDatabase GetDatabase(string databaseName);
    }

    public class WriteMongoClient : IWriteMongoClient
    {
        private readonly MongoClient _client;

        public WriteMongoClient(string connectionString)
        {
            _client = new MongoClient(connectionString);
        }

        public IMongoDatabase GetDatabase(string databaseName)
        {
            return _client.GetDatabase(databaseName);
        }
    }

    public class ReadMongoClient : IReadMongoClient
    {
        private readonly MongoClient _client;

        public ReadMongoClient(string connectionString)
        {
            _client = new MongoClient(connectionString);
        }

        public IMongoDatabase GetDatabase(string databaseName)
        {
            return _client.GetDatabase(databaseName);
        }
    }
}
