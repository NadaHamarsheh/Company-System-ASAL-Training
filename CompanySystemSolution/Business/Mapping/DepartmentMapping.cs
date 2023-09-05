using System;
using Business.Models;
using Business.View;
using Infrastructure;


namespace Business.Mapping
{
	public class DepartmentMapping
	{
		public async Task<Department> ModelToEntity(DepartmentModel DepartmentModel)
		{
            if (DepartmentModel.Name == null || DepartmentModel.Description == null)
            {
                return null;
            }

            var Department = new Department
            {
                Id = 0,                         // this must be continue to the last number in the database
                Name = DepartmentModel.Name,
                Description = DepartmentModel.Description,
                CreatedOn = DateTime.Now,
                CreatedBy = "",                 // name of the logging user using a GetCurrentUser method 
                ModifiedOn = DateTime.Now,
                ModifiedBy = ""                 // name of the logging user using a GetCurrentUser method 
            };

            //var Department = new Department
            //{
            //    Name = DepartmentModel.Name,
            //    Description = DepartmentModel.Description
            //};

            return await Task.FromResult(Department);
		}

        public async Task<DepartmentView> EntityToView(Department Department)
        {
            var DepartmentView = new DepartmentView
            {
                Id = Department.Id,
                Name = Department.Name,
                Description = Department.Description,
                CreatedOn = Department.CreatedOn,
                CreatedBy = Department.CreatedBy,
                ModifiedOn = Department.ModifiedOn,
                ModifiedBy = Department.ModifiedBy
            };

            return await Task.FromResult(DepartmentView);
        }
    }
}

