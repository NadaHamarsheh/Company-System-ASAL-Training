using Business.Models;
using Business.View;

namespace Business.Interfaces
{
	public interface IDepartmentManager
	{
        Task<DepartmentView> CreateDepartment(DepartmentModel model);
        Task<IList<DepartmentView>> GetAllDepartments();
        Task<DepartmentView> GetDepartmentById(int id);
        Task<bool> DeleteDepartment(int id);
        Task<DepartmentView> UpdateDepartment(int id, DepartmentModel model);
    }
}