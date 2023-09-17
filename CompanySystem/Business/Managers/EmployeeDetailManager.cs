using Business.View;
using Business.Mapping;
using Business.Interfaces;
using Infrastructure;
using Infrastructure.Repository;
using Business.Models;

namespace Business.Managers
{
	public class EmployeeDetailManager : IEmployeeDetailManager
	{
        private readonly IRepository<EmployeeDetail> _repository;
        private readonly IDepartmentManager _departmentManager;

        public EmployeeDetailManager(IRepository<EmployeeDetail> repository, IDepartmentManager departmentManager)
        {
            _repository = repository;
            _departmentManager = departmentManager;
        }

        public async Task<IList<EmployeeDetailView>> GetAllEmployeeDetails()
        {
            var employeeDetails = await _repository.GetAll() ??
                                throw new Exception("No Employee Detail");

            return employeeDetails.Where(x => !x.IsDeleted).Select(x => x.EntityToView()).ToList() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<EmployeeDetailView> CreateEmployeeDetail(EmployeeDetailModel model)
        {
            _ = await _departmentManager.GetDepartmentById(model.DepartmentId) ??
                        throw new Exception("Department Not Found");

            var employee = model.ModelToEntity() ??
                        throw new Exception("Problem in converting Model to Entity");

            employee.CreatedBy = "Nada";
            employee.CreatedOn = DateTime.Now;
            employee.IsDeleted = false;

            await _repository.Create(employee);

            return employee.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<EmployeeDetailView> GetEmployeeDetailById(int id)
        {
            var employee = await _repository.GetById(id) ??
                            throw new Exception("No Employee Detail");

            if (employee.IsDeleted)
                throw new Exception("Employee Detail is already Deleted");

            return employee.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<IList<EmployeeDetailView>> GetEmployeeDetailsByDepartment(int id)
        {
            _ = await _departmentManager.GetDepartmentById(id) ??
                        throw new Exception("Department Not Found");

            var employee = await _repository.GetEmployeeByDepartment(id) ??
                           throw new Exception("Employee are Not Found");

            return employee.Where(x => !x.IsDeleted).Select(x => x.EntityToView()).ToList() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<EmployeeDetailView> UpdateEmployeeDetail(int id, EmployeeDetailModel model)
        {
            var existingEmployee = await _repository.GetById(id) ??
                                   throw new Exception("No Employee Details");

            if (existingEmployee.IsDeleted)
                throw new Exception("Employee Detail is already Deleted");

            _ = await _departmentManager.GetDepartmentById(id) ??
                        throw new Exception("Department Not Found");

            existingEmployee.Salary = model.Salary;
            existingEmployee.StartDate = model.StartDate;
            existingEmployee.EndDate = model.EndDate;
            existingEmployee.DepartmentId = model.DepartmentId;
            existingEmployee.ModifiedBy = "Nada";
            existingEmployee.ModifiedOn = DateTime.Now;

            await _repository.Update(id, existingEmployee);

            return existingEmployee.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<bool> DeleteEmployeeDetail(int id)
        {
            var existingEmployee = await _repository.GetById(id) ??
                                   throw new Exception("No Employee Detail");

            if (existingEmployee.IsDeleted)
                throw new Exception("Employee Detail is already Deleted");

            existingEmployee.IsDeleted = true;

            await _repository.Update(id, existingEmployee);

            return true;
        }
    }
}