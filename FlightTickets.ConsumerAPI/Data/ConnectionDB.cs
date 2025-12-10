using FlightTickets.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlightTickets.ConsumerAPI.Data
{
    public class ConnectionDB
    {
        public readonly IMongoCollection<Ticket> mongoCollectionApproved;
        public readonly IMongoCollection<Ticket> mongoCollectionDenied;

        public ConnectionDB(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            mongoCollectionApproved = database.GetCollection<Ticket>(mongoDBSettings.Value.CollectionNameApproved);
            mongoCollectionDenied = database.GetCollection<Ticket>(mongoDBSettings.Value.CollectionNameDenied);
        }
        public IMongoCollection<Ticket> GetMongoCollectionApproved()
        {
            return mongoCollectionApproved;
        }

        public IMongoCollection<Ticket> GetMongoCollectionDenied()
        {
            return mongoCollectionDenied;
        }
    }
}
