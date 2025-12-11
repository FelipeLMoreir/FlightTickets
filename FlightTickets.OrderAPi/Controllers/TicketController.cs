using FlightTickets.Models.DTOs;
using FlightTickets.OrderAPi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightTickets.OrderAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ILogger<TicketController> _logger;

        public TicketController(ITicketService ticketService, ILogger<TicketController> logger)
        {
            _ticketService = ticketService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicketAsync([FromBody] TicketRequestDTO ticket)
        {
            _logger.LogInformation("Creating a new ticket");

            var creatdTicket = await _ticketService.CreateTicketAsync(ticket);

            return Ok(creatdTicket);
            //return CreatedAtAction(nameof(GetTicketById), new { id = creatdTicket.Id }, creatdTicket);
        }
    }
}
