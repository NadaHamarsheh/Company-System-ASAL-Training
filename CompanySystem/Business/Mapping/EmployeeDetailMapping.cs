using Business.Models;
using Business.View;
using Infrastructure;

namespace Business.Mapping
{
	public static class EmployeeDetailMapping
	{
        public static EmployeeDetail ModelToEntity(this EmployeeDetailModel model)
        {
            return (model == null) ? null : new EmployeeDetail
            {
                Salary = model.Salary,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                DepartmentId = model.DepartmentId
            };
        }

        public static EmployeeDetailView EntityToView(this EmployeeDetail employee)
        {
            return (employee == null) ? null : new EmployeeDetailView
            {
                Id = employee.Id,
                Salary = employee.Salary,
                StartDate = employee.StartDate,
                EndDate = employee.EndDate,
                DepartmentId = employee.DepartmentId,
                CreatedOn = employee.CreatedOn,
                CreatedBy = employee.CreatedBy,
                ModifiedOn = employee.ModifiedOn,
                ModifiedBy = employee.ModifiedBy,
                IsDeleted = employee.IsDeleted
            };
        }
    }
}