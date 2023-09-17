using Business.Models;
using Business.View;

namespace Business.Interfaces
{
	public interface IUserDetailManager
	{
        Task<IList<UserDetailView>> GetAllUserDetails();
        Task<UserDetailView> CreateUserDetail(UserDetailModel model);
        Task<UserDetailView> GetUserDetailById(int id);
        Task<bool> DeleteUserDetail(int id);
        Task<UserDetailView> UpdateUserDetail(int id, UserDetailModel model);
    }
}