using Market.API.Data.Interfaces;
using Market.API.Entities;
using Market.API.Repositories.Interfaces;
using MongoDB.Driver;

namespace Market.API.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly IMarketContext _context;

        public StockRepository(IMarketContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Stock>> GetStocks()
        {
            return await _context
                            .Stocks
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task AddStock(Stock stock)
        {
            await _context.Stocks.InsertOneAsync(stock);
        }

        public async Task<List<Stock>> GetStockPrice(string companycode, DateTime startdate, DateTime enddate)
        {
            return await _context
                           .Stocks
                           .Find(
                                    x => x.CreatedOn > startdate &&
                                    x.CreatedOn < enddate && x.CompanyCode == companycode
                                 ).ToListAsync();

        }

        public async Task<bool> DeleteStock(string companycode)
        {
            FilterDefinition<Stock> filter = Builders<Stock>.Filter.Eq(p => p.CompanyCode, companycode);

            DeleteResult deleteResult = await _context
                                                .Stocks
                                                .DeleteManyAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

    }
}
