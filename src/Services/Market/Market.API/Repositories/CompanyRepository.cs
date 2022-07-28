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

        public async Task<Company> GetCompany(string companycode)
        {
            return await _context
                           .Companies
                           .Find(p => p.Code == companycode)
                           .FirstOrDefaultAsync();
        }

        public async Task Register(Company company)
        {
            await _context.Companies.InsertOneAsync(company);
        }

        public async Task<bool> DeleteCompany(string companycode)
        {
            FilterDefinition<Company> filter = Builders<Company>.Filter.Eq(p => p.Code, companycode);

            DeleteResult deleteResult = await _context
                                                .Companies
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

    }
}
