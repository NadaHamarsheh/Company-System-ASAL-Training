using Business.Models;
using Business.View;
using Infrastructure;

namespace Business.Mapping
{
	public static class UserMapping
	{
        public static User ModelToEntity(this UserModel model)
        {
            return (model == null) ? null : new User
            {
                Email = model.Email,
                Password = model.Password,
                UserRoleId = model.UserRoleId,
                UserDetailId = model.UserDetailId,
                EmployeeDetailId = model.EmployeeDetailId,
                LeaderId = model.LeaderId
            };
        }

        public static UserView EntityToView(this User user)
        {
            return (user == null) ? null : new UserView
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                UserRoleId = user.UserRoleId,
                UserDetailId = user.UserDetailId,
                EmployeeDetailId = user.EmployeeDetailId,
                LeaderId = user.LeaderId,
                CreatedOn = user.CreatedOn,
                CreatedBy = user.CreatedBy,
                ModifiedOn = user.ModifiedOn,
                ModifiedBy = user.ModifiedBy,
                IsDeleted = user.IsDeleted
            };
        }
    }
}