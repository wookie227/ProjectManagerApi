using Microsoft.AspNetCore.Mvc;
using ProjectManagerApi.Models;
using ProjectManagerApi.Services;

namespace ProjectManagerApi.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return Ok(await _companyService.GetAllCompaniesAsync());
        }
    }
}
