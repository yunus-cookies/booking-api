using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Models
{
    public class Booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string BookingName { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
    }
}