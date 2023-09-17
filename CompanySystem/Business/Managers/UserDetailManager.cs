using Business.Interfaces;
using Business.Mapping;
using Business.Models;
using Business.View;
using Infrastructure;
using Infrastructure.Repository;

namespace Business.Managers
{
	public class UserDetailManager : IUserDetailManager
	{
        private readonly IRepository<UserDetail> _repository;

        public UserDetailManager(IRepository<UserDetail> repository)
        {
            _repository = repository;
        }

        public async Task<IList<UserDetailView>> GetAllUserDetails()
        {
            var userDetails = await _repository.GetAll() ??
                                throw new Exception("No User Detail");

            return userDetails.Where(x => !x.IsDeleted).Select(x => x.EntityToView()).ToList() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<UserDetailView> CreateUserDetail(UserDetailModel model)
        {
            var user = model.ModelToEntity() ??
                        throw new Exception("Problem in converting Model to Entity");

            user.CreatedBy = "Nada";
            user.CreatedOn = DateTime.Now;
            user.IsDeleted = false;

            await _repository.Create(user);

            return user.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<UserDetailView> GetUserDetailById(int id)
        {
            var user = await _repository.GetById(id) ??
                            throw new Exception("No User Detail");

            if (user.IsDeleted)
                throw new Exception("User Detail is already Deleted");

            return user.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<UserDetailView> UpdateUserDetail(int id, UserDetailModel model)
        {
            var existingUser = await _repository.GetById(id) ??
                                   throw new Exception("No User Details");

            if (existingUser.IsDeleted)
                throw new Exception("User Detail is already Deleted");

            existingUser.FirstName = model.FirstName;
            existingUser.LastName = model.LastName;
            existingUser.Photo = model.Photo;
            existingUser.Address = model.Address;
            existingUser.Tel = model.Tel;
            existingUser.Experience = model.Experience;
            existingUser.ModifiedBy = "Nada";
            existingUser.ModifiedOn = DateTime.Now;

            await _repository.Update(id, existingUser);

            return existingUser.EntityToView() ??
                    throw new Exception("Problem in converting Entity to View");
        }

        public async Task<bool> DeleteUserDetail(int id)
        {
            var existingUser = await _repository.GetById(id) ??
                                   throw new Exception("No User Detail");

            if (existingUser.IsDeleted)
                throw new Exception("User Detail is already Deleted");

            existingUser.IsDeleted = true;

            await _repository.Update(id, existingUser);

            return true;
        }
    }
}