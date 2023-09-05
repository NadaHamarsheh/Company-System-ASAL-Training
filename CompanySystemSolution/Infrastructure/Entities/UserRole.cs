using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.SharedFiles;

namespace Infrastructure
{
    [Table("UserRole")]
    public class UserRole : TrackingData
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(10)]
		public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

		public User User { get; set; }
    }
}

