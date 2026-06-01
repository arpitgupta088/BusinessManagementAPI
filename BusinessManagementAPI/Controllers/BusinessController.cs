using BusinessManagementAPI.Models;
using BusinessManagementAPI.Supervisor;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessSupervisor _businessSupervisor;

        public BusinessController(IBusinessSupervisor businessSupervisor)
        {
            _businessSupervisor = businessSupervisor;
        }

        [HttpGet]
        public async Task<ActionResult<List<Business>>> GetAll()
        {
            var businesses = await _businessSupervisor.GetAllAsync();
            return Ok(businesses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetById(string id)
        {
            var business = await _businessSupervisor.GetByIdAsync(id);

            if (business == null) return NotFound();

            return Ok(business);
        }

        [HttpPost]
        public async Task<IActionResult> AddBusiness([FromBody] Business business)
        {
            await _businessSupervisor.AddAsync(business);
            return Ok("Business Added Successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusiness(string id, Business business)
        {
            await _businessSupervisor.UpdateAsync(id, business);
            return Ok("Business Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(string id)
        {
            await _businessSupervisor.DeleteAsync(id);
            return Ok("Business Deleted successfully");
        }
    }
}
