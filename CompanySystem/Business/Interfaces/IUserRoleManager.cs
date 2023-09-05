using Business.Models;
using Business.View;

namespace Business.Interfaces
{
    public interface IUserRoleManager
    {
        Task<IList<UserRoleView>> GetAllUserRoles();
        Task<UserRoleView> CreateUserRole(UserRoleModel model);
        Task<UserRoleView> GetUserRoleById(int id);
        Task<bool> DeleteUserRole(int id);
        Task<UserRoleView> UpdateUserRole(int id, UserRoleModel model);
    }
}