using Business.Interfaces;
using Business.Models;
using Business.View;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeDetailController : ControllerBase
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
                var employees = await _employeeDetailManager.GetAllEmployeeDetails();

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpGet("Employee/{id:int}")]
        public async Task<ActionResult<EmployeeDetailView>> GetEmployeeDetailById(int id)
        {
            try
            {
                return await _employeeDetailManager.GetEmployeeDetailById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDetailView>> CreateEmployeeDetail(EmployeeDetailModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return null;

                return await _employeeDetailManager.CreateEmployeeDetail(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpGet("Department/{DepartmentId:int}")]
        public async Task<ActionResult<EmployeeDetailView>> GetEmployeeDetailsByDepartment(int DepartmentId)
        {
            try
            {
                var employees = await _employeeDetailManager.GetEmployeeDetailsByDepartment(DepartmentId);

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeDetailView>> UpdateEmployeeDetail(int id, EmployeeDetailModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return null;

                return await _employeeDetailManager.UpdateEmployeeDetail(id, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteEmployeeDetail(int id)
        {
            try
            {
                return await _employeeDetailManager.DeleteEmployeeDetail(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }
    }
}