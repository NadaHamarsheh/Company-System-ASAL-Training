using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.SharedFiles;

namespace Infrastructure
{
    [Table("Department")]
    public class Department : TrackingData
	{
		[Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        //public EmployeeDetail EmployeeDetails { get; set; }
    }
}