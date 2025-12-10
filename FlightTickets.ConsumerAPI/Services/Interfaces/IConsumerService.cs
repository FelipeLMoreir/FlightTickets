using FlightTickets.Models.Models;

namespace FlightTickets.ConsumerAPI.Services.Interfaces
{
    public interface IConsumerService
    {
        Task GetTicketsFromQueueAsync();
        Task SaveApprovedTicketsToCollectionAsync(Ticket ticket);
        Task SaveDeniedTicketsToCollectionAsync(Ticket ticket);
    }
}
