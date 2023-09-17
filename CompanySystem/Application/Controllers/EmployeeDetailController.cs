using Business.Interfaces;
using Business.Models;
using Business.View;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeDetailController
	{
        private readonly IEmployeeDetailManager _employeeDetailManager;

        public EmployeeDetailController(IEmployeeDetailManager employeeDetailManager)
        {
            _employeeDetailManager = employeeDetailManager;
        }

        [HttpGet]
        public async Task<ActionResult<IList<EmployeeDetailView>>> GetAllEmployeeDetails()
        {
            try
            {
                var employee = await _employeeDetailManager.GetAllEmployeeDetails();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }
    }
}

