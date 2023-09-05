using Business.Interfaces;
using Business.View;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRoleController : ControllerBase
	{
        private readonly IUserRoleManager _userRoleManager;

        public UserRoleController(IUserRoleManager userRoleManager)
        {
            _userRoleManager = userRoleManager;
        }

        [HttpGet]
        public async Task<ActionResult<IList<UserRoleView>>> GetAllUserRoles()
        {
            try
            {
                var userRoles = await _userRoleManager.GetAllUserRoles();

                return Ok(userRoles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserRoleView>> CreateUserRole(UserRoleModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return null;

                return await _userRoleManager.CreateUserRole(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserRoleView>> GetUserRoleById(int id)
        {
            try
            {
                return await _userRoleManager.GetUserRoleById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserRoleView>> UpdateUserRole(int id, UserRoleModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return null;

                return await _userRoleManager.UpdateUserRole(id, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteUserRole(int id)
        {
            try
            {
                return await _userRoleManager.DeleteUserRole(id); ;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }
    }
}