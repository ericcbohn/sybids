using System;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using sybids.Models;

namespace sybids.Repo {
    public class BidContext {
        private readonly IMongoDatabase _database = null;

        public BidContext(IOptions<Settings> settings) {
            var client = new MongoClient(settings.Value.ConnectionString);
            if(client != null) _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<BidModel> Bid {
            get { return _database.GetCollection<BidModel>("bid"); }
        }

        public IMongoCollection<PairingModel> Pairing {
            get { return _database.GetCollection<PairingModel>("pairing"); }
        }

        // public IMongoCollection<LineModel> Lines {
        //     get { return _database.GetCollection<LineModel>("lines"); }
        // }
    }
}