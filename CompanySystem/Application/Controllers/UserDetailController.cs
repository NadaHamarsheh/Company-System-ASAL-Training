using Business.Interfaces;
using Business.View;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Managers;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDetailController : ControllerBase
	{
        private readonly IUserDetailManager _userDetailManager;

        public UserDetailController(IUserDetailManager userDetailManager)
        {
            _userDetailManager = userDetailManager;
        }

        [HttpGet]
        public async Task<ActionResult<IList<UserDetailView>>> GetAllUserDetails()
        {
            try
            {
                var userRoles = await _userDetailManager.GetAllUserDetails();

                return Ok(userRoles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDetailView>> CreateUserDetail(UserDetailModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return null;

                return await _userDetailManager.CreateUserDetail(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDetailView>> GetUserDetailById(int id)
        {
            try
            {
                return await _userDetailManager.GetUserDetailById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserDetailView>> UpdateUserDetail(int id, UserDetailModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return null;

                return await _userDetailManager.UpdateUserDetail(id, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteUserDetail(int id)
        {
            try
            {
                return await _userDetailManager.DeleteUserDetail(id); ;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"{ex.Message}");
            }
        }
    }
}