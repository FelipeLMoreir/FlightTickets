using Bogus;
using FlightTickets.Models.DTOs;
using FlightTickets.Models.Models;
using FlightTickets.OrderAPi.Controllers;
using FlightTickets.OrderAPi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlightTickets.Tests.Controllers.OrderController
{
    public class OrderControllerTest
    {
        private readonly ILogger<TicketController> _logger;

        private readonly TicketService _ticketService;

        private readonly TicketController _ticketController;

        private readonly Faker<TicketRequestDTO> _ticketFaker;

        public OrderControllerTest()
        {
            _logger = new LoggerFactory().CreateLogger<TicketController>();
            _ticketService = new TicketService();
            _ticketController = new TicketController(_ticketService, _logger);

            _ticketFaker = new Faker<TicketRequestDTO>()
                .RuleFor(ticket => ticket.PassengerName, faker => faker.Person.FullName)
                .RuleFor(ticket => ticket.Price, faker => faker.Random.Decimal(100, 2000))
                .RuleFor(ticket => ticket.FlightNumber, faker => faker.Random.Guid().ToString());
        }

        [Fact]
        public void CreateTicketMustReturnOk()
        {
            //Arrange
            var ticketRequest = _ticketFaker.Generate();

            // Act
            var result = _ticketController.CreateTicketAsync(ticketRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
