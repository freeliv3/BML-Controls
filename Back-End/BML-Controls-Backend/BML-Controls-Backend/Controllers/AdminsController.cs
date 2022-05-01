using AutoMapper;
using BML_Controls_Backend.API.Domain.Services;
using BML_Controls_Backend.API.Extentions;
using BML_Controls_Backend.Domain.Models;
using BML_Controls_Backend.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BML_Controls_Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminsController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all admins")]
        [ProducesResponseType(typeof(IEnumerable<AdminResource>), 200)]
        public async Task<IEnumerable<AdminResource>> GetAllAsync()
        {
            var admins = await _adminService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Admin>, IEnumerable<AdminResource>>(admins);
            return resources;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "List an admin by id")]
        [ProducesResponseType(typeof(AdminResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _adminService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var adminResource = _mapper.Map<Admin, AdminResource>(result.Resource);
            return Ok(adminResource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an admin")]
        [ProducesResponseType(typeof(AdminResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAdminResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var admin = _mapper.Map<SaveAdminResource, Admin>(resource);
            var result = await _adminService.UpdateAsync(id, admin);
            if (!result.Success)
                return BadRequest(result.Message);
            var adminResource = _mapper.Map<Admin, AdminResource>(result.Resource);
            return Ok(adminResource);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete an admin")]
        [ProducesResponseType(typeof(AdminResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _adminService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var adminResource = _mapper.Map<Admin, AdminResource>(result.Resource);
            return Ok(adminResource);
        }
    }
}
