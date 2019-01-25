using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ticketing.API.Models
{
    public class Ticket
    {
        public ObjectId Id { get; set; }

        [BsonElement("URL")]
        public string TicketURL { get; set; }
    }
}