using FlightTickets.ConsumerAPI.Data;
using FlightTickets.ConsumerAPI.Repositories.Interfaces;
using FlightTickets.Models.Models;
using MongoDB.Driver;

namespace FlightTickets.ConsumerAPI.Repositories
{
    public class ConsumerRepository : IConsumerRepository
    {
        private readonly ILogger<ConsumerRepository> _logger;
        private readonly IMongoCollection<Ticket> _collectionApproved;
        private readonly IMongoCollection<Ticket> _collectionDenied;

        public ConsumerRepository(ILogger<ConsumerRepository> logger, ConnectionDB connection)
        {
            _logger = logger;
            _collectionApproved = connection.GetMongoCollectionApproved();
            _collectionDenied = connection.GetMongoCollectionDenied();
        }
    
        public async Task SaveApprovedTicketsAsync(Ticket ticket)
        {
            try
            {
                _logger.LogInformation("Saving approved ticket: {TicketId} - {PassengerName}", ticket.Id, ticket.PassengerName);
                await _collectionApproved.InsertOneAsync(ticket);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving approved ticket");
                throw;
            }
        }

        public async Task SaveDeniedTicketsAsync(Ticket ticket)
        {
            try
            {
                _logger.LogInformation("Saving denied ticket: {TicketId} - {PassengerName}", ticket.Id, ticket.PassengerName);
                await _collectionDenied.InsertOneAsync(ticket);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving denied ticket");
                throw;
            }
        }
    }
}
