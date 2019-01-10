using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ticketing.API.Models
{
    public class TicketStatus : Ticket
    {
        public TicketStatus(Ticket ticket)
        {
            Id = ticket.Id;
            TicketBrowser = ticket.TicketBrowser;
            TicketCategory = ticket.TicketCategory;
            TicketName = ticket.TicketName;
            TicketSpeaker = ticket.TicketSpeaker;
            Queued = false;
        }

        public TicketStatus(Ticket ticket, bool queued)
        {
            Id = ticket.Id;
            TicketBrowser = ticket.TicketBrowser;
            TicketCategory = ticket.TicketCategory;
            TicketName = ticket.TicketName;
            TicketSpeaker = ticket.TicketSpeaker;
            Queued = queued;
        }
        public bool Queued { get; set; }
    }
}