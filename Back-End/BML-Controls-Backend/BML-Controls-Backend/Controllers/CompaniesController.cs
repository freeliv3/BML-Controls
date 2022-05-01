using AutoMapper;
using BML_Controls_Backend.API.Extentions;
using BML_Controls_Backend.Domain.Models;
using BML_Controls_Backend.Domain.Services;
using BML_Controls_Backend.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BML_Controls_Backend.Controllers
{
    [ApiController]
    [Route("/api")]
    [Produces("application/json")]
    public class CompaniesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(IUserService userService, ICompanyService companyService, IMapper mapper)
        {
            _userService = userService;
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet("users/{userId}/companies")]
        [SwaggerOperation(Summary = "List all companies of a user")]
        public async Task<IEnumerable<CompanyResource>> GetAllByUserIdAsync(int userId)
        {
            var companies = await _companyService.FindByUserId(userId);
            var resources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

            return resources;
        }

        [HttpGet("users/{userId}/companies/{companyId}")]
        [SwaggerOperation(Summary = "List a company of a user")]
        public async Task<IEnumerable<CompanyResource>> GetAllByUserIdAndCompanyIdAsync(int userId, int companyId)
        {
            var companies = await _companyService.GetByUserIdAndCompanyId(userId, companyId);
            var resources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

            return resources;
        }

        [HttpPost("users/{userId}/companies")]
        [SwaggerOperation(Summary = "Create a company for a user")]
        public async Task<IActionResult> PostAsync(int userId, [FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var company = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _companyService.SaveAsync(userId, company);

            if (!result.Success)
                return BadRequest(result.Message);

            var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }

        [HttpDelete("users/{userId}/companies/{companyId}")]
        [SwaggerOperation(Summary = "Delete a company of a user")]
        public async Task<IActionResult> DeleteAsync(int userId)
        {
            var result = await _companyService.DeleteAsync(userId);
            if (!result.Success)
                return BadRequest(result.Message);

            var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }

    }
}
