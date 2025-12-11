using FlightTickets.ConsumerAPI.Controllers;
using FlightTickets.ConsumerAPI.Data;
using FlightTickets.ConsumerAPI.Repositories;
using FlightTickets.ConsumerAPI.Services;
using FlightTickets.Models.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightTickets.Tests.Controllers.ConsumerControllerTests
{
    public class ConsumerControllerTest
    {
        private readonly ILogger<ConsumerController> _loggerController;
        private readonly ILogger<ConsumerRepository> _loggerRepository;
        private readonly ILogger<ConsumerService> _loggerService;
        private readonly ConsumerService _consumerService;
        private readonly ConsumerController _consumerController;
        private readonly ConsumerRepository _consumerRepository;
        private readonly IMongoCollection<Ticket> _collectionApproved;
        private readonly IMongoCollection<Ticket> _collectionDenied;

        public ConsumerControllerTest(ConnectionDB connection)
        {
            _loggerController = new LoggerFactory().CreateLogger<ConsumerController>();
            _collectionApproved = connection.GetMongoCollectionApproved();
            _collectionDenied = connection.GetMongoCollectionDenied();
            _consumerRepository = new ConsumerRepository(_loggerRepository, connection);
            _consumerService = new ConsumerService(_loggerService, _consumerRepository);
        }

        [Fact]
        public void TicketSaveDatabaseMustReturnOk()
        {
            //act
            var result = _consumerController.TicketSaveDatabase().Result;

            //assert
            Assert.NotNull(result);
            Assert.IsType<Ticket>(result);
        }
    }
}
