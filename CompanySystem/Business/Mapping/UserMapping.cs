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
                UserRoleId = model.UserRoleId
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
                CreatedOn = user.CreatedOn,
                CreatedBy = user.CreatedBy,
                ModifiedOn = user.ModifiedOn,
                ModifiedBy = user.ModifiedBy,
                IsDeleted = user.IsDeleted
            };
        }
    }
}