using FlightTickets.ConsumerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightTickets.ConsumerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly ILogger<ConsumerController> _logger;
        private readonly IConsumerService _consumerService;

        public ConsumerController(ILogger<ConsumerController> logger, IConsumerService consumerService)
        {
            _logger = logger;
            _consumerService = consumerService;
        }

        [HttpPost]
        public async Task<IActionResult> TicketSaveDatabase()
        {
            try
            {
                _logger.LogInformation("Starting to process tickets from queues.");
                await _consumerService.GetTicketsFromQueueAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
