namespace FlightTickets.ConsumerAPI.Data
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } 
        public string DatabaseName { get; set; }
        public string CollectionNameApproved { get; set; } 
        public string CollectionNameDenied { get; set; } 
    }
}