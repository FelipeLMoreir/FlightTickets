using FlightTickets.ConsumerAPI.Data;
using FlightTickets.ConsumerAPI.Repositories;
using FlightTickets.Models.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FlightTickets.Tests.RepositoryTests.ConsumerRepositoryTests
{
    public class ConsumerRepositoryTest
    {
        private readonly ILogger<ConsumerRepository> _logger;
        private readonly IMongoCollection<Ticket> _collectionApproved;
        private readonly IMongoCollection<Ticket> _collectionDenied;

        public ConsumerRepositoryTest(ConnectionDB connection)
        {
            _logger = new LoggerFactory().CreateLogger<ConsumerRepository>();
            _collectionApproved = connection.GetMongoCollectionApproved();
            _collectionDenied = connection.GetMongoCollectionDenied();
        }


    }
}
