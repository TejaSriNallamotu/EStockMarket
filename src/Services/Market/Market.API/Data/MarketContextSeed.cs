using Market.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Market.API.Data
{
    public class MarketContextSeed
    {
        public static void SeedData(IMongoCollection<Company> companyCollection)
        {
            bool existProduct = companyCollection.Find(p => true).Any();
            if (!existProduct)
            {
                companyCollection.InsertManyAsync(GetPreconfiguredProducts());  
            }
        }

        private static IEnumerable<Company> GetPreconfiguredProducts()
        {
            return new List<Company>()
            {
                new Company()
                {
                   Code= "1001C",
                   Name="Spotify",
                   CEO="Shantanu Narayen",
                   TurnOver=950.00M,
                   Website="https://websitebuilders.com",
                   Exchange="BSE"
                },
                new Company()
                {
                   Code= "1002C",
                   Name="Starbucks",
                   CEO="Kumar Mangalam Birla",
                   TurnOver=800.00M,
                   Website="https://www.chtips.com/disclaimer",
                   Exchange="NSE"
                }
            };
        }
    }
}
