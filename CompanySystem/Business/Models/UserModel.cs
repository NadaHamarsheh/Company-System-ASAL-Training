using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
	public class UserModel
	{
        [Required]
        [MaxLength(40)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        public int UserRoleId { get; set; }

        [Required]
        public int UserDetailId { get; set; }

        [Required]
        public int EmployeeDetailId { get; set; }

        public int LeaderId { get; set; }
    }
}