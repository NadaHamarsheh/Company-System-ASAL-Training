using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Business.Models
{
	public class UserDetailModel
	{
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

        [MaxLength(40)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string Tel { get; set; }

        [MaxLength(40)]
        public string Experience { get; set; }
    }
}