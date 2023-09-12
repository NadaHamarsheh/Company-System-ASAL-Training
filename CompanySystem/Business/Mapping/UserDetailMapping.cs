using Business.Models;
using Business.View;
using Infrastructure;

namespace Business.Mapping
{
	public static class UserDetailMapping
	{
        public static UserDetail ModelToEntity(this UserDetailModel model)
        {
            return (model == null) ? null : new UserDetail
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Tel = model.Tel,
                Photo = model.Photo,
                Address = model.Address,
                Experience = model.Experience
            };
        }

        public static UserDetailView EntityToView(this UserDetail user)
        {
            return (user == null) ? null : new UserDetailView
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Tel = user.Tel,
                Photo = user.Photo,
                Address = user.Address,
                Experience = user.Experience,
                CreatedOn = user.CreatedOn,
                CreatedBy = user.CreatedBy,
                ModifiedOn = user.ModifiedOn,
                ModifiedBy = user.ModifiedBy,
                IsDeleted = user.IsDeleted
            };
        }
    }
}