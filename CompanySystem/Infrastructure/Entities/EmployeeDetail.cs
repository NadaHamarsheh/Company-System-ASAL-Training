using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.SharedFiles;

namespace Infrastructure
{
    [Table("EmployeeDetail")]
    public class EmployeeDetail : TrackingData
	{
        [Key]
        public int Id { get; set; }

        public double Salary { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}

