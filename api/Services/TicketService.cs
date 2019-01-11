using System.Collections.Generic;
using System.Linq;
using Ticketing.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace Ticketing.API.Services
{
    public class TicketService
    {
        private readonly IMongoCollection<Ticket> _tickets;
        private readonly ConnectionFactory _factory;
        private IOptionsSnapshot<AppConfiguration> _appSettings;

        public TicketService(IConfiguration config, IOptionsSnapshot<AppConfiguration> appSettings)
        {
            _appSettings = appSettings;

            _factory = new ConnectionFactory() { HostName = config.GetConnectionString("Messaging") };
            _factory.UserName = _appSettings.Value.MessagingUsername;
            _factory.Password = _appSettings.Value.MessagingPassword;
            
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

        public TicketStatus Create(Ticket ticket)
        {
            _tickets.InsertOne(ticket);
            var queued = this.Send(ticket);
            var ticketStatus = new TicketStatus(ticket, queued);
            return ticketStatus;
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

        private bool Send(Ticket ticket)
        {
            var queued = false;
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _appSettings.Value.MessagingQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var ticketJson = JsonConvert.SerializeObject(ticket);
                var ticketBase64Encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(ticketJson));
                byte[] ticketByte = Convert.FromBase64String(ticketBase64Encoded);
                var body = ticketByte;
                channel.BasicPublish(exchange: "", routingKey: _appSettings.Value.MessagingQueue, basicProperties: null, body: body);
                queued = true;
            }
            return queued;
        }
    }
}