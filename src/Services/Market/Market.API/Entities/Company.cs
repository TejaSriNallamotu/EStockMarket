using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Market.API.Entities
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Code { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string CEO { get; set; }

        //[Range(100000000, double.MaxValue, ErrorMessage = "Turnover must be greater than 10Cr.")]
        public decimal TurnOver { get; set; }

        [BsonElement("Url")]
        public string Website { get; set; }
        public string Exchange { get; set; }
    }
}
