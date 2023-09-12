using Business.View;
using Business.Mapping;
using Business.Interfaces;
using Infrastructure;
using Infrastructure.Repository;
using Business.Models;

namespace Business.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IRepository<User> _repository;
        private readonly IUserRoleManager _userRoleManager;

        public UserManager(IRepository<User> repository, IUserRoleManager userRoleManager)
        {
            _repository = repository;
            _userRoleManager = userRoleManager;
        }

        public async Task<IList<UserView>> GetAllUsers()
        {
            var users = await _repository.GetAll() ??
                                throw new Exception("No Users");

            return users.Where(x => !x.IsDeleted).Select(x => x.EntityToView()).ToList() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<UserView> GetUserById(int id)
        {
            var user = await _repository.GetById(id) ??
                        throw new Exception("User Not Found");

            if (user.IsDeleted == true)
                throw new Exception("User is already Deleted");

            return user.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<IList<UserView>> GetUsersByUserRole(int id)
        {
            _ = await _userRoleManager.GetUserRoleById(id);

            var users = await _repository.GetUsersByRole(id) ??
                           throw new Exception("Users are Not Found");

            return users.Where(x => !x.IsDeleted).Select(x => x.EntityToView()).ToList() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<UserView> CreateUser(UserModel model)
        {
            _ = await _userRoleManager.GetUserRoleById(model.UserRoleId) ??
                                throw new Exception("User Role Not Found"); ;

            var user = model.ModelToEntity() ??
                        throw new Exception("Problem in converting Model to Entity");

            user.CreatedBy = "Nada";
            user.CreatedOn = DateTime.Now;

            await _repository.Create(user);

            return user.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<UserView> UpdateUser(int id, UserModel model)
        {
            var existingUser = await _repository.GetById(id) ??
                                throw new Exception("User Not Found");

            if (existingUser.IsDeleted)
                throw new Exception("User is already Deleted");

            _ = await _userRoleManager.GetUserRoleById(model.UserRoleId);

            existingUser.Email = model.Email;
            existingUser.Password = model.Password;
            existingUser.UserRoleId = model.UserRoleId;
            existingUser.ModifiedBy = "Nada";
            existingUser.ModifiedOn = DateTime.Now;

            await _repository.Update(id, existingUser);

            return existingUser.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<bool> DeleteUser(int id)
        {
            var existingUser = await _repository.GetById(id) ??
                    throw new Exception("User Not Found");

            if (existingUser.IsDeleted)
                throw new Exception("User is already Deleted");

            existingUser.IsDeleted = true;

            await _repository.Update(id, existingUser);

            return true;
        }
    }
}