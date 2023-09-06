using Business.Interfaces;
using Business.Models;
using Business.Mapping;
using Business.View;
using Infrastructure.Repository;
using Infrastructure;

namespace Business.Managers
{
	public class UserRoleManager : IUserRoleManager
	{
        private readonly IRepository<UserRole> _repository;

        public UserRoleManager(IRepository<UserRole> repository)
        {
            _repository = repository;
        }

        public async Task<IList<UserRoleView>> GetAllUserRoles()
        {
            var userRoles = await _repository.GetAll() ??
                                throw new Exception("No User Roles");

            return userRoles.Where(x => !x.IsDeleted).Select(x => x.EntityToView()).ToList() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<UserRoleView> CreateUserRole(UserRoleModel model)
        {
            var role = model.ModelToEntity() ??
                        throw new Exception("Problem in converting Model to Entity");

            role.CreatedBy = "Nada";
            role.CreatedOn = DateTime.Now;
            role.IsDeleted = false;

            await _repository.Create(role);

            return role.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<UserRoleView> GetUserRoleById(int id)
        {
            var role = await _repository.GetById(id) ??
                            throw new Exception("No User Roles");

            if (role.IsDeleted == true)
                throw new Exception("User Role is already Deleted");

            return role.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<UserRoleView> UpdateUserRole(int id, UserRoleModel model)
        {
            var existingRole = await _repository.GetById(id) ??
                                   throw new Exception("No User Roles");

            if (existingRole.IsDeleted == true)
                throw new Exception("User Role is already Deleted");

            existingRole.Name = model.Name;
            existingRole.Description = model.Description;
            existingRole.ModifiedBy = "Nada";
            existingRole.ModifiedOn = DateTime.Now;

            await _repository.Update(id, existingRole);

            return existingRole.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<bool> DeleteUserRole(int id)
        {
            var existingRole = await _repository.GetById(id) ??
                                   throw new Exception("No User Roles");

            if (existingRole.IsDeleted == true)
                throw new Exception("User Role is already Deleted");

            existingRole.IsDeleted = true;

            await _repository.Update(id, existingRole);

            return true;
        }
    }
}