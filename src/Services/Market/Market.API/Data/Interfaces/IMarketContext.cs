using Market.API.Entities;
using MongoDB.Driver;

namespace Market.API.Data.Interfaces
{
    public interface IMarketContext
    {
        IMongoCollection<Company> Companies { get; }

        IMongoCollection<Stock> Stocks { get; }

    }
}
