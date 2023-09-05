using Business.Models;
using Business.View;
using Infrastructure;

namespace Business.Mapping
{
	public static class UserRoleMapping
	{
        public static UserRole ModelToEntity(this UserRoleModel model)
        {
            return (model == null) ? null : new UserRole
            {
                Description = model.Description,
                Name = model.Name
            };
        }

        public static UserRoleView EntityToView(this UserRole userRole)
        {
            return (userRole == null) ? null : new UserRoleView
            {
                Id = userRole.Id,
                Name = userRole.Name,
                Description = userRole.Description,
                CreatedOn = userRole.CreatedOn,
                CreatedBy = userRole.CreatedBy,
                ModifiedOn = userRole.ModifiedOn,
                ModifiedBy = userRole.ModifiedBy,
                IsDeleted = userRole.IsDeleted
            };
        }
    }
}