using Business.Models;
using Business.View;
using Infrastructure;

namespace Business.Mapping
{
	public static class DepartmentMapping
	{
        public static Department ModelToEntity(this DepartmentModel model)
		{
            return (model == null) ? null : new Department
            {
                Description = model.Description,
                Name = model.Name
            };
		}

        public static DepartmentView EntityToView(this Department department)
        {
            return (department == null) ? null : new DepartmentView
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                CreatedOn = department.CreatedOn,
                CreatedBy = department.CreatedBy,
                ModifiedOn = department.ModifiedOn,
                ModifiedBy = department.ModifiedBy,
                IsDeleted = department.IsDeleted
            };
        }
    }
}