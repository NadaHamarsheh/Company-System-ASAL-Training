using Business.Interfaces;
using Business.View;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
	{
		private readonly IDepartmentManager _departmentManager;

        public DepartmentController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        [HttpGet]
        public async Task<ActionResult<IList<DepartmentView>>> GetAllDepartments()
        {
            try
            {
                var departments = await _departmentManager.GetAllDepartments();

                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentView>> CreateDepatment(DepartmentModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return null;

                return await _departmentManager.CreateDepartment(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartmentView>> GetDepartmentById(int id)
        {
            try
            {
                return await _departmentManager.GetDepartmentById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<DepartmentView>> UpdateDepartment(int id, DepartmentModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return null;

                return await _departmentManager.UpdateDepartment(id, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteDepartment(int id)
        {
            try
            {
                return await _departmentManager.DeleteDepartment(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }
    }
}