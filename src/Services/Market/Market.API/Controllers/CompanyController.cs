using Market.API.Entities;
using Market.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/Market/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyRepository repository, ILogger<CompanyController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _repository.GetCompanies();
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error occured while fetching user");
                throw;
            }
        }

    }
}
