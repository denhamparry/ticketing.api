using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ticketing.API.Models
{
    public class Ticket
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string TicketName { get; set; }

        [BsonElement("Browser")]
        public string TicketBrowser { get; set; }

        [BsonElement("Category")]
        public string TicketCategory { get; set; }

        [BsonElement("Speaker")]
        public string TicketSpeaker { get; set; }
    }
}