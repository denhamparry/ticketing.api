using System.Collections.Generic;
using Ticketing.API.Models;
using Ticketing.API.Services;
using Microsoft.AspNetCore.Mvc;
using MassTransit;
using System.Threading.Tasks;

namespace Ticketing.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TicketService _ticketService;
        private readonly IBus _bus;

        public TicketsController(TicketService ticketService, IBus bus)
        {
            _ticketService = ticketService;
            _bus = bus;
        }

        [HttpGet]
        public ActionResult<List<Ticket>> Get()
        {
            return _ticketService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetTicket")]
        public ActionResult<Ticket> Get(string id)
        {
            var ticket = _ticketService.Get(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateAsync(Ticket ticket)
        {
            ticket = _ticketService.Create(ticket);
            await _bus.Publish<Ticket>(ticket);
            return CreatedAtRoute("GetTicket", new { id = ticket.Id.ToString() }, ticket);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Ticket ticketIn)
        {
            var ticket = _ticketService.Get(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _ticketService.Update(id, ticketIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var ticket = _ticketService.Get(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _ticketService.Remove(ticket.Id);

            return NoContent();
        }
    }
}