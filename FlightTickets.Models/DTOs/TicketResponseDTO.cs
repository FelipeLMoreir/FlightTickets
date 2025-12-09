using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightTickets.Models.DTOs
{
    public class TicketResponseDTO
    {
        [BsonId]
        public string Id { get; init; } = string.Empty;
        public string PassengerName { get; init; } = string.Empty;
        public string FlightNumber { get; init; } = string.Empty;
        public string SeatNumber { get; init; } = string.Empty;
        public decimal Price { get; init; } = 0;
    }
}
