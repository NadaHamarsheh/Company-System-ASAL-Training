using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
	public class EmployeeDetailModel
	{
        [Required]
        public double Salary { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}