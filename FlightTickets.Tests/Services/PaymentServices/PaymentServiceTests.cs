using Bogus;
using FlightTickets.Models.Models;
using FlightTickets.PaymentAPI.Services;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System.Reflection;

namespace FlightTickets.Tests.Services.PaymentServices
{
    public class PaymentServiceTests
    {
        private readonly ILogger<PaymentService> _logger;
        private readonly PaymentService _paymentService;
        private readonly Faker<Ticket> _ticketFaker;

        public PaymentServiceTests()
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            _logger = loggerFactory.CreateLogger<PaymentService>();

            _paymentService = new PaymentService();
            _ticketFaker = new Faker<Ticket>()
                .RuleFor(ticket => ticket.Id, faker => ObjectId.GenerateNewId())
                .RuleFor(ticket => ticket.PassengerName, faker => faker.Person.FullName)
                .RuleFor(ticket => ticket.Price, faker => faker.Random.Decimal(100, 2000));
        }

        [Theory]
        [InlineData(500, "TicketsApproved")]
        [InlineData(800, "TicketsApproved")]
        [InlineData(1200, "TicketsDenied")]
        [InlineData(2500, "TicketsDenied")]
        public async Task ValidatePaymentTicketCorrectQueue(decimal price, string queue)
        {
            //arrange
            var ticket = _ticketFaker.Generate();
            Assert.Equal(ticket.Price, price);

            //act
            await InvokeValidatePaymentTicketAsync(ticket);

            //assert
            string actualQueue = price < 1000 ? "TicketsApproved" : "TicketsDenied";
            Assert.Equal(queue, actualQueue);
        }

        [Fact]
        public void GenerateValidTicket_ShouldHaveCorrectStructure()
        {
            var ticket = _ticketFaker.Generate();

            Assert.NotNull(ticket.Id);
            Assert.NotNull(ticket.PassengerName);
            Assert.True(ticket.Price > 0);
        }

        private async Task InvokeValidatePaymentTicketAsync(Ticket ticket)
        {
            var method = typeof(PaymentService)
                .GetMethod("ValidatePaymentTicket",
                    BindingFlags.NonPublic | BindingFlags.Instance)!;

            await (Task)method.Invoke(_paymentService, new object?[] { ticket })!;
        }
    }
}
