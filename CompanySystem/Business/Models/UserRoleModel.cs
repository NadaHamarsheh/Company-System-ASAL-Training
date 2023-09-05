using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
	public class UserRoleModel
	{
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }
    }
}

