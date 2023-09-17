using Business.Models;
using Business.View;

namespace Business.Interfaces
{
	public interface IEmployeeDetailManager
	{
        Task<IList<EmployeeDetailView>> GetAllEmployeeDetails();
        Task<EmployeeDetailView> CreateEmployeeDetail(EmployeeDetailModel model);
        Task<EmployeeDetailView> GetEmployeeDetailById(int id);
        Task<IList<EmployeeDetailView>> GetEmployeeDetailsByDepartment(int id);
        Task<bool> DeleteEmployeeDetail(int id);
        Task<EmployeeDetailView> UpdateEmployeeDetail(int id, EmployeeDetailModel model);
    }
}