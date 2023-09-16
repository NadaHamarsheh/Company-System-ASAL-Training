using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.SharedFiles;

namespace Infrastructure
{
    [Table("User")]
    public class User : TrackingData
	{
        [Key]
		public int Id { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        [MaxLength(30)]
        public string Password { get; set; }

        [ForeignKey("UserRoleId")]
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        [ForeignKey("UserDetailId")]
        public int UserDetailId { get; set; }
        public UserDetail UserDetails { get; set; }

        [ForeignKey("EmployeeDetailId")]
        public int EmployeeDetailId { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }
    }
}