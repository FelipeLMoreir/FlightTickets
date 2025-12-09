using MongoDB.Bson;

namespace FlightTickets.Models.DTOs
{
    public class TicketRequestDTO
    {
        public string PassengerName { get; init; } = string.Empty;
        public string FlightNumber { get; init; } = string.Empty;
        public string SeatNumber { get; init; } = string.Empty;
        public decimal Price { get; init; } = 0;
    }
}
