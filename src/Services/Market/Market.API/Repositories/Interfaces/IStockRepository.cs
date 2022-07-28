using Market.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.API.Repositories.Interfaces
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetStocks();
        Task AddStock(Stock stock);

        Task<List<Stock>> GetStockPrice(string companycode, DateTime startdate, DateTime enddate);

        Task<bool> DeleteStock(string companycode);

    }
}
