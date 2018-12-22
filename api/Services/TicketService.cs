using System.Collections.Generic;
using System.Linq;
using Ticketing.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ticketing.API.Services
{
    public class TicketService
    {
        private readonly IMongoCollection<Ticket> _tickets;

        public TicketService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TicketingDb"));
            var database = client.GetDatabase("TicketingDb");
            _tickets = database.GetCollection<Ticket>("Tickets");
        }

        public List<Ticket> Get()
        {
            return _tickets.Find(ticket => true).ToList();
        }

        public Ticket Get(string id)
        {
            var docId = new ObjectId(id);

            return _tickets.Find<Ticket>(ticket => ticket.Id == docId).FirstOrDefault();
        }

        public Ticket Create(Ticket ticket)
        {
            _tickets.InsertOne(ticket);
            return ticket;
        }

        public void Update(string id, Ticket ticketIn)
        {
            var docId = new ObjectId(id);

            _tickets.ReplaceOne(ticket => ticket.Id == docId, ticketIn);
        }

        public void Remove(Ticket ticketIn)
        {
            _tickets.DeleteOne(ticket => ticket.Id == ticketIn.Id);
        }

        public void Remove(ObjectId id)
        {
            _tickets.DeleteOne(ticket => ticket.Id == id);
        }
    }
}