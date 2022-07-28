using Market.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.API.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();

        Task<Company> GetCompany(string companycode);

        Task Register(Company company);

        Task<bool> DeleteCompany(string companycode);

    }
}
