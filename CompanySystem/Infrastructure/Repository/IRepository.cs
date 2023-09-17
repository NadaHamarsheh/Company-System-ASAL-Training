
namespace Infrastructure.Repository
{
	public interface IRepository<T> where T : class
	{
        Task Create(T entity);
        Task<IList<T>> GetAll();
        Task<T> GetById(object id);
        Task<IList<User>> GetUsersByRole(int id);
        Task Update(object id, T entity);
        Task<IList<EmployeeDetail>> GetEmployeeByDepartment(int id);
    }
}