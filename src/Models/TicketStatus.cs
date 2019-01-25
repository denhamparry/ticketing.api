using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ticketing.API.Models
{
    public class TicketStatus : Ticket
    {
        public TicketStatus(Ticket ticket)
        {
            Id = ticket.Id;
            TicketURL = ticket.TicketURL;
            Queued = false;
        }

        public TicketStatus(Ticket ticket, bool queued)
        {
            Id = ticket.Id;
            TicketURL = ticket.TicketURL;
            Queued = queued;
        }
        public bool Queued { get; set; }
    }
}