using FlightTickets.PaymentAPI.Controllers;
using FlightTickets.PaymentAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlightTickets.Tests.Controllers.PaymentControllerTests
{
    public class PaymentControllerTest
    {
        private readonly ILogger<PaymentController> _logger;
                
        private readonly PaymentService _paymentService;
                
        private readonly PaymentController _paymentController;

        public PaymentControllerTest()
        {
            _logger = new LoggerFactory().CreateLogger<PaymentController>();
            _paymentService = new PaymentService();
            _paymentController = new PaymentController(_logger, _paymentService);
        }

        [Fact]
        //[Trait("VerbosHTTP", "Get")]
        public void ProcessPaymentMustReturnOkResult()
        {
            //Act
            var result = _paymentController.Get().Result;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }
    }
}
