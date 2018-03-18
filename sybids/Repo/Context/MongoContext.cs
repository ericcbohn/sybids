using Microsoft.Extensions.Options;
using MongoDB.Driver;
using sybids.Models;

namespace sybids.Repo.Context
{
    public sealed class MongoContext 
    {
        private readonly IMongoDatabase _database = null;

        public MongoContext(IOptions<Settings> settings) {
            var client = new MongoClient(settings.Value.ConnectionString);
            if(client != null) _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<PairingModel> Pairings {
            get { return _database.GetCollection<PairingModel>("pairings"); }
        }

        public IMongoCollection<LineModel> Lines {
            get { return _database.GetCollection<LineModel>("lines"); }
        }
    }
}