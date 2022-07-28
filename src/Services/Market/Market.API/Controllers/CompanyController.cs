using Market.API.Entities;
using Market.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/market/[controller]")]
    public class companyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly ILogger<companyController> _logger;

        public companyController(ICompanyRepository repository, ILogger<companyController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _repository.GetCompanies();
            return Ok(companies);
        }

        [HttpGet]
        [Route("info/{companycode}", Name = "GetCompanyInfo")]
        public async Task<IActionResult> GetCompanyDetails(string companycode)
        {
            var company = await _repository.GetCompany(companycode);
            if (company == null)
            {
                _logger.LogError($"Company code: {companycode}, is not found.");
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Company company)
        {
            await _repository.Register(company);
            return CreatedAtRoute("GetCompanyInfo", new { companycode = company.Code }, company);
        }

        [HttpDelete]
        [Route("delete/{companycode}")]

        public async Task<IActionResult> DeleteCompanyByCode(string companycode)
        {
            return Ok(await _repository.DeleteCompany(companycode));
        }

    }
}
