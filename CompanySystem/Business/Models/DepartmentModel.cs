using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
	public class DepartmentModel
	{
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }
    }
}