using Business.Interfaces;
using Business.Models;
using Business.Mapping;
using Business.View;
using Infrastructure.Repository;
using Infrastructure;

namespace Business.Managers
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IRepository<Department> _repository;

        public DepartmentManager(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task<IList<DepartmentView>> GetAllDepartments()
        {
            var departments = await _repository.GetAll() ??
                                throw new Exception("No Departments");

            return departments.Where(x => !x.IsDeleted).Select(x => x.EntityToView()).ToList() ??
                    throw new Exception("Problem in converting from Entity to View");
        }

        public async Task<DepartmentView> GetDepartmentById(int id)
        {
            var department = await _repository.GetById(id) ??
                                throw new Exception("No Department Found");

            if (department.IsDeleted == true)
                throw new Exception("Department is already Deleted");

            return department.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<DepartmentView> CreateDepartment(DepartmentModel model)
        {
            var department = model.ModelToEntity() ??
                                throw new Exception("Problem in converting Model to Entity");

            department.CreatedBy = "Nada";
            department.CreatedOn = DateTime.Now;
            department.IsDeleted = false;

            await _repository.Create(department);

            return department.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<DepartmentView> UpdateDepartment(int id, DepartmentModel model)
        {
            var existingDepartment = await _repository.GetById(id) ??
                                throw new Exception("No Department Found");

            if (existingDepartment.IsDeleted == true)
                throw new Exception("Department is already Deleted"); 

            existingDepartment.Name = model.Name;
            existingDepartment.Description = model.Description;
            existingDepartment.ModifiedBy = "Nada";
            existingDepartment.ModifiedOn = DateTime.Now;

            await _repository.Update(id, existingDepartment);

            return existingDepartment.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var existingDepartment = await _repository.GetById(id) ??
                                throw new Exception("No Department Found");

            if (existingDepartment.IsDeleted == true)
                throw new Exception("Department is already Deleted");

            existingDepartment.IsDeleted = true;

            await _repository.Update(id, existingDepartment);

            return true;
        }
    }
}