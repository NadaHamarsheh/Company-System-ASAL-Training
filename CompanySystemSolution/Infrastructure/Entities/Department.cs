using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.SharedFiles;

namespace Infrastructure
{
    [Table("Department")]
    public class Department : TrackingData
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        public string Description { get; set; }

        // define one to many relation [employee & department]
        public EmployeeDetail EmployeeDetails { get; set; }
    }
}

