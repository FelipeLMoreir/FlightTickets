using FlightTickets.Models.DTOs;

namespace FlightTickets.OrderAPi.Services.Interfaces
{
    public interface ITicketService
    {
        Task<TicketResponseDTO> CreateTicketAsync(TicketRequestDTO ticketRequest);
    }
}
