using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.SharedFiles;

namespace Infrastructure
{
    [Table("User")]
    public class User : TrackingData
	{
		public int Id { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Password { get; set; }

        [ForeignKey("role")]
        public int RoleId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } 

        [ForeignKey("user")]
        public int UserId { get; set; }
        public UserDetail UserDetails { get; set; } 

    }
}

