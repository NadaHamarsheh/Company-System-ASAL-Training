using Business.Models;
using Business.View;

namespace Business.Interfaces
{
	public interface IUserManager
	{
        Task<IList<UserView>> GetAllUsers();
        Task<UserView> GetUserById(int id);
        Task<IList<UserView>> GetUsersByUserRole(int id);
        Task<UserView> CreateUser(UserModel model);
        Task<UserView> UpdateUser(int id, UserModel model);
        Task<bool> DeleteUser(int id);
    }
}