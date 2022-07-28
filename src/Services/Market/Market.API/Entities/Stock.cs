using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Market.API.Entities
{
    public class Stock
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CompanyCode { get; set; }
        public decimal Price { get; set; }

        [BsonDateTimeOptions]
        public DateTime CreatedOn { get; set; }
    }   
}
