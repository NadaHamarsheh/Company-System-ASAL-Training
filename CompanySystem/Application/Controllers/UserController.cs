using Business.Interfaces;
using Business.Models;
using Business.View;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
	{
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IList<UserView>>> GetAllUsers()
        {
            try
            {
                var users = await _userManager.GetAllUsers();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpGet("User/{id:int}")]
        public async Task<ActionResult<UserView>> GetUserById(int id)
        {
            try
            {
                return await _userManager.GetUserById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserView>> CreateUser(UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return null;

                return await _userManager.CreateUser(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpGet("Role/{roleId:int}")]
        public async Task<ActionResult<UserView>> GetUsersByUserRole(int roleId)
        {
            try
            {
                var users = await _userManager.GetUsersByUserRole(roleId);

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserView>> UpdateUser(int id, UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return null;

                return await _userManager.UpdateUser(id, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            try
            {
                return await _userManager.DeleteUser(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }
    }
}