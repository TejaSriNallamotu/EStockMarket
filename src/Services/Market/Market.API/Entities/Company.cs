using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Market.API.Entities
{
    public class Company
    {
        [BsonId]
        public string Code { get; set; }
        public string Name { get; set; }
        public string CEO { get; set; }

        [Range(100000000.0d, (double)decimal.MaxValue, ErrorMessage = "Turnover must be greater than 10Cr.")]
        public decimal TurnOver { get; set; }

        [BsonElement("Url")]
        public string Website { get; set; }
        public string Exchange { get; set; }

    }
}
