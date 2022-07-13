using Market.API.Data.Interfaces;
using Market.API.Entities;
using MongoDB.Driver;

namespace Market.API.Data
{
    public class MarketContext : IMarketContext
    {
        public MarketContext(IConfiguration configuration)
        {            
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Companies = database.GetCollection<Company>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            MarketContextSeed.SeedData(Companies);
        }

        public IMongoCollection<Company> Companies { get; }
    }
}
