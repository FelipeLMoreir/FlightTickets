using Bogus;
using FlightTickets.Models.DTOs;
using FlightTickets.OrderAPi.Services;
using FlightTickets.OrderAPi.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FlightTickets.Tests.Services.OrderServices
{
    public class OrderServiceTests
    {
        private readonly ITicketService _ticketService;
        private readonly ILogger<TicketService> _logger;
        private readonly Faker<TicketRequestDTO> _ticketRequestFaker;

        public OrderServiceTests()
        {
            _logger = new LoggerFactory().CreateLogger<TicketService>();
            _ticketService = new TicketService();

            _ticketRequestFaker = new Faker<TicketRequestDTO>()
                .RuleFor(t => t.PassengerName, f => f.Person.FullName)
                .RuleFor(t => t.FlightNumber, f => $"FL-{f.Random.Number(1000, 9999)}")
                .RuleFor(t => t.SeatNumber, f => $"A{f.Random.Number(1, 50)}")
                .RuleFor(t => t.Price, f => f.Random.Decimal(100, 2000));
        }

        [Fact]
        public async Task CreateTicketAsync_MustReturnTicketResponseDTO()
        {
            // Arrange
            var ticketRequest = _ticketRequestFaker.Generate();

            // Act
            var result = await _ticketService.CreateTicketAsync(ticketRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TicketResponseDTO>(result);
            Assert.NotNull(result.Id);
            Assert.Equal(ticketRequest.PassengerName, result.PassengerName);
            Assert.Equal(ticketRequest.FlightNumber, result.FlightNumber);
            Assert.Equal(ticketRequest.SeatNumber, result.SeatNumber);
            Assert.Equal(ticketRequest.Price, result.Price);
        }
    }
}
