using Market.API.Entities;
using Market.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [ApiController]
    [Route("api/v1.0/market/[controller]")]
    public class stockController : ControllerBase
    {
        private readonly IStockRepository _repository;
        private readonly ILogger<companyController> _logger;

        public stockController(IStockRepository repository, ILogger<companyController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _repository.GetStocks();
            return Ok(stocks);
        }

        [HttpPost]
        [Route("add/{companycode}")]
        public async Task<IActionResult> AddStock(Stock stock)
        {
            try
            {
                await _repository.AddStock(stock);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Invalid Stock.");
            }
        }

        [HttpGet]
        [Route("get/{companycode}/{startdate}/{enddate}")]
        public async Task<IActionResult> GetCompanyDetails(string companycode,DateTime startdate, DateTime enddate)
        {
            var company = await _repository.GetStockPrice(companycode, startdate, enddate);
            return Ok(company);
        }

        [HttpDelete]
        [Route("delete/{companycode}")]
        public async Task<IActionResult> DeleteStockByCode(string companycode)
        {
            return Ok(await _repository.DeleteStock(companycode));
        }

    }
}
