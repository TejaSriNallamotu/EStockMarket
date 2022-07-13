using Market.API.Data.Interfaces;
using Market.API.Entities;
using Market.API.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.API.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IMarketContext _context;

        public CompanyRepository(IMarketContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _context
                            .Companies
                            .Find(p => true)
                            .ToListAsync();
        }

    }
}
