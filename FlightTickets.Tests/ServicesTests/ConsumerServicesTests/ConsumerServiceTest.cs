using DnsClient.Internal;
using FlightTickets.ConsumerAPI.Data;
using FlightTickets.ConsumerAPI.Repositories;
using FlightTickets.ConsumerAPI.Services;
using FlightTickets.Models.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightTickets.Tests.Services.ConsumerServicesTests
{
    public class ConsumerServiceTest
    {
        private readonly ILogger<ConsumerService> _loggerService;
        private readonly ILogger<ConsumerRepository> _loggerRepository;
        private readonly ConsumerRepository _consumerRepository;
        private readonly ConsumerService _consumerService;
        private readonly IMongoCollection<Ticket> _collectionApproved;
        private readonly IMongoCollection<Ticket> _collectionDenied;

        public ConsumerServiceTest(ConnectionDB connection)
        {
            _loggerService = new LoggerFactory().CreateLogger<ConsumerService>();
            _loggerRepository = new LoggerFactory().CreateLogger<ConsumerRepository>();
            _collectionApproved = connection.GetMongoCollectionApproved();
            _collectionDenied = connection.GetMongoCollectionDenied();
            _consumerRepository = new ConsumerRepository(_loggerRepository, connection);
        }

        //public void 
    }
}
